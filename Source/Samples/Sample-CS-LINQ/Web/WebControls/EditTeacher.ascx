<%@ Control CodeBehind="EditTeacher.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.EditTeacher" Language="C#" %>

<div class="Field"><span class="Label">SSN:</span><span class="Input"><asp:TextBox ID="SSNField" runat="server" />
    <Ajax:MaskedEditExtender ID="SSNMaskedEditExtender" runat="server" TargetControlID="SSNField" Mask="999-99-9999" ClearMaskOnLostFocus="false" ClearTextOnInvalid="true" />
    <asp:RequiredFieldValidator ID="SSNValidator" runat="server" ControlToValidate="SSNField" ErrorMessage="The SSN field is invalid." Required="true" /></span></div>
<div class="Field"><span class="Label">First Name:</span><span class="Input"><asp:TextBox ID="FirstNameField" runat="server" />
    <asp:RequiredFieldValidator ID="FirstNameValidator" runat="server" ControlToValidate="FirstNameField" ErrorMessage="The First Name field is invalid." Required="true" /></span></div>
<div class="Field"><span class="Label">Last Name:</span><span class="Input"><asp:TextBox ID="LastNameField" runat="server" />
    <asp:RequiredFieldValidator ID="LastNameValidator" runat="server" ControlToValidate="LastNameField" ErrorMessage="The Last Name field is invalid." Required="true" /></span></div>
<div class="Field"><span class="Label">Active:</span><span class="Input"><asp:CheckBox ID="ActiveField" runat="server" /></span></div>
<div class="Actions">
  <asp:LinkButton ID="SaveButton" runat="server" Text="Save" CssClass="Action Accept" OnClick="SaveButton_Click" />
  <asp:LinkButton ID="CancelButton" runat="server" Text="Cancel" CssClass="Action Cancel" OnClick="CancelButton_Click" />
</div>