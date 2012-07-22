<%@ Control CodeBehind="CourseList.ascx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.WebControls.CourseList" Language="C#" %>

<asp:DataGrid id="Grid" runat="server" DataKeyField="ID" AutoGenerateColumns="false" CssClass="Grid" HeaderStyle-CssClass="Header" AlternatingItemStyle-CssClass="Alternate" OnItemCommand="Grid_ItemCommand" OnNeedsDataBinding="Grid_NeedsDataBinding">
  <Columns>
    <asp:BoundColumn HeaderText="ID" DataField="ID" HeaderStyle-Width="50px" ItemStyle-Width="50px" />
    <asp:BoundColumn HeaderText="Semester" DataField="Semester" />
    <asp:BoundColumn HeaderText="Teacher" DataField="Teacher" />
    <asp:BoundColumn HeaderText="Number" DataField="Number" />
    <asp:BoundColumn HeaderText="Name" DataField="Name" />
    <asp:TemplateColumn HeaderText="Status" HeaderStyle-Width="150px" ItemStyle-Width="150px">
      <ItemTemplate><%# Enum.GetName(typeof(QuantumConcepts.CodeGenerator.Sample.DataAccess.CourseStatus), Eval("Status")) %></ItemTemplate>
    </asp:TemplateColumn>
    <asp:ButtonColumn Text="Edit" CommandName="Edit" ButtonType="LinkButton" HeaderStyle-CssClass="Action" ItemStyle-CssClass="Action" />
    <asp:ButtonColumn Text="Delete" CommandName="Delete" ButtonType="LinkButton" HeaderStyle-CssClass="Action" ItemStyle-CssClass="Action" />
  </Columns>
</asp:DataGrid>