<%@ Page Title="Service Types" MasterPageFile="~/Main.Master" Inherits="System.Web.UI.Page" Language="C#" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <div class="ServiceBlock">
    <h3>Course<a name="Course"> </a></h3>
    <p>Maps to the Course table in the database.</p>
    <div class="TypeProperties">
      <table summary="Table describing the properties for Course.">
        <thead>
          <tr>
            <th scope="col">Property</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>ID</td>
            <td>int</td>
            <td>Maps to the ID column.</td>
          </tr>
          <tr>
            <td>Name</td>
            <td>string</td>
            <td>Maps to the Name column.</td>
          </tr>
          <tr>
            <td>Number</td>
            <td>string</td>
            <td>Maps to the Number column.</td>
          </tr>
          <tr>
            <td>SemesterID</td>
            <td>int</td>
            <td>Maps to the SemesterID column.</td>
          </tr>
          <tr>
            <td>Status</td>
            <td>string</td>
            <td>Maps to the Status column.</td>
          </tr>
          <tr>
            <td>TeacherID</td>
            <td>int</td>
            <td>Maps to the TeacherID column.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Course Collection<a name="Course-Collection"> </a></h3>
    <p>A collection of <a href="#Course">Courses</a>.</p>
  </div>
  <div class="ServiceBlock">
    <h3>Enrollment<a name="Enrollment"> </a></h3>
    <p>Maps to the Enrollment table in the database.</p>
    <div class="TypeProperties">
      <table summary="Table describing the properties for Enrollment.">
        <thead>
          <tr>
            <th scope="col">Property</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>ID</td>
            <td>int</td>
            <td>Maps to the ID column.</td>
          </tr>
          <tr>
            <td>CourseID</td>
            <td>int</td>
            <td>Maps to the CourseID column.</td>
          </tr>
          <tr>
            <td>StudentID</td>
            <td>int</td>
            <td>Maps to the StudentID column.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Enrollment Collection<a name="Enrollment-Collection"> </a></h3>
    <p>A collection of <a href="#Enrollment">Enrollments</a>.</p>
  </div>
  <div class="ServiceBlock">
    <h3>Major<a name="Major"> </a></h3>
    <p>Maps to the Major table in the database.</p>
    <div class="TypeProperties">
      <table summary="Table describing the properties for Major.">
        <thead>
          <tr>
            <th scope="col">Property</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>ID</td>
            <td>int</td>
            <td>Maps to the ID column.</td>
          </tr>
          <tr>
            <td>Name</td>
            <td>string</td>
            <td>Maps to the Name column.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Major Collection<a name="Major-Collection"> </a></h3>
    <p>A collection of <a href="#Major">Majors</a>.</p>
  </div>
  <div class="ServiceBlock">
    <h3>Semester<a name="Semester"> </a></h3>
    <p>Maps to the Semester table in the database.</p>
    <div class="TypeProperties">
      <table summary="Table describing the properties for Semester.">
        <thead>
          <tr>
            <th scope="col">Property</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>ID</td>
            <td>int</td>
            <td>Maps to the ID column.</td>
          </tr>
          <tr>
            <td>End</td>
            <td>DateTime</td>
            <td>Maps to the End column.</td>
          </tr>
          <tr>
            <td>Begin</td>
            <td>DateTime</td>
            <td>Maps to the Begin column.</td>
          </tr>
          <tr>
            <td>Name</td>
            <td>string</td>
            <td>Maps to the Name column.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Semester Collection<a name="Semester-Collection"> </a></h3>
    <p>A collection of <a href="#Semester">Semesters</a>.</p>
  </div>
  <div class="ServiceBlock">
    <h3>Student<a name="Student"> </a></h3>
    <p>Maps to the Student table in the database.</p>
    <div class="TypeProperties">
      <table summary="Table describing the properties for Student.">
        <thead>
          <tr>
            <th scope="col">Property</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>ID</td>
            <td>int</td>
            <td>Maps to the ID column.</td>
          </tr>
          <tr>
            <td>SSN</td>
            <td>string</td>
            <td>Maps to the SSN column.</td>
          </tr>
          <tr>
            <td>Active</td>
            <td>bool</td>
            <td>Maps to the Active column.</td>
          </tr>
          <tr>
            <td>FirstName</td>
            <td>string</td>
            <td>Maps to the FirstName column.</td>
          </tr>
          <tr>
            <td>LastName</td>
            <td>string</td>
            <td>Maps to the LastName column.</td>
          </tr>
          <tr>
            <td>MajorID</td>
            <td>int</td>
            <td>Maps to the MajorID column.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Student Collection<a name="Student-Collection"> </a></h3>
    <p>A collection of <a href="#Student">Students</a>.</p>
  </div>
  <div class="ServiceBlock">
    <h3>Teacher<a name="Teacher"> </a></h3>
    <p>Maps to the Teacher table in the database.</p>
    <div class="TypeProperties">
      <table summary="Table describing the properties for Teacher.">
        <thead>
          <tr>
            <th scope="col">Property</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>ID</td>
            <td>int</td>
            <td>Maps to the ID column.</td>
          </tr>
          <tr>
            <td>SSN</td>
            <td>string</td>
            <td>Maps to the SSN column.</td>
          </tr>
          <tr>
            <td>Active</td>
            <td>bool</td>
            <td>Maps to the Active column.</td>
          </tr>
          <tr>
            <td>FirstName</td>
            <td>string</td>
            <td>Maps to the FirstName column.</td>
          </tr>
          <tr>
            <td>LastName</td>
            <td>string</td>
            <td>Maps to the LastName column.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Teacher Collection<a name="Teacher-Collection"> </a></h3>
    <p>A collection of <a href="#Teacher">Teachers</a>.</p>
  </div>

<script type="text/javascript">$(document).ready(function () { $(".TypeProperties table th:nth-child(2)").addClass("SecondColumn"); });</script></asp:Content>