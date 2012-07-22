<%@ Control CodeBehind="EditEnrollment.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.EditEnrollment" Language="C#" %>

<div class="Field"><span class="Label">Student:</span><span class="Input"><asp:DropDownList ID="StudentField" runat="server" AppendDataBoundItems="true" DataValueField="ID" DataTextField="FullName" /></span></div>
<div class="Field"><span class="Label">Course:</span><span class="Input"><asp:DropDownList ID="CourseField" runat="server" AppendDataBoundItems="true" DataValueField="ID" DataTextField="FullName" /></span></div>
<div class="Actions">
  <asp:LinkButton ID="SaveButton" runat="server" Text="Save" CssClass="Action Accept" OnClick="SaveButton_Click" />
  <asp:LinkButton ID="CancelButton" runat="server" Text="Cancel" CssClass="Action Cancel" OnClick="CancelButton_Click" />
</div>