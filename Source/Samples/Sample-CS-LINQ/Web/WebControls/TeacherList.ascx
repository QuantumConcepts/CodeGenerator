<%@ Control CodeBehind="TeacherList.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.TeacherList" Language="C#" %>

<asp:DataGrid id="Grid" runat="server" DataKeyField="ID" AutoGenerateColumns="false" CssClass="Grid" HeaderStyle-CssClass="Header" AlternatingItemStyle-CssClass="Alternate" OnItemCommand="Grid_ItemCommand" OnNeedsDataBinding="Grid_NeedsDataBinding">
  <Columns>
    <asp:BoundColumn HeaderText="ID" DataField="ID" HeaderStyle-Width="50px" ItemStyle-Width="50px" />
    <asp:BoundColumn HeaderText="SSN" DataField="SSN" />
    <asp:BoundColumn HeaderText="First Name" DataField="FirstName" />
    <asp:BoundColumn HeaderText="Last Name" DataField="LastName" />
    <asp:BoundColumn HeaderText="Active" DataField="Active" HeaderStyle-Width="50px" ItemStyle-Width="50px" />
    <asp:ButtonColumn Text="Edit" CommandName="Edit" ButtonType="LinkButton" HeaderStyle-CssClass="Action" ItemStyle-CssClass="Action" />
    <asp:ButtonColumn Text="Delete" CommandName="Delete" ButtonType="LinkButton" HeaderStyle-CssClass="Action" ItemStyle-CssClass="Action" />
  </Columns>
</asp:DataGrid>