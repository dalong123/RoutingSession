<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Content/Site.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <div>
        You're seeing this from webforms!
    </div>
    <div>
        <% if(!string.IsNullOrWhiteSpace(RouteData.Values["id"] as string)) {%>
            You've passed an id parameter: <%: RouteData.Values["id"]%>
        <% } %>
    </div>
</body>
</html>
