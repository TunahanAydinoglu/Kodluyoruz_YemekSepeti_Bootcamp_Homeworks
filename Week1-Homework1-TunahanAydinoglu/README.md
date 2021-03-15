# Singleton method için controller adı ProductsController
	Örnek Endpointleri : 
	
	GetProducts : Method:GET :  localhost:50312/api/products
	GetProductsById : Method:GET :  localhost:50312/api/products/8

	PostProduct : Method:POST :  localhost:50312/api/products
		body: {
   			 	"Id":11,
  			 	"Name":"Post Try",
   			 	"Price":12.11
			  }

	PutProduct : Method:PUT :  localhost:50312/api/products
		body: {
   			 	"Id":11,
  			 	"Name":"Put Try",
   			 	"Price":12.11
			  }	
	DeleteProductById : Method:DELETE :  localhost:50312/api/products/11	
	Options : Method:OPTIONS :  localhost:50312/api/products				  		  

# Dataların program kapatıldıntan sonrada gitmemesi için json dosya üzerinden işlemlerimi yaptım controller adı FileDatasController
	Örnek Endpointleri :

	GetProducts : Method:GET : localhost:50312/api/filedatas
	GetProductById : Method:GET :  localhost:50312/api/filedatas/12
	PostProducts : Method:POST :  localhost:50312/api/filedatas
		body: {
   			 	"Id":13,
  			 	"Name":"Post Try",
   			 	"Price":12.11
			  }	

	PutProduct : Method:PUT :  localhost:50312/api/filedatas
		body: {
   			 	"Id":13,
  			 	"Name":"Put Try",
   			 	"Price":12.11
			  }

	DeleteProductById : Method:DELETE :  localhost:50312/api/filedatas/13	
	Options : Method:OPTIONS :  localhost:50312/api/filedatas		  
