
## C# testini çözdükten sonra araştırdığım kavramlar : 


##Struct
	Structlar kendi değer tiplerimizi oluşturmamıza yarayan yapılardır.
	Classlar kadar kompleks olmasına ihtiyaç duymadığımız sadece veri işlemleri için kullanılacak bir yapı lazımsa bir struct oluşturarak kullanabiliriz.
	Structlar class veya structlardan kalıtım alamazlar.
	Sadece Interface implemente edilebilir.


##Mutable ve Immutable
	Kelime anlamları olarak mutable değişebilir, immutable değişemez demektir.
	Aslında tam olarakta keli anlanmlarını karşılayan işler yapıyorlar.
	Immutable tanımlamak için readonly ve propertyler için encapsulation özelliklerinden sadece get özelliğini tanımlarsak bu değerleri sadece constructorda set edip daha sonra değişmemesini garantilemiş oluşuruz ve Immutable bir değer oluşturmuş oluruz.


##Predicate
	Predicate aslında bir delegedir.
	Delegeler methodları işaret etmeye yarayan ve işaret ettikleri methodlarla aynı parametreleri alan ve aynı dönüş tipine sahip olan yapılardır.
	Bir methodu delege içine atayıp delegeler üzerinden çağırabiliriz ve aynı imzalara sahip birçok methodu bir delege içine atıp atanan methodları sırasıyla tek bir delege çağırarak kullanabiliriz.
	Predicate ise herhangi bir tipteki değişkeni alarak geriye sadece boolean değer dönen özel bir delegedir.


##Partial Class
	Partial classlar gereksinimlerden dolayı büyüyen classların okunulabilirliklerinin azalması sebebiyle bölmeye ihtiyaç duyduğumuz zamanlarda classları parçalamamıza yardımcı olan yapılardır.
	Base classla aynı isimlerde tanımlanması gerekir.
	örnek olarak bir base classta methodlarımız olduğunu düşünürsek : 

		puclic class Person{
			public void GetPersons(){}
		}
	gibi bir classımız olduğunu düşünelim.
	partial classtada propları tuttuğumuzu düşünelim : 

		public partial class Person{
			public string Name {get; set;}
		}

	gibi bir yapı kurduğumuz zaman bunları tek bir classta gibi kullanabiliyoruz.