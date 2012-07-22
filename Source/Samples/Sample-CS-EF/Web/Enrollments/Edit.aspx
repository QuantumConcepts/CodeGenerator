<%@ Page Title="Create or Edit Enrollment" MasterPageFile="~/Main.Master" CodeBehind="Edit.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.Enrollments.Edit" Language="C#" %>
<%@ Register TagPrefix="Sample" TagName="Edit" Src="~/WebControls/EditEnrollment.ascx" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <Sample:Edit ID="EditControl" runat="server" OnSaved="EditControl_Saved" OnCancelled="EditControl_Cancelled" />
</asp:Content>