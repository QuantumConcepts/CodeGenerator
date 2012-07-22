<%@ Control CodeBehind="EditCourse.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.EditCourse" Language="C#" %>

<div class="Field"><span class="Label">Semester:</span><span class="Input"><asp:DropDownList ID="SemesterField" runat="server" AppendDataBoundItems="true" DataValueField="ID" DataTextField="Name" /></span></div>
<div class="Field"><span class="Label">Teacher:</span><span class="Input"><asp:DropDownList ID="TeacherField" runat="server" AppendDataBoundItems="true" DataValueField="ID" DataTextField="FullName" /></span></div>
<div class="Field"><span class="Label">Number:</span><span class="Input"><asp:TextBox ID="NumberField" runat="server" />
    <asp:RequiredFieldValidator ID="NumberValidator" runat="server" ControlToValidate="NumberField" ErrorMessage="The Number field is invalid." Required="true" /></span></div>
<div class="Field"><span class="Label">Name:</span><span class="Input"><asp:TextBox ID="NameField" runat="server" />
    <asp:RequiredFieldValidator ID="NameValidator" runat="server" ControlToValidate="NameField" ErrorMessage="The Name field is invalid." Required="true" /></span></div>
<div class="Field"><span class="Label">Status:</span><span class="Input"><asp:DropDownList ID="CourseStatusField" runat="server" AppendDataBoundItems="true" DataValueField="" DataTextField="" /></span></div>
<div class="Actions">
  <asp:LinkButton ID="SaveButton" runat="server" Text="Save" CssClass="Action Accept" OnClick="SaveButton_Click" />
  <asp:LinkButton ID="CancelButton" runat="server" Text="Cancel" CssClass="Action Cancel" OnClick="CancelButton_Click" />
</div>