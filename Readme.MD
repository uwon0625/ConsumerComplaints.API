This is an ASP.NET 5 WEB API with Consumer Complaints data(as of 09/23/2016) from http://catalog.data.gov/dataset/consumer-complaint-database#topic=consumer_navigation.
<br/>
<br/>
<b>Technology used:</b><br/>
Entity Framwork v6.1 Data First<br/>
Sql Server 2016 Developer Edition (local installation)<br/>
Unity IoC(WEB API)<br/>
Moq(Unit testing)<br/>
Async/Await pattern(and sync calls)<br/>
Facebook and Google Auth Provider<br/>

<br/>
<b>Main features:</b><br/>
1. GET api/Complaints: List 10 of the Complaints records, see details below;<br/>
2. GET api/Complaints/{id}: List individual Complaint record by Id;<br/>
3. PUT api/Complaints/{id}: with Complaint Data;<br/>
4. POST api/Complaint:  with Complaint Data;<br/>
5. DELETE api/Complaints/{id}: delete a complaint<br/>
6. GET api/TopComplaints: List 10 of the grouped(by Company Name) Complaints records, will do paging later;<br/>
7. GET api/TopComplaints/{zip}: List 10 of the grouped(by Company Name) Complaints records filtered by the zip code, will do paging later;<br/>
8. Account and Auth APIs... (br/>

<b>GET api/Complaints routing examples: api/Complaints/{CompanyName}/{zip}/{pageSize}/{pageNumber}/{orderBy}</b><br/>
GET api/Complaints<br/>
GET api/Complaints/Discover<br/>
GET api/Complaints/Discover/334XX<br/>
GET api/Complaints/Discover/334XX/3<br/>
GET api/Complaints/Discover/334XX/3/3<br/>
GET api/Complaints/Discover/334XX/3/3/-DateReceived<br/>

<br/>
<b>Note:</b><br/>
1. Some of the functionalities are tested(Unit test, manual test, integration test) while others to be tested.<br/>
2. The Complaint Id(last column) is rebased when migration with Entity Framework v6.<br/>
