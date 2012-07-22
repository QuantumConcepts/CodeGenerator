<%@ Page Title="Service Methods" MasterPageFile="~/Main.Master" Inherits="System.Web.UI.Page" Language="C#" %>

<asp:Content runat="server" ContentPlaceHolderID="content">
  <div class="ServiceBlock">
    <h3>All Courses</h3>
    <p>Returns a paginated representation of all of the Courses.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Courses.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Courses/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCourses</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Course-Collection">Course Collection</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Courses.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Courses</h3>
    <p>Returns how many Courses exist.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Courses.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Courses/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Courses</h3>
    <p>Returns how many pages of data exist for all Courses.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Courses.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Courses/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Course</h3>
    <p>Returns a representation of a particular Course based on its identifier.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Course.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Course/{id}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCourseByID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Course">Course</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Course.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>id</td>
            <td>int</td>
            <td>The primary key identifier of the Course instance to retrieve.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Courses by Semester</h3>
    <p>Returns a paginated representation of all of the Courses based on the primary key of the related Semester.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Courses by Semester.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semester/{semesterID}/Courses/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesBySemesterID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Course-Collection">Course Collection,</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Courses by Semester.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>semesterID</td>
            <td>int</td>
            <td>The foreign key identifier of the Semester instance from which to retrieve the child Courses.</td>
          </tr>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Courses by Semester</h3>
    <p>Returns how many Courses exist based on the primary key of the related Semester.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Courses by Semester.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semester/{semesterID}/Courses/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesBySemesterIDCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Count of All Courses by Semester.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>semesterID</td>
            <td>int</td>
            <td>The foreign key identifier of the Semester instance from which to retrieve the child Courses.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Courses by Semester</h3>
    <p>Returns how many pages of data exist for all Courses based on the primary key of the related Semester.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Courses by Semester.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semester/{semesterID}/Courses/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesBySemesterIDPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Page Count of All Courses by Semester.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>semesterID</td>
            <td>int</td>
            <td>The foreign key identifier of the Semester instance from which to retrieve the child Courses.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Courses by Teacher</h3>
    <p>Returns a paginated representation of all of the Courses based on the primary key of the related Teacher.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Courses by Teacher.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teacher/{teacherID}/Courses/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesByTeacherID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Course-Collection">Course Collection,</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Courses by Teacher.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>teacherID</td>
            <td>int</td>
            <td>The foreign key identifier of the Teacher instance from which to retrieve the child Courses.</td>
          </tr>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Courses by Teacher</h3>
    <p>Returns how many Courses exist based on the primary key of the related Teacher.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Courses by Teacher.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teacher/{teacherID}/Courses/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesByTeacherIDCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Count of All Courses by Teacher.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>teacherID</td>
            <td>int</td>
            <td>The foreign key identifier of the Teacher instance from which to retrieve the child Courses.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Courses by Teacher</h3>
    <p>Returns how many pages of data exist for all Courses based on the primary key of the related Teacher.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Courses by Teacher.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teacher/{teacherID}/Courses/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetCoursesByTeacherIDPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Page Count of All Courses by Teacher.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>teacherID</td>
            <td>int</td>
            <td>The foreign key identifier of the Teacher instance from which to retrieve the child Courses.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Enrollments</h3>
    <p>Returns a paginated representation of all of the Enrollments.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Enrollments.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Enrollments/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollments</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Enrollment-Collection">Enrollment Collection</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Enrollments.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Enrollments</h3>
    <p>Returns how many Enrollments exist.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Enrollments.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Enrollments/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Enrollments</h3>
    <p>Returns how many pages of data exist for all Enrollments.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Enrollments.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Enrollments/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Enrollment</h3>
    <p>Returns a representation of a particular Enrollment based on its identifier.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Enrollment.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Enrollment/{id}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentByID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Enrollment">Enrollment</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Enrollment.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>id</td>
            <td>int</td>
            <td>The primary key identifier of the Enrollment instance to retrieve.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Enrollments by Student</h3>
    <p>Returns a paginated representation of all of the Enrollments based on the primary key of the related Student.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Enrollments by Student.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Student/{studentID}/Enrollments/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsByStudentID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Enrollment-Collection">Enrollment Collection,</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Enrollments by Student.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>studentID</td>
            <td>int</td>
            <td>The foreign key identifier of the Student instance from which to retrieve the child Enrollments.</td>
          </tr>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Enrollments by Student</h3>
    <p>Returns how many Enrollments exist based on the primary key of the related Student.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Enrollments by Student.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Student/{studentID}/Enrollments/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsByStudentIDCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Count of All Enrollments by Student.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>studentID</td>
            <td>int</td>
            <td>The foreign key identifier of the Student instance from which to retrieve the child Enrollments.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Enrollments by Student</h3>
    <p>Returns how many pages of data exist for all Enrollments based on the primary key of the related Student.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Enrollments by Student.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Student/{studentID}/Enrollments/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsByStudentIDPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Page Count of All Enrollments by Student.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>studentID</td>
            <td>int</td>
            <td>The foreign key identifier of the Student instance from which to retrieve the child Enrollments.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Enrollments by Course</h3>
    <p>Returns a paginated representation of all of the Enrollments based on the primary key of the related Course.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Enrollments by Course.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Course/{courseID}/Enrollments/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsByCourseID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Enrollment-Collection">Enrollment Collection,</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Enrollments by Course.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>courseID</td>
            <td>int</td>
            <td>The foreign key identifier of the Course instance from which to retrieve the child Enrollments.</td>
          </tr>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Enrollments by Course</h3>
    <p>Returns how many Enrollments exist based on the primary key of the related Course.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Enrollments by Course.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Course/{courseID}/Enrollments/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsByCourseIDCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Count of All Enrollments by Course.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>courseID</td>
            <td>int</td>
            <td>The foreign key identifier of the Course instance from which to retrieve the child Enrollments.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Enrollments by Course</h3>
    <p>Returns how many pages of data exist for all Enrollments based on the primary key of the related Course.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Enrollments by Course.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Course/{courseID}/Enrollments/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetEnrollmentsByCourseIDPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Page Count of All Enrollments by Course.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>courseID</td>
            <td>int</td>
            <td>The foreign key identifier of the Course instance from which to retrieve the child Enrollments.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Majors</h3>
    <p>Returns a paginated representation of all of the Majors.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Majors.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Majors/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetMajors</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Major-Collection">Major Collection</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Majors.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Majors</h3>
    <p>Returns how many Majors exist.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Majors.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Majors/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetMajorsCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Majors</h3>
    <p>Returns how many pages of data exist for all Majors.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Majors.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Majors/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetMajorsPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Major</h3>
    <p>Returns a representation of a particular Major based on its identifier.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Major.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Major/{id}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetMajorByID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Major">Major</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Major.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>id</td>
            <td>int</td>
            <td>The primary key identifier of the Major instance to retrieve.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Semesters</h3>
    <p>Returns a paginated representation of all of the Semesters.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Semesters.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semesters/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetSemesters</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Semester-Collection">Semester Collection</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Semesters.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Semesters</h3>
    <p>Returns how many Semesters exist.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Semesters.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semesters/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetSemestersCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Semesters</h3>
    <p>Returns how many pages of data exist for all Semesters.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Semesters.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semesters/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetSemestersPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Semester</h3>
    <p>Returns a representation of a particular Semester based on its identifier.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Semester.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Semester/{id}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetSemesterByID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Semester">Semester</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Semester.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>id</td>
            <td>int</td>
            <td>The primary key identifier of the Semester instance to retrieve.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Students</h3>
    <p>Returns a paginated representation of all of the Students.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Students.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Students/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudents</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Student-Collection">Student Collection</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Students.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Students</h3>
    <p>Returns how many Students exist.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Students.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Students/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudentsCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Students</h3>
    <p>Returns how many pages of data exist for all Students.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Students.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Students/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudentsPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Student</h3>
    <p>Returns a representation of a particular Student based on its identifier.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Student.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Student/{id}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudentByID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Student">Student</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Student.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>id</td>
            <td>int</td>
            <td>The primary key identifier of the Student instance to retrieve.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Students by Major</h3>
    <p>Returns a paginated representation of all of the Students based on the primary key of the related Major.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Students by Major.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Major/{majorID}/Students/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudentsByMajorID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Student-Collection">Student Collection,</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Students by Major.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>majorID</td>
            <td>int</td>
            <td>The foreign key identifier of the Major instance from which to retrieve the child Students.</td>
          </tr>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Students by Major</h3>
    <p>Returns how many Students exist based on the primary key of the related Major.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Students by Major.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Major/{majorID}/Students/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudentsByMajorIDCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Count of All Students by Major.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>majorID</td>
            <td>int</td>
            <td>The foreign key identifier of the Major instance from which to retrieve the child Students.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Students by Major</h3>
    <p>Returns how many pages of data exist for all Students based on the primary key of the related Major.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Students by Major.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Major/{majorID}/Students/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetStudentsByMajorIDPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Page Count of All Students by Major.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>majorID</td>
            <td>int</td>
            <td>The foreign key identifier of the Major instance from which to retrieve the child Students.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>All Teachers</h3>
    <p>Returns a paginated representation of all of the Teachers.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of All Teachers.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teachers/{page}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetTeachers</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Teacher-Collection">Teacher Collection</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for All Teachers.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>page</td>
            <td>int</td>
            <td>The index of the page of data to retrieve. A value of 1 indicates the first page of data.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Count of All Teachers</h3>
    <p>Returns how many Teachers exist.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Count of All Teachers.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teachers/Count</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetTeachersCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Page Count of All Teachers</h3>
    <p>Returns how many pages of data exist for all Teachers.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Page Count of All Teachers.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teachers/PageCount</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetTeachersPageCount</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td>int</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
  <div class="ServiceBlock">
    <h3>Teacher</h3>
    <p>Returns a representation of a particular Teacher based on its identifier.</p>
    <div class="MethodTable">
      <table summary="Table describing URIs, HTTP Verbs, Methods, and Output of Teacher.">
        <tbody>
          <tr>
            <th scope="row">REST URI:</th>
            <td>/Teacher/{id}</td>
          </tr>
          <tr>
            <th scope="row">REST Verb:</th>
            <td>GET</td>
          </tr>
          <tr>
            <th scope="row">SOAP Method:</th>
            <td>GetTeacherByID</td>
          </tr>
          <tr>
            <th scope="row">Output:</th>
            <td><a href="Types.aspx#Teacher">Teacher</a></td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="MethodParameters">
      <table summary="Table describing the parameters for Teacher.">
        <thead>
          <tr>
            <th scope="col">Parameter</th>
            <th scope="col">Type</th>
            <th scope="col">Description</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>id</td>
            <td>int</td>
            <td>The primary key identifier of the Teacher instance to retrieve.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div><script type="text/javascript">$(document).ready(function () { $(".MethodParameters table th:nth-child(2)").addClass("SecondColumn"); });</script></asp:Content>