#CodeGenerator v1.7.2.0
**Develop stable, robust and highly versatile software, faster!**

Countless hours have been spent by developers writing the same code over and over and over again. It's time to stop this repetitive coding and bring your team to the next level of efficiency.

That's where CodeGenerator comes in. This tool allows you and your team to get the nuts and bolts of any project up and running amazingly fast. The backbone of CodeGenerator relies on technologies that your team probably already knows - XML and XSLT. You design an XSL Template _once_ and CodeGenerator handles the rest. Once you get going you'll be pleasantly surprised by just how much code you can automate! And what's more - you can generate code in any language and for any platform! It's all up to you to decide how you want to architect your templates for the most robust and fool-proof codebase you've ever used.

CodeGenerator is truly going to change the way you write code - for the better. We've used this tool on private projects for years and decided to make it available to everyone.

##Free for Personal and Non-profit Use
CodeGenerator is free for personal and non-profit use. 

##Open Source
CodeGenerator has been released on GitHub as open-source software! We hope to get the open source community's input and help to make this product even better.

##Installation
CodeGenerator is currently available as a Windows installer. The latest version is v1.7.2.0 and [it can be downloaded here](https://www.quantumconceptscorp.com/Products/CodeGenerator.aspx).

##Quick Start Guide
The first step is to understand how CodeGenerator works. Basically, CodeGenerator is a tool that reads a database schema and outputs generated code based on that schema. The output is completely up to you - C#, Java, HTML, text, XML, etc. - you can created templates to generate anything you you can think of.

###Supported Databases
* SQL Server 2005+
* MySQL 5+
* (May work with older versions depending on your schema.)

###Supported Languages/Frameworks
* Templates can be written to support virtually any language or framework.

###Supported Operating Systems
* Windows XP and above.

###Templates
A number of templates are included to get you started quick:

###C♯
####Data Model/Access Templates:

* **DataObjects.xslt** - The base data objects (model) which are defined by your database schema.
* **Enumerations.xslt** - Generated enumerations for the data model as defined in the project.
* **DataAccess-EF.xslt** - Classes which extend the base data objects and add database-access functionality using the Entity Framework.
* **DataAccess-LINQ.xslt** - Classes which extend the base data objects and add database-access functionality using the LINQ-to-SQL framework.
* **Cache.xslt** - Classes which cache certain data objects (as defined in the CodeGenerator project) for quick access.
* **Logic.xslt** - Classes which store business logic and functionality to traverse the object graph by foreign key and unique index. Also allows you to specify custom APIs.

####Web Service Templates

* **BaseServiceObjects.xslt** - Extends the base data objects for use as return values in web service calls.

#####REST Templates

* **RESTServiceObjects.xslt** - Extends the base service objects and adds functionality specific to REST.
* **RESTInterface.xslt** - Interface definitions for all generated REST endpoints (mark tables, foreign keys and unique indices with the "ServiceExposed" attribute).
* **RESTImplementation.xslt** - Implements the REST interface to return data.
* **RESTServiceLinkType.xslt** - Defines "links" between objects for easy querying of additional data.
* **RESTUrlUtil.xslt** - Provides a standard way to build URLs to access resources via REST.

#####SOAP Templates

* **SOAPServiceObjects.xslt** - Extends the base service objects and adds functionality specific to SOAP.
* **SOAPInterface.xslt** - interface definitions for all generated SOAP methods (mark tables, foreign keys and unique indices with the "ServiceExposed" attribute).
* **SOAPImplementation.xslt** - Implements the SOAP interface to return data.

#####Serice Documentation

* **ServiceDocumentation-Common.xslt** - Shared functionality for generating service documentation.
* **ServiceDocumentation-HTML-Methods.xslt** - Generates HTML documentation for service methods.
* **ServiceDocumentation-HTML-Types.xslt** - Generates HTML documentation for service types.
* **ServiceChanges.xslt** - This templates is used outside of CodeGenerator to generate a diff between two versions of the service.
