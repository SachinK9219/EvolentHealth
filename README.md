# EvolentHealth
Web API

<b>How to run application ?</b>
1) Install IIS server on your system.
2) Deploy publish folder into IIS server.
3) Add Application name EvolentAPI (already configure for calling api) 
4) Open browser and type http://localhost/EvolentAPI/api/contacts/GetAllContact
4) Used Basic Authentication
username : admin
password : admin@123

<b>Datbase used :</b>
1) SQL Server -  App_Data/contact.bak<br>
2) Txt File (default)-  App_Data/sample.txt

Location:App_Data
1) SQL Server : Contack.bak <br>
2)Text File : sample.txt

There are two folder
1. Application
2. Publish

Based on DpendencyInjection we can create object and used database.

Logger file created
Location : "C:\\EvolentHealth\\ContactAPIError.log"

<b>Configuration to use SQL Server DB</b>
1) Open App_start > UnityConfig.cs
2) Change ContactDataAccessTxt to ContactDataAccessSQL in below line<br>
   container.RegisterType<IContact, ContactDataAccessTxt>();

<b>API :</b><br>
<b>To get all contacts</b><br>
<b>Method :</b> GET<br>
<b>URL :</b> api/contacts/GetAllContact<br>
<b>Responce:</b> {<br>
        "ID": "1",
        "FirstName": "rushi",
        "LastName": "k",
        "Email": "rushi@gmail.com",
        "PhoneNumber": "3325698741",
        "Status": true
    },

<b>To Insert New contact</b><br>
<b>Method :</b> POST<br>
<b>URL :</b> api/contacts/InsertContact<br>
<b>Request: </b> {<br>
        "ID": "25",
        "FirstName": "Kedar",
        "LastName": "P",
        "Email": "9028293656",
        "PhoneNumber": "Kiran@gmail.com",
        "Status": true
    }
<br><b>Reponce:</b>{<br>
    "Details": null,
    "Message": "Data Inserted Successfully",
    "Status": "Success"
}


<b>To update existing Contact</b><br>
<b>Method :</b> POST<br>
<b>URL :</b> api/contacts/UpdateContact<br>
<b>Request:</b> {<br>
        "ID": "25",
        "FirstName": "Kiran",
        "LastName": "P",
        "Email": "9028293656",
        "PhoneNumber": "Kiran@gmail.com",
        "Status": true
    }
<br><b>Respnce:</b><br>
{
    "Details": null,
    "Message": "Data Updated Successfully",
    "Status": "Success"
}


<b><br>To Delete Contact</b><br>
<b>Method :</b> Delete<br>
<b>URL :</b> api/Contact/DeleteContact?id=25<br>
<b>Respnce:</b><br>
{
    "Details": null,
    "Message": "Data Deleted Successfully",
    "Status": "Success"
}



<b>Web Application </b>

How to run application ?
1) Install IIS server on your system.
2) Deploy publish folder into IIS server.
3) Add Application name EvolentUI
4) Open browser and type http://localhost/EvolentUI

<b>There are two folder</b>
1. Application
2. Publish

<b>Logger file Location Location:</b> "C:\\EvolentHealth\\ContactError.log"

I am using MVC architectural and dependency injection.













