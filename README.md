# e-Commerce
e-Commerce [Asp.Net Core MVC 6 Multi Layer Project]


<p> .Net Core sdk version </p>
<code> 1.0.0-preview2-003121 </code> 
<a href="https://github.com/dotnet/core/blob/master/release-notes/download-archives/1.0-preview2-download.md"> download </a>

<h4> Project Directory </h4>
<br />
<pre> 
	e-Commerce[Solution]
		|
		|
		|------src
		|	|	
		|	|---Commerce.Contracts
		|	|
		|	|---Commerce.DAL
		|	|
		|	|---Commerce.Model
		|	|	
		|	|---Commerce.Web
		|
		|		
		|------test
			|
			|---Commerce.DAL.Test
			|	
			|---Commerce.Web.Test
				
</pre>

<h4> Edit database connection string in appsettings.json </h4>
<code> 
	"DefaultConnection": "server=localhost;userid=root;pwd=[database password];port=[your port number];
	database=ExamService;sslmode=none;charset=utf8;" 
</code>
<br /> <b> Example :</b> <br />
<code> 
	"DefaultConnection": "server=localhost;userid=root;pwd=;port=3306;
	database=ExamService;sslmode=none;charset=utf8;" 
</code>

