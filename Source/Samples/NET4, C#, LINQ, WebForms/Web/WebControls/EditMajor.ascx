<%@ Control CodeBehind="EditMajor.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.EditMajor" Language="C#" %>

<div class="Field"><span class="Label">Name:</span><span class="Input"><asp:TextBox ID="NameField" runat="server" />
    <asp:RequiredFieldValidator ID="NameValidator" runat="server" ControlToValidate="NameField" ErrorMessage="The Name field is invalid." Required="true" /></span></div>
<div class="Actions">
  <asp:LinkButton ID="SaveButton" runat="server" Text="Save" CssClass="Action Accept" OnClick="SaveButton_Click" />
  <asp:LinkButton ID="CancelButton" runat="server" Text="Cancel" CssClass="Action Cancel" OnClick="CancelButton_Click" />
</div>