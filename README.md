MVC-CMS
=======

A lightweight ASP.net MVC CMS

The goal of this project is to help MVC developers create data-driven websites using Bootstrap and Entity Framework Code First.

It is NOT an clone of Wordpress. There is no setup screen, there are no wizards or other UI elements. It does not take over the structure of your app or force you into a particular way of creating a website.

This allows mvc.cms to be used with existing websites as an add-on, and you can even use it with existing MVC views and controllers if that's what you need.

The primary use case is for developing a custom ASP.net MVC website that ultimately which needs content to be editable by end users. The end user can edit labels, content, drop-down lists etc. For example, an order entry form. It is going to have most elements coded by a developer. But labels may need to be renamed, content updated etc that needs no developer intervention.

The primary workflow is:
1. Adding an action in a controller to handle a page request.
2. Creating a ViewModel for the Page (a PageViewModel).
3. Creating a View for the ViewModel.

A PageViewModel is simple class with whatever properties needs to be exposed to the View. For example, a Page with a Header would be:
    public class HomeViewModel : ViewModelBase{

    [MapToDb]
     public string Header{get;set;}

     }


Note the MapToDb attribute. At runtime, reflection is used to find all properties which are to be mapped to the database. The values are then retrieved automatically and set.

The view then uses the ViewModel as it's model:
     <h1>Model.Header</h1>.


And so, with no additional code, you have a data driven website.

The next phase is editing that header. An HTML helper is included which sets up "Editable Regions." Authorized users click on a "Edit this page" button, and a button is shown for each region which can be edited, such as the header. The user clicks on an Edit button for the region he would like to edit, and the EditTemplate is retrieved and displayed. In this example, a textbox is shown in place. The user edit's, hit's a save button, and the Header is then saved to the database. All of this is done code free. The plumbing to do all of that is supplied by the framework.

The above is a simple example, but extended to include all content, labels, and text on a website, it becomes a very workable system.

There are many more goodies in the toolbox, too many to show here. But the general idea is to provide a framework which, like MVC, doesn't get in the way, it only shows one way to get things done.
