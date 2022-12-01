<h1>Test Api</h1>
<p>Use this Rest API startup template for begin your API automation. This template integrated with JWT(Json Web Token) as authentication.</p>
<h2>Requirements</h2>
<ul>
<li>Visual Studio 2019 or higher</li>
<li>Microsoft SQL Server 2012 or higher</li>
<li>Git CLI</li>
</ul>
<h2>Patterns</h2>
<ul>
<li>OOP</li>
<li>Dependancey Injection</li>
</ul>
<h2>Get started</h2>
<ul>
<li>Open your Git Bash CLI</li>
<li>git clone https://github.com/duke9001/TestApi.git</li>
<li>Open Microsoft SQL Server and create Database</li>
<li>Double click on TestApi.sln</li>
<li>Open server exporer tab and create databse connection</li>
<li>Open appsettings.json</li>
<li>Replace DefaultConnection string with yout database connection string</li>
<li>Open package manager console and type update-datase and hit enter</li>
</ul>
<h2>List of API</h2>
 <table>		
     <tr>				
       <th>API Call</th>	
       <th>Action</th>
     </tr> 
     <tr>				
       <td>GET: api/Users</td>
       <td>List all users </td>
     </tr>  
  <tr>				
       <td>GET: api/Users/{id}</td>
       <td>Get user by ID</td>
     </tr>  
   <tr>				
       <td>PUT: api/Users/{id}</td>
       <td>Update user by ID</td>
     </tr>  
   <tr>				
       <td>POST: api/Users</td>
       <td>Insert user</td>
     </tr>  
   <tr>				
       <td>DELETE: api/Users/{id}</td>
       <td>Delete user by ID</td>
     </tr> 
  
  
   <tr>				
       <td>GET: api/Products</td>
       <td>List all Products</td>
     </tr>  
  <tr>				
       <td>GET: api/Products/{id}</td>
       <td>Get product by ID</td>
     </tr>  
   <tr>				
       <td>PUT: api/Products/{id}</td>
       <td>Update product by ID</td>
     </tr>  
   <tr>				
       <td>POST: api/Products</td>
       <td>Insert product</td>
     </tr>  
   <tr>				
       <td>DELETE: api/Products/{id}</td>
       <td>Delete product by ID</td>
     </tr> 
   <tr>				
       <td>POST: api/Token</td>
       <td>Get token by email and password</td>
     </tr> 
  
   </table>
<a href="test">Read full article</a>
