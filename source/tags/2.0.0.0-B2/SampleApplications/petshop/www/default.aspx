<%@ Page Language="C#" MasterPageFile="~/global.master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<map name="petmap">
	<area href="category.aspx?CategoryId=99d1bea3-9c50-466a-b082-d1954d736644" alt="Birds" coords="72,2,280,250" shape="RECT">
	<area href="category.aspx?CategoryId=b8469bb3-991b-4623-a7ea-d772106698be" alt="Fish" coords="2,180,72,250" shape="RECT">
	<area href="category.aspx?CategoryId=7c6cc986-bee6-42ac-948a-bf8f579ac3dc" alt="Dogs" coords="60,250,130,320" shape="RECT">
	<area href="category.aspx?CategoryId=6ea4bc05-2402-45ee-b707-e3ba1f865f4d" alt="Reptiles" coords="140,270,210,340" shape="RECT">
	<area href="category.aspx?CategoryId=6eb220f9-7992-4e19-a264-54a50ea0e389" alt="Cats" coords="225,240,295,310" shape="RECT">
	<area href="category.aspx?CategoryId=99d1bea3-9c50-466a-b082-d1954d736644" alt="Birds" coords="280,180,350,250" shape="RECT">
</map><img id="Img1" src="~/images/splash.gif" alt="Pet Selection Map" usemap="#petmap" width="350" height="355" runat="server" border="0">
</asp:Content>
