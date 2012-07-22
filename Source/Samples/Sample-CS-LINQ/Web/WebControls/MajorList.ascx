<%@ Control CodeBehind="MajorList.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.MajorList" Language="C#" %>

<asp:DataGrid id="Grid" runat="server" DataKeyField="ID" AutoGenerateColumns="false" CssClass="Grid" HeaderStyle-CssClass="Header" AlternatingItemStyle-CssClass="Alternate" OnItemCommand="Grid_ItemCommand" OnNeedsDataBinding="Grid_NeedsDataBinding">
  <Columns>
    <asp:BoundColumn HeaderText="ID" DataField="ID" HeaderStyle-Width="50px" ItemStyle-Width="50px" />
    <asp:BoundColumn HeaderText="Name" DataField="Name" />
    <asp:ButtonColumn Text="Edit" CommandName="Edit" ButtonType="LinkButton" HeaderStyle-CssClass="Action" ItemStyle-CssClass="Action" />
    <asp:ButtonColumn Text="Delete" CommandName="Delete" ButtonType="LinkButton" HeaderStyle-CssClass="Action" ItemStyle-CssClass="Action" />
  </Columns>
</asp:DataGrid>