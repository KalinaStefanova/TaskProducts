# TaskProducts
This branch contains two archives and a project.
ProductsAndCategories.rar is a project arhive.
productInfo.rar is the mongodb database dump.

In order to be able to test the project you need to restore this database,
After you set up the project and restore the database -  build it and open Products.html in your browser.

BUGFIX:  
In Producs.html at row 66 the "txtaddProductID" input element should not be disabled: input type="text" id="txtaddProductID" disabled="disabled" 
Please, remove the "disabled" attribute.
