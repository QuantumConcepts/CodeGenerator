using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditParameterDialog<T> : Form
        where T : IProjectSchemaElement
    {
        private Project _project;
        private bool _isReturnParameter;
        public Parameter<T> Parameter { get; private set; }

        public EditParameterDialog(Project project, bool isReturnParameter)
            : this(project, isReturnParameter, null)
        { }

        public EditParameterDialog(Project project, bool isReturnParameter, Parameter<T> parameter)
        {
            InitializeComponent();
            _project = project;
            _isReturnParameter = isReturnParameter;
            this.Parameter = parameter;
        }

        private void EditParameterDialog_Load(object sender, EventArgs e)
        {
            modifierGroupBox.Enabled = !_isReturnParameter;
            voidDataTypeRadioButton.Enabled = _isReturnParameter;
            tablesComboBox.DataSource = _project.Entities;
            enumTableComboBox.DataSource = (from tm in _project.Entities
                                            where tm.ContainsEnumeration()
                                            select tm).ToList();

            if (this.Parameter == null)
            {
                this.Parameter = new Parameter<T>();
                nameTextBox.Enabled = !_isReturnParameter;
                otherDataTypeComboBox.Focus();
            }
            else
            {
                if (!this.Parameter.IsReturnParameter)
                {
                    noneModifierRadioButton.Checked = (this.Parameter.Modifier == Parameter<T>.ParameterModifier.None);
                    refModifierRadioButton.Checked = (this.Parameter.Modifier == Parameter<T>.ParameterModifier.Ref);
                    outModifierRadioButton.Checked = (this.Parameter.Modifier == Parameter<T>.ParameterModifier.Out);
                    paramsModifierRadioButton.Checked = (this.Parameter.Modifier == Parameter<T>.ParameterModifier.Params);
                }

                if (this.Parameter.Type == Parameter<T>.ParameterType.DataObject)
                {
                    Entity selectedTableMapping = this.Parameter.DataTypeReferencedTableMapping;

                    dataObjectDataTypeRadioButton.Checked = true;

                    if (selectedTableMapping != null)
                        tablesComboBox.SelectedItem = selectedTableMapping;
                }
                else if (Parameter.Type == Parameter<T>.ParameterType.Enum)
                {
                    Entity selectedTableMapping = Parameter.DataTypeReferencedTableMapping;
                    Property selectedColumnMapping = Parameter.DataTypeReferencedEnumColumnMapping;

                    enumDataTypeRadioButton.Checked = true;

                    if (selectedTableMapping != null)
                        enumTableComboBox.SelectedItem = selectedTableMapping;

                    if (selectedColumnMapping != null)
                        enumTypeComboBox.SelectedItem = selectedColumnMapping;
                }
                else
                {
                    voidDataTypeRadioButton.Checked = (_isReturnParameter && this.Parameter.Type == Parameter<T>.ParameterType.Void);
                    otherDataTypeRadioButton.Checked = (!_isReturnParameter || this.Parameter.Type == Parameter<T>.ParameterType.Other);
                    tablesComboBox.SelectedIndex = -1;
                    otherDataTypeComboBox.Text = this.Parameter.OtherDataType;
                }

                singleDataTypeRadioButton.Checked = (this.Parameter.Quantifier == Parameter<T>.ParameterQuantifier.Single);
                arrayOfDataTypeRadioButton.Checked = (this.Parameter.Quantifier == Parameter<T>.ParameterQuantifier.Array);
                listOfDataTypeRadioButton.Checked = (this.Parameter.Quantifier == Parameter<T>.ParameterQuantifier.List);
                enumerableOfDataTypeRadioButton.Checked = (this.Parameter.Quantifier == Parameter<T>.ParameterQuantifier.IEnumerable);

                nullableDataTypeCheckBox.Checked = this.Parameter.Nullable;

                nameTextBox.Enabled = !this.Parameter.IsReturnParameter;

                if (!this.Parameter.IsReturnParameter)
                    nameTextBox.Text = this.Parameter.Name;
            }
        }

        private void DataType_CheckChanged(object sender, EventArgs e)
        {
            UpdateParameterDisplay();
        }

        private void UpdateParameterDisplay()
        {
            Parameter<T>.ParameterType parameterType = GetSelectedParameterType();
            bool isVoidSelected = (parameterType == Parameter<T>.ParameterType.Void);
            bool isDataObjectSelected = (parameterType == Parameter<T>.ParameterType.DataObject);
            bool isEnumSelected = (parameterType == Parameter<T>.ParameterType.Enum);
            bool isOtherSelected = (parameterType == Parameter<T>.ParameterType.Other);
            
            singleDataTypeRadioButton.Enabled = (!isVoidSelected);
            singleDataTypeRadioButton.Checked = (isEnumSelected || singleDataTypeRadioButton.Checked);
            arrayOfDataTypeRadioButton.Enabled = (!isVoidSelected && !isEnumSelected);
            listOfDataTypeRadioButton.Enabled = (!isVoidSelected && !isEnumSelected);
            enumerableOfDataTypeRadioButton.Enabled = (!isVoidSelected && !isEnumSelected);
            tablesComboBox.Visible = dataObjectDataTypeRadioButton.Checked;
            enumTableComboBox.Visible = enumDataTypeRadioButton.Checked;
            enumTypeComboBox.Visible = enumDataTypeRadioButton.Checked;
            otherDataTypeComboBox.Visible = otherDataTypeRadioButton.Checked;
            nullableDataTypeCheckBox.Checked = (nullableDataTypeCheckBox.Checked && (enumDataTypeRadioButton.Checked || otherDataTypeRadioButton.Checked));
            nullableDataTypeCheckBox.Enabled = (enumDataTypeRadioButton.Checked || otherDataTypeRadioButton.Checked);

            if (!isDataObjectSelected)
            {
                tablesComboBox.SelectedIndex = -1;
                tablesComboBox.Focus();
            }

            if (!isEnumSelected)
            {
                enumTableComboBox.SelectedIndex = -1;
                enumTypeComboBox.SelectedIndex = -1;
                enumTableComboBox.Focus();
            }

            if (!isOtherSelected)
            {
                otherDataTypeComboBox.Text = null;
                otherDataTypeComboBox.Focus();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Parameter<T>.ParameterType parameterType = GetSelectedParameterType();
            Parameter<T>.ParameterQuantifier quantifier = GetSelectedQuantifier();
            Parameter<T>.ParameterModifier modifier = GetSelectedModifier();
            bool isVoidSelected = (parameterType == Parameter<T>.ParameterType.Void);
            bool isDataObjectSelected = (parameterType == Parameter<T>.ParameterType.DataObject);
            bool isEnumSelected = (parameterType == Parameter<T>.ParameterType.Enum);
            bool isOtherSelected = (parameterType == Parameter<T>.ParameterType.Other);
            bool isNullable = ((isEnumSelected || isOtherSelected) && nullableDataTypeCheckBox.Checked);

            if (string.IsNullOrEmpty(nameTextBox.Text) && !_isReturnParameter)
            {
                MessageBox.Show("Please enter the name.");
                nameTextBox.Focus();
                nameTextBox.SelectAll();
                return;
            }

            if (isDataObjectSelected && tablesComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select the data object.");
                return;
            }

            if (isEnumSelected && (enumTableComboBox.SelectedIndex < 0 || enumTypeComboBox.SelectedIndex < 0))
            {
                MessageBox.Show("Please select the enum table and column.");
                return;
            }

            if (isOtherSelected && string.IsNullOrEmpty(otherDataTypeComboBox.Text))
            {
                MessageBox.Show("Please enter the data type.");
                return;
            }

            if (_isReturnParameter)
            {
                if (isVoidSelected)
                    this.Parameter = Parameter<T>.CreateVoidReturnParameter(this.Parameter.Annotations, this.Parameter.Attributes);
                else if (isDataObjectSelected)
                    this.Parameter = Parameter<T>.CreateDataObjectReturnParameter(GetSelectedTableMapping(), quantifier, this.Parameter.Annotations, this.Parameter.Attributes);
                else if (isEnumSelected)
                    this.Parameter = Parameter<T>.CreateEnumReturnParameter(GetSelectedEnumerationMapping().ColumnMapping, isNullable, this.Parameter.Annotations, this.Parameter.Attributes);
                else
                    this.Parameter = Parameter<T>.CreateOtherReturnParameter(otherDataTypeComboBox.Text, quantifier, isNullable, this.Parameter.Annotations, this.Parameter.Attributes);
            }
            else
            {
                if (isDataObjectSelected)
                    Parameter = Parameter<T>.CreateDataObjectParameter(nameTextBox.Text, modifier, quantifier, GetSelectedTableMapping(), this.Parameter.Annotations, this.Parameter.Attributes);
                else if (isEnumSelected)
                    Parameter = Parameter<T>.CreateEnumParameter(nameTextBox.Text, modifier, GetSelectedEnumerationMapping().ColumnMapping, isNullable, this.Parameter.Annotations, this.Parameter.Attributes);
                else
                    Parameter = Parameter<T>.CreateOtherParameter(nameTextBox.Text, modifier, quantifier, otherDataTypeComboBox.Text, isNullable, this.Parameter.Annotations, this.Parameter.Attributes);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Parameter<T>.ParameterModifier GetSelectedModifier()
        {
            if (noneModifierRadioButton.Checked)
                return Parameter<T>.ParameterModifier.None;
            else if (refModifierRadioButton.Checked)
                return Parameter<T>.ParameterModifier.Ref;
            else if (outModifierRadioButton.Checked)
                return Parameter<T>.ParameterModifier.Out;
            else if (paramsModifierRadioButton.Checked)
                return Parameter<T>.ParameterModifier.Params;

            throw new ApplicationException("Unknown or no Modifier selected.");
        }

        private Parameter<T>.ParameterQuantifier GetSelectedQuantifier()
        {
            if (singleDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterQuantifier.Single;
            else if (arrayOfDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterQuantifier.Array;
            else if (listOfDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterQuantifier.List;
            else if (enumerableOfDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterQuantifier.IEnumerable;

            throw new ApplicationException("Unknown or no Quantifier selected.");
        }

        private Parameter<T>.ParameterType GetSelectedParameterType()
        {
            if (voidDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterType.Void;
            else if (dataObjectDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterType.DataObject;
            else if (enumDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterType.Enum;
            else if (otherDataTypeRadioButton.Checked)
                return Parameter<T>.ParameterType.Other;

            throw new ApplicationException("Unknown or no Type selected.");
        }

        private Entity GetSelectedTableMapping()
        {
            return (Entity)tablesComboBox.SelectedItem;
        }

        private Entity GetSelectedEnumTableMapping()
        {
            return (Entity)enumTableComboBox.SelectedItem;
        }

        private EnumerationMapping GetSelectedEnumerationMapping()
        {
            return (EnumerationMapping)enumTypeComboBox.SelectedItem;
        }

        private void enumTableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enumTableComboBox.SelectedItem != null)
            {
                enumTypeComboBox.DataSource = (from cm in ((Entity)enumTableComboBox.SelectedItem).Properties
                                               where cm.EnumerationMapping != null
                                               select cm.EnumerationMapping).ToList();
            }
        }

        private void enumTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnumerationMapping enumerationMapping = GetSelectedEnumerationMapping();

            nullableDataTypeCheckBox.Checked = (enumerationMapping != null && enumerationMapping.ColumnMapping.Nullable);
        }

        private void editAnnotationsButton_Click(object sender, EventArgs e)
        {
            using (EditAnnotations<Parameter<T>> dialog = new EditAnnotations<Parameter<T>>(Parameter))
            {
                dialog.ShowDialog();
            }
        }

        private void attributesButton_Click(object sender, EventArgs e)
        {
            using (EditAttributes<Parameter<T>> dialog = new EditAttributes<Parameter<T>>(Parameter))
            {
                dialog.ShowDialog();
            }
        }
    }
}
