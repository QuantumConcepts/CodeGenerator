<%@ Page Title="Home" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QuantumConcepts.CodeGenerator.Sample.Web.Default" %>

<asp:Content ContentPlaceHolderID="content" runat="server">
    <p>Welcome to the Quantum Concepts Code Generator Sample! This sample project has very little hand-written code - see the breakdown below for more information.</p>

    <p>Use the links above to see what this simple sample application can do - and remember, <strong>93.7% of this code was generated</strong> by <a href="http://www.thecodegenerator.com" title="CodeGenerator" target="_blank">CodeGenerator</a>.</p>

    <h3>Configuration</h3>
    <ul>
        <li>Microsoft SQL Server 2008 R2 database</li>
        <li>Microsoft Visual Studio 2010 solution with the following projects:
            <ul>
                <li><strong>Database Server:</strong> For deploying the Login for the database schema project.</li>
                <li><strong>Database Schema:</strong> For deploying the schema for the entire project.</li>
                <li><strong>Common:</strong> Referenced by all other project, includes common utilities.</li>
                <li><strong>DataObjects:</strong> Basic data objects with simple properties and nothing else.</li>
                <li><strong>DataAccess:</strong> LINQ-to-SQL objects for interacting with the database - inherits from the DataObjects layer.</li>
                <li><strong>Logic:</strong> Handles all logical interaction using the DataAccess layer - custom API logic is written here.</li>
                <li><strong>Service:</strong> A WCF service which exposes both REST and SOAP to retrieve information from the Logic layer.</li>
                <li><strong>Web:</strong> The web front-end which interacts with the Logic layer to view, update, and delete data. Also exposes the REST and SOAP end-points. Also includes full service documentation.</li>
            </ul>
        </li>
        <li>Microsoft IIS 7.5 on Windows Server 2008 R2.</li>
    </ul>

    <h3>Code Breakdown</h3>
    <p>Have a look at the following table. It indicates each source file, the number of lines, whether it's generated, etc. In short, <strong>93.7% of the code in this sample project was generated</strong>. What's that mean? If you need to generate administrative applications you can just point to your database, click "Generate" and you're 90% done.</p>
    <p><a href="http://archive.msdn.microsoft.com/LOCCounter" title="LOC Counter" target="_blank">LOC Counter</a> was used to generate these results - if you'd like, you may <a href="App_Resources/Download/Metrics.pdf" title="LOC Counter Report" target="_blank">view the full report</a>.</p>
    <table class="Metrics">
        <thead>
                <tr>
	                <th scope="col">Project</td>
	                <th scope="col">File</td>
	                <th scope="col"># Lines</td>
	                <th scope="col">Generated?</td>
	                <th scope="col"># Hand-coded Lines</td>
	                <th scope="col"># Generated Lines</td>
                <tr/>
        </thead>
        <tbody>
            <tr>
	            <td scope="row">Common</td>
	            <td><a href="ViewCode.aspx?Path=Common/Utils/SampleConfigUtil.cs" title="View Code for Utils/SampleConfigUtil.cs" target="_blank">Utils/SampleConfigUtil.cs</a></td>
	            <td>23</td>
	            <td>No</td>
	            <td>23</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Common</td>
	            <td><a href="ViewCode.aspx?Path=Common/Utils/SampleUrlUtil.cs" title="View Code for Utils/SampleUrlUtil.cs" target="_blank">Utils/SampleUrlUtil.cs</a></td>
	            <td>17</td>
	            <td>No</td>
	            <td>17</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/Cache/Cache.Generated.cs" title="View Code for Cache/Cache.Generated.cs" target="_blank">Cache/Cache.Generated.cs</a></td>
	            <td>52</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>52</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/Course.cs" title="View Code for Course.cs" target="_blank">Course.cs</a></td>
	            <td>12</td>
	            <td>No</td>
	            <td>12</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/DataAccess.Generated.cs" title="View Code for DataAccess.Generated.cs" target="_blank">DataAccess.Generated.cs</a></td>
	            <td>1,261</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>1,261</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/SampleObjectContext.cs" title="View Code for SampleObjectContext.cs" target="_blank">SampleObjectContext.cs</a></td>
	            <td>16</td>
	            <td>No</td>
	            <td>16</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/Semester.cs" title="View Code for Semester.cs" target="_blank">Semester.cs</a></td>
	            <td>11</td>
	            <td>No</td>
	            <td>11</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/Student.cs" title="View Code for Student.cs" target="_blank">Student.cs</a></td>
	            <td>12</td>
	            <td>No</td>
	            <td>12</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">DataAccess</td>
	            <td><a href="ViewCode.aspx?Path=DataAccess/Teacher.cs" title="View Code for Teacher.cs" target="_blank">Teacher.cs</a></td>
	            <td>12</td>
	            <td>No</td>
	            <td>12</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">DataObjects</td>
	            <td><a href="ViewCode.aspx?Path=DataObjects/DataObjects.Generated.cs" title="View Code for DataObjects.Generated.cs" target="_blank">DataObjects.Generated.cs</a></td>
	            <td>113</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>113</td>
            <tr/>
            <tr>
	            <td scope="row">DataObjects</td>
	            <td><a href="ViewCode.aspx?Path=DataObjects/Enumerations.Generated.cs" title="View Code for Enumerations.Generated.cs" target="_blank">Enumerations.Generated.cs</a></td>
	            <td>17</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>17</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/CourseLogic.cs" title="View Code for CourseLogic.cs" target="_blank">CourseLogic.cs</a></td>
	            <td>26</td>
	            <td>No</td>
	            <td>26</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/Logic.Generated.cs" title="View Code for Logic.Generated.cs" target="_blank">Logic.Generated.cs</a></td>
	            <td>560</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>560</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/MajorLogic.cs" title="View Code for MajorLogic.cs" target="_blank">MajorLogic.cs</a></td>
	            <td>16</td>
	            <td>No</td>
	            <td>16</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/Security/SampleEncryptionUtil.cs" title="View Code for Security/SampleEncryptionUtil.cs" target="_blank">Security/SampleEncryptionUtil.cs</a></td>
	            <td>17</td>
	            <td>No</td>
	            <td>17</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/SemesterLogic.cs" title="View Code for SemesterLogic.cs" target="_blank">SemesterLogic.cs</a></td>
	            <td>16</td>
	            <td>No</td>
	            <td>16</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/StudentLogic.cs" title="View Code for StudentLogic.cs" target="_blank">StudentLogic.cs</a></td>
	            <td>17</td>
	            <td>No</td>
	            <td>17</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Logic</td>
	            <td><a href="ViewCode.aspx?Path=Logic/TeacherLogic.cs" title="View Code for TeacherLogic.cs" target="_blank">TeacherLogic.cs</a></td>
	            <td>16</td>
	            <td>No</td>
	            <td>16</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/IREST.Generated.cs" title="View Code for IREST.Generated.cs" target="_blank">IREST.Generated.cs</a></td>
	            <td>254</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>254</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/ISOAP.Generated.cs" title="View Code for ISOAP.Generated.cs" target="_blank">ISOAP.Generated.cs</a></td>
	            <td>160</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>160</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/REST.cs" title="View Code for REST.cs" target="_blank">REST.cs</a></td>
	            <td>39</td>
	            <td>No</td>
	            <td>39</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/REST.Generated.cs" title="View Code for REST.Generated.cs" target="_blank">REST.Generated.cs</a></td>
	            <td>242</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>242</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/ServiceObjects/BaseServiceObjects.Generated.cs" title="View Code for ServiceObjects/BaseServiceObjects.Generated.cs" target="_blank">ServiceObjects/BaseServiceObjects.Generated.cs</a></td>
	            <td>75</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>75</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/ServiceObjects/REST/Link.cs" title="View Code for ServiceObjects/REST/Link.cs" target="_blank">ServiceObjects/REST/Link.cs</a></td>
	            <td>25</td>
	            <td>No</td>
	            <td>25</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/ServiceObjects/REST/LinkType.Generated.cs" title="View Code for ServiceObjects/REST/LinkType.Generated.cs" target="_blank">ServiceObjects/REST/LinkType.Generated.cs</a></td>
	            <td>21</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>21</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/ServiceObjects/REST/RESTServiceObjects.Generated.cs" title="View Code for ServiceObjects/REST/RESTServiceObjects.Generated.cs" target="_blank">ServiceObjects/REST/RESTServiceObjects.Generated.cs</a></td>
	            <td>127</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>127</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/ServiceObjects/SOAP/SOAPServiceObjects.Generated.cs" title="View Code for ServiceObjects/SOAP/SOAPServiceObjects.Generated.cs" target="_blank">ServiceObjects/SOAP/SOAPServiceObjects.Generated.cs</a></td>
	            <td>80</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>80</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/SOAP.Generated.cs" title="View Code for SOAP.Generated.cs" target="_blank">SOAP.Generated.cs</a></td>
	            <td>242</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>242</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/Utils/InvalidParameterFaultReason.cs" title="View Code for Utils/InvalidParameterFaultReason.cs" target="_blank">Utils/InvalidParameterFaultReason.cs</a></td>
	            <td>13</td>
	            <td>No</td>
	            <td>13</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/Utils/RESTUrlUtil.cs" title="View Code for Utils/RESTUrlUtil.cs" target="_blank">Utils/RESTUrlUtil.cs</a></td>
	            <td>24</td>
	            <td>No</td>
	            <td>24</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/Utils/RESTUrlUtil.Generated.cs" title="View Code for Utils/RESTUrlUtil.Generated.cs" target="_blank">Utils/RESTUrlUtil.Generated.cs</a></td>
	            <td>67</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>67</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/Utils/ServiceFault.cs" title="View Code for Utils/ServiceFault.cs" target="_blank">Utils/ServiceFault.cs</a></td>
	            <td>12</td>
	            <td>No</td>
	            <td>12</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Service</td>
	            <td><a href="ViewCode.aspx?Path=Service/Utils/ServiceUtil.cs" title="View Code for Utils/ServiceUtil.cs" target="_blank">Utils/ServiceUtil.cs</a></td>
	            <td>31</td>
	            <td>No</td>
	            <td>31</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Courses/Default.aspx" title="View Code for Courses/Default.aspx" target="_blank">Courses/Default.aspx</a></td>
	            <td>6</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>6</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Courses/Default.aspx.cs" title="View Code for Courses/Default.aspx.cs" target="_blank">Courses/Default.aspx.cs</a></td>
	            <td>40</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>40</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Courses/Edit.aspx" title="View Code for Courses/Edit.aspx" target="_blank">Courses/Edit.aspx</a></td>
	            <td>5</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>5</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Courses/Edit.aspx.cs" title="View Code for Courses/Edit.aspx.cs" target="_blank">Courses/Edit.aspx.cs</a></td>
	            <td>36</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>36</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Default.aspx" title="View Code for Default.aspx" target="_blank">Default.aspx</a></td>
	            <td>25</td>
	            <td>No</td>
	            <td>25</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Default.aspx.cs" title="View Code for Default.aspx.cs" target="_blank">Default.aspx.cs</a></td>
	            <td>15</td>
	            <td>No</td>
	            <td>15</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Default.aspx.designer.cs" title="View Code for Default.aspx.designer.cs" target="_blank">Default.aspx.designer.cs</a></td>
	            <td>6</td>
	            <td>No</td>
	            <td>6</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Enrollments/Default.aspx" title="View Code for Enrollments/Default.aspx" target="_blank">Enrollments/Default.aspx</a></td>
	            <td>6</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>6</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Enrollments/Default.aspx.cs" title="View Code for Enrollments/Default.aspx.cs" target="_blank">Enrollments/Default.aspx.cs</a></td>
	            <td>40</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>40</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Enrollments/Edit.aspx" title="View Code for Enrollments/Edit.aspx" target="_blank">Enrollments/Edit.aspx</a></td>
	            <td>5</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>5</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Enrollments/Edit.aspx.cs" title="View Code for Enrollments/Edit.aspx.cs" target="_blank">Enrollments/Edit.aspx.cs</a></td>
	            <td>36</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>36</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Main.Master.cs" title="View Code for Main.Master.cs" target="_blank">Main.Master.cs</a></td>
	            <td>16</td>
	            <td>No</td>
	            <td>16</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Main.Master.designer.cs" title="View Code for Main.Master.designer.cs" target="_blank">Main.Master.designer.cs</a></td>
	            <td>6</td>
	            <td>No</td>
	            <td>6</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Majors/Default.aspx" title="View Code for Majors/Default.aspx" target="_blank">Majors/Default.aspx</a></td>
	            <td>6</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>6</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Majors/Default.aspx.cs" title="View Code for Majors/Default.aspx.cs" target="_blank">Majors/Default.aspx.cs</a></td>
	            <td>40</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>40</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Majors/Edit.aspx" title="View Code for Majors/Edit.aspx" target="_blank">Majors/Edit.aspx</a></td>
	            <td>5</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>5</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Majors/Edit.aspx.cs" title="View Code for Majors/Edit.aspx.cs" target="_blank">Majors/Edit.aspx.cs</a></td>
	            <td>36</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>36</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Semesters/Default.aspx" title="View Code for Semesters/Default.aspx" target="_blank">Semesters/Default.aspx</a></td>
	            <td>6</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>6</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Semesters/Default.aspx.cs" title="View Code for Semesters/Default.aspx.cs" target="_blank">Semesters/Default.aspx.cs</a></td>
	            <td>40</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>40</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Semesters/Edit.aspx" title="View Code for Semesters/Edit.aspx" target="_blank">Semesters/Edit.aspx</a></td>
	            <td>5</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>5</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Semesters/Edit.aspx.cs" title="View Code for Semesters/Edit.aspx.cs" target="_blank">Semesters/Edit.aspx.cs</a></td>
	            <td>36</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>36</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Service/Documentation/Methods.aspx" title="View Code for Service/Documentation/Methods.aspx" target="_blank">Service/Documentation/Methods.aspx</a></td>
	            <td>1,527</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>1,527</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Service/Documentation/Types.aspx" title="View Code for Service/Documentation/Types.aspx" target="_blank">Service/Documentation/Types.aspx</a></td>
	            <td>259</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>259</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Students/Default.aspx" title="View Code for Students/Default.aspx" target="_blank">Students/Default.aspx</a></td>
	            <td>6</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>6</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Students/Default.aspx.cs" title="View Code for Students/Default.aspx.cs" target="_blank">Students/Default.aspx.cs</a></td>
	            <td>40</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>40</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Students/Edit.aspx" title="View Code for Students/Edit.aspx" target="_blank">Students/Edit.aspx</a></td>
	            <td>5</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>5</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Students/Edit.aspx.cs" title="View Code for Students/Edit.aspx.cs" target="_blank">Students/Edit.aspx.cs</a></td>
	            <td>36</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>36</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Teachers/Default.aspx" title="View Code for Teachers/Default.aspx" target="_blank">Teachers/Default.aspx</a></td>
	            <td>6</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>6</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Teachers/Default.aspx.cs" title="View Code for Teachers/Default.aspx.cs" target="_blank">Teachers/Default.aspx.cs</a></td>
	            <td>40</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>40</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Teachers/Edit.aspx" title="View Code for Teachers/Edit.aspx" target="_blank">Teachers/Edit.aspx</a></td>
	            <td>5</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>5</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/Teachers/Edit.aspx.cs" title="View Code for Teachers/Edit.aspx.cs" target="_blank">Teachers/Edit.aspx.cs</a></td>
	            <td>36</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>36</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/BasePage.cs" title="View Code for WebControls/BasePage.cs" target="_blank">WebControls/BasePage.cs</a></td>
	            <td>18</td>
	            <td>No</td>
	            <td>18</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/BaseUserControl.cs" title="View Code for WebControls/BaseUserControl.cs" target="_blank">WebControls/BaseUserControl.cs</a></td>
	            <td>14</td>
	            <td>No</td>
	            <td>14</td>
	            <td>0</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/CourseList.ascx" title="View Code for WebControls/CourseList.ascx" target="_blank">WebControls/CourseList.ascx</a></td>
	            <td>18</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>18</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/CourseList.ascx.cs" title="View Code for WebControls/CourseList.ascx.cs" target="_blank">WebControls/CourseList.ascx.cs</a></td>
	            <td>64</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>64</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditCourse.ascx" title="View Code for WebControls/EditCourse.ascx" target="_blank">WebControls/EditCourse.ascx</a></td>
	            <td>73</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>73</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditCourse.ascx.cs" title="View Code for WebControls/EditCourse.ascx.cs" target="_blank">WebControls/EditCourse.ascx.cs</a></td>
	            <td>82</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>82</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditEnrollment.ascx" title="View Code for WebControls/EditEnrollment.ascx" target="_blank">WebControls/EditEnrollment.ascx</a></td>
	            <td>38</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>38</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditEnrollment.ascx.cs" title="View Code for WebControls/EditEnrollment.ascx.cs" target="_blank">WebControls/EditEnrollment.ascx.cs</a></td>
	            <td>70</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>70</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditMajor.ascx" title="View Code for WebControls/EditMajor.ascx" target="_blank">WebControls/EditMajor.ascx</a></td>
	            <td>23</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>23</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditMajor.ascx.cs" title="View Code for WebControls/EditMajor.ascx.cs" target="_blank">WebControls/EditMajor.ascx.cs</a></td>
	            <td>61</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>61</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditSemester.ascx" title="View Code for WebControls/EditSemester.ascx" target="_blank">WebControls/EditSemester.ascx</a></td>
	            <td>43</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>43</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditSemester.ascx.cs" title="View Code for WebControls/EditSemester.ascx.cs" target="_blank">WebControls/EditSemester.ascx.cs</a></td>
	            <td>67</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>67</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditStudent.ascx" title="View Code for WebControls/EditStudent.ascx" target="_blank">WebControls/EditStudent.ascx</a></td>
	            <td>69</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>69</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditStudent.ascx.cs" title="View Code for WebControls/EditStudent.ascx.cs" target="_blank">WebControls/EditStudent.ascx.cs</a></td>
	            <td>76</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>76</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditTeacher.ascx" title="View Code for WebControls/EditTeacher.ascx" target="_blank">WebControls/EditTeacher.ascx</a></td>
	            <td>56</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>56</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EditTeacher.ascx.cs" title="View Code for WebControls/EditTeacher.ascx.cs" target="_blank">WebControls/EditTeacher.ascx.cs</a></td>
	            <td>70</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>70</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EnrollmentList.ascx" title="View Code for WebControls/EnrollmentList.ascx" target="_blank">WebControls/EnrollmentList.ascx</a></td>
	            <td>13</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>13</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/EnrollmentList.ascx.cs" title="View Code for WebControls/EnrollmentList.ascx.cs" target="_blank">WebControls/EnrollmentList.ascx.cs</a></td>
	            <td>61</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>61</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/MajorList.ascx" title="View Code for WebControls/MajorList.ascx" target="_blank">WebControls/MajorList.ascx</a></td>
	            <td>12</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>12</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/MajorList.ascx.cs" title="View Code for WebControls/MajorList.ascx.cs" target="_blank">WebControls/MajorList.ascx.cs</a></td>
	            <td>60</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>60</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/SemesterList.ascx" title="View Code for WebControls/SemesterList.ascx" target="_blank">WebControls/SemesterList.ascx</a></td>
	            <td>14</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>14</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/SemesterList.ascx.cs" title="View Code for WebControls/SemesterList.ascx.cs" target="_blank">WebControls/SemesterList.ascx.cs</a></td>
	            <td>62</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>62</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/StudentList.ascx" title="View Code for WebControls/StudentList.ascx" target="_blank">WebControls/StudentList.ascx</a></td>
	            <td>16</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>16</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/StudentList.ascx.cs" title="View Code for WebControls/StudentList.ascx.cs" target="_blank">WebControls/StudentList.ascx.cs</a></td>
	            <td>64</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>64</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/TeacherList.ascx" title="View Code for WebControls/TeacherList.ascx" target="_blank">WebControls/TeacherList.ascx</a></td>
	            <td>15</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>15</td>
            <tr/>
            <tr>
	            <td scope="row">Web</td>
	            <td><a href="ViewCode.aspx?Path=Web/WebControls/TeacherList.ascx.cs" title="View Code for WebControls/TeacherList.ascx.cs" target="_blank">WebControls/TeacherList.ascx.cs</a></td>
	            <td>63</td>
	            <td>Yes</td>
	            <td>0</td>
	            <td>63</td>
            <tr/>
        </tbody>
        <tfoot>
            <tr>
	            <td></td>
	            <td>Total Line Count:</td>
	            <td>7,224</td>
	            <td></td>
	            <td>455</td>
	            <td>6,769</td>
            <tr/>
            <tr>
	            <td></td>
	            <td>Percent of Total:</td>
	            <td></td>
	            <td></td>
	            <td>6.30%</td>
	            <td>93.70%</td>
            <tr/>
        </tfoot>
    </table>
</asp:Content>