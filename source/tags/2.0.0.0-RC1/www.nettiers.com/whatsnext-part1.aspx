<%@ Page MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<script src="http://js.track.semway.com/v1.2/tag.js" type="text/javascript"></script>
    <script type="text/javascript">
    <!--
        swtag();
    -->
    </script>
    <noscript>
			<img width="1" height="1" src="http://ws2.track.semway.com/v1.3/noscript.ashx" >
		</noscript>
		
From Original post by Robert Hinojosa: <a href="http://forum.codesmithtools.com/default.aspx?f=19&m=8499">http://forum.codesmithtools.com/default.aspx?f=19&m=8499</a>
<p></p>

<B>I've got it NetTiers Generated, Now where do I go?</B>
<DIV></DIV>
<DIV>&nbsp;</DIV>
<DIV>This article is for advanced and complex application architectures.&nbsp; For 
	simple projects and prototypes, you can simply use the Entity and DAL layers 
	direcly.</DIV>
<DIV>&nbsp;</DIV>
<DIV>Now, there are several ways to really leverage this type of an architecture 
	with Business Objects.&nbsp;
</DIV>
<DIV><A href="http://codebetter.com/blogs/jeffrey.palermo/archive/2005/04/02/128598.aspx"
		target="_blank">http://codebetter.com/blogs/jeffrey.palermo/archive/2005/04/02/128598.aspx</A></DIV>
<DIV>I will focus on two of them, both have their pros and cons and I will discuss 
	both of them.&nbsp; By all means, if there are others you'd like to see 
	compared, let me know, and I will do a write up of them all.&nbsp; There is no 
	silver bullet to architecture, so each will have a pro and a con.&nbsp; Choose 
	wisely.</DIV>
<DIV>&nbsp;</DIV>
<DIV><B>Manager Business Objects</B>:</DIV>
<DIV>The first architecture that you can use right out of the box, is the Manager 
	pattern.&nbsp;
</DIV>
<DIV>&nbsp;</DIV>
<DIV>For each of your core entities within your domain, you have a manager object 
	that contains methods that serve as all of the verbs or behavior that your 
	entity can do.</DIV>
<DIV>&nbsp;</DIV>
<DIV>As an example, we stick with Northwind and we look at the Orders Entity.</DIV>
<DIV>&nbsp;</DIV>
<DIV>There would then be an&nbsp;OrderManager class that would have several of the 
	following verb type behavior methods, CreateOrder(), GetOrder(), 
	SaveOrder().&nbsp; There is much more to this logic however, since CreateOrder 
	has to manage many of the sibling or children relationships, such as having 
	things such as a potential Customer Entity, Invoice Entity, Products Entity, 
	Price List entity, etc.&nbsp; So the manager is able to know about<B></B><B></B><B></B><B></B><B></B><B></B><B></B>
	all of the relationships in the domain, and how to use the loosely coupled 
	domain objects in a manner that is still flexibile and allows for change quite 
	easily.&nbsp;
</DIV>
<DIV>&nbsp;</DIV>
<DIV>In even further complex applications, where the ordering business process 
	changes from client to client, these Verbs can easily become one of two 
	patterns for further flexibility, a Strategy pattern, or an Inversion of 
	Control pattern.
</DIV>
<DIV>&nbsp;</DIV>
<DIV>This basically says, Ok, I as an OrderManager know that there is a need to do 
	a CreateOrder() verb, however, in a situation that gives exclusive vendor 
	pricing based on vendor, the logic to determine the actual order varies 
	drastically.&nbsp; So the OrderManager can not possibly know all of the varying 
	ways a CreateOrder can happen, although he knows for sure that it must 
	happen.&nbsp; So the CreateOrder(IOrderBuilder orderBuilder)&nbsp; which is 
	responsible for knowing how to relate this still dumb entities that are used to 
	persist your orders.&nbsp;
</DIV>
<DIV>&nbsp;</DIV>
<DIV>The biggest pro, is that it's easy to do, it uses out of the box 
	functionality, easy for other developers to see relationships and pick up where 
	you left off, and keeps objects thin, they still are dummy objects not knowing 
	how to do really quite anything except keep object state. There is a little bit 
	more coupling, but if using Strategy or IOC, you can alleviate that coupling.</DIV>
<DIV>&nbsp;</DIV>
<DIV>The drawback is that you can't have direct object composition, as in the 
	example where the Ticket has a TicketStatus object as&nbsp;a property. You can 
	always however just do that as a method by passing the object so it will know 
	which ID to pull from.&nbsp; These objects are now puppeteered, and moved from 
	one method to the other, not knowing where it came from or where it's 
	going.&nbsp; They are always depending on someone else to process.&nbsp;
</DIV>
<DIV>&nbsp;</DIV>
<DIV><B>Component Based Business Objects:</B></DIV>
<DIV>The second method is to simply inherit from these dumb, loosely coupled, 
	entity objects. This layer sits on top of both the entity layer and the DAL 
	layer.&nbsp; These entities now become fat business objects because now, they 
	have wrappers to all of the DAL methods, they know how to load, save, and 
	manipulate&nbsp;themselves and are not dependant on another manager object to 
	load them and puppeteer these objects around.&nbsp; They try and define all of 
	their relationships, so loading one of these guys usually gives you access to 
	the entire object graph.&nbsp; Things to alleviate the load are things like 
	using lazy loading for composition, ex Ticket entity has a TicketType object, 
	but it stays null until it's actually in use.&nbsp; This is great for 
	applications that are heavily defined.&nbsp; I need to build a FAQ and 
	Knowledge Base application.&nbsp; Well, it's pretty defined that the FAQ and 
	Knowledge Base will be mostly defined by the nature and history of FAQ's and 
	KB's.&nbsp; You know that history says, these applications do not change much 
	across the board.&nbsp; These are great because it's one stop shopping for 
	everything that object stands for.&nbsp; All of your business logic goes in one 
	place, and now with Partial classes, makes it even easier to generate most of 
	this code.&nbsp; There is a Book called Object Thinking <A href="http://www.amazon.com/exec/obidos/tg/detail/-/0735619654/002-9090140-5676836?v=glance"
		target="_blank">http://www.amazon.com/exec/obidos/tg/detail/-/0735619654/002-9090140-5676836?v=glance</A>, 
	and a co-worker had introduced me to this, saying that if you think of objects 
	like people, you would not like to forced across the dancefloor by some Manager 
	object,&nbsp;thus the puppeteering reference above.&nbsp;You, as an object 
	would like to dance in your own graces.</DIV>
<DIV>&nbsp;</DIV>
<DIV>The pros, easily control event management, object composition, aggregation is 
	already in place from the Entity objects because of the code gen.&nbsp; A truer 
	object domain.&nbsp; You will have 1-1 domain to object representation for the 
	most part.&nbsp; Using good pattern design, you will not see too much overhead, 
	ie lazy loading compositional objects.&nbsp; All logic is in one place, one 
	stop shopping.</DIV>
<DIV>&nbsp;</DIV>
<DIV>The cons however, all logic is in one place.&nbsp; This could get huge 
	quickly, and that can be a nasty, nasty problem, as far as organizational items 
	are concerned.&nbsp; Again though, with partial classes, there is an easier way 
	to organize all of your stuff, but seperating too much without a class 
	representation might make it confusing for other developers to pick up and use. 
	Also, in order for you to inherit from lowly Entity project, and use this new 
	type out of the box, the DAL layer has to know about<B></B><B></B><B></B><B></B><B></B><B></B><B></B>
	the type it's going to be creating in the DAL.&nbsp; Which, by the layering, 
	if&nbsp;your component project sits on top&nbsp;of the&nbsp;Entity&nbsp;and DAL 
	Layers, will not be&nbsp;possible without some refactoring.&nbsp; So if you 
	call a GetByTicketId(int id) when the DAL has a datareader and has&nbsp;records 
	to return to you, he says, Hey I'm gonna create an object 
	of&nbsp;Entity.Ticket.&nbsp;&nbsp;Well, using this approach does you no good, 
	because you would have to map the object to a Components.Ticket from a 
	Entity.Ticket.&nbsp; Even though&nbsp;you&nbsp;inherit from Entity.Ticket, you 
	are not a type of Component.Ticket, so you&nbsp;loose all the composition you 
	added,&nbsp;ie (TicketType object as a property&nbsp;of Ticket).&nbsp; To 
	remedy this scenario, you have to use reflection&nbsp;and use a factory pattern 
	for a Create() method that says, what type do you want&nbsp;back, the only 
	thing&nbsp;I know about<B></B><B></B><B></B><B></B><B></B><B></B><B></B> is an 
	Entity.TicketType, but if you want something else, you'll have to tell me to 
	create this type.&nbsp; Doing this, the DAL has to be setup to accept a type, 
	like NameSpace.Components.Ticket.&nbsp; Taking this, you can say, 
	Activator.CreateInstance(type) and then when these objects come back to you 
	from the DAL, they are already in your type, and everything is good in the 
	world again.&nbsp; So now from the UI, I can say
</DIV>
<DIV>&nbsp;</DIV>
<DIV>Components.Ticket ticket = Ticket.GetByTicketId(9);&nbsp;
</DIV>
<DIV>MyLabel.Text = ticket.TicketType.TicketTypeName;</DIV>
<DIV>
	<DIV>&nbsp;</DIV>
	<DIV><B>How to Decide:</B></DIV>
	<DIV>In many real life scenarios, this is a perfectly acceptable approach to use 
		either.&nbsp; Think of yourself at the grocery store and your checking 
		out.&nbsp; There is a defined process you go through. Example one would be, 
		here's my shopping cart, check me out.&nbsp; There is the Order(You), and you 
		have an OrderManager (the check out clerk), they are processing your order with 
		an OrderProcessor(Register), and you have varying things that can come into 
		play.&nbsp; Coupons, Multi-Tender, Overrides, Cash - Check or Charge.&nbsp; 
		With an OrderManager, you can create classes for the differing items and stay 
		flexible enough to manage anything that can come up.</DIV>
	<DIV>&nbsp;</DIV>
	<DIV>Scenario two is the Component based approach, I am a self contained object, I 
		know all and be all. So I will take myself to the Self Checkout Line and do all 
		the work myself.&nbsp;&nbsp; You are still the Order(You), however, this is 
		very defined process, and are very limited to what you can do.&nbsp; Show my id 
		when i buy beer. Coupons, defined set of Multi-Tender, However, how will you 
		hanlde when you can't do any overrides unless they are defined or if it doesn't 
		recognize the coupon you&nbsp;entered to your&nbsp;Composite Order 
		Processor&nbsp;Compositional Object, etc.&nbsp; If things vary, you have to 
		depend on someone else to help.&nbsp; In having to call someone else to help, 
		in a&nbsp;component based architecture, who is that, do they fit neatly in your 
		domain?&nbsp;&nbsp;If noone, you'll have a myriad of if/then/else and case 
		statements, all in one place.&nbsp;&nbsp;Is that really what you want?&nbsp;
	</DIV>
	<DIV>Case in point, if going the myriad route, try to use patterns to seperate what 
		varies, and not be so stuck on trying to get everything in one place.&nbsp; 
		There will be some marrying of the two if&nbsp;you need flexibility, but in the 
		end, this works best if there is a hard defined process and requirements that 
		won't change.</DIV>
	<DIV>&nbsp;</DIV>
	<DIV>As always, we are <B></B><B></B><B></B><B></B><B></B><B></B><B></B>open to any 
		suggestions that will help us get to the next level in all your hearts.</DIV>
	<DIV>&nbsp;&nbsp;
	</DIV>
	<IMG alt="tongue" src="http://forum.codesmithtools.com/emoticons/tongue.gif" border="0"
		emot=":tongue:">
	<P></P>
	<P></P>
	<P></P>
	<P></P>
	<P></P>
	<P></P>
	<P>
		<HR align="left" width="50%" SIZE="1">
		<DIV>Robert</DIV>
		<DIV>-------------------------------------<BR>
			&nbsp;Member of the .NetTiers team</DIV>
		<DIV><A href="http://www.nettiers.com" target="_blank">http://www.nettiers.com</A><BR>
			-------------------------------------
			<P></P>
		</DIV>
	<P></P> <!-- Edit -->
	<P><I>Post Edited (Robert Hinojosa) : 11/10/2005 12:36:00 PM GMT</I></P>
</DIV>
</asp:Content>