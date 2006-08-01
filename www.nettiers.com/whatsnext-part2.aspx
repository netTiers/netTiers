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

From Original post by Robert Hinojosa: <a href="http://forum.codesmithtools.com/default.aspx?f=19&m=8605">http://forum.codesmithtools.com/default.aspx?f=19&m=8605</a>
<p></p>
<DIV class=msgQuoteWrap>I thought this deserved another post, since it deals 
with detailed problem domain.&nbsp; I wrote this post&nbsp;so that i could 
appeal to a large audience. Well hopefully. <IMG alt=tongue 
src="http://forum.codesmithtools.com/emoticons/tongue.gif" border=0 
emot=":tongue:"> </DIV>
<DIV class=msgQuoteWrap>This is a followup from the post found here: Part I - <A 
href="http://forum.codesmithtools.com/default.aspx?f=19&amp;m=8499" 
target=_blank>http://forum.codesmithtools.com/default.aspx?f=19&amp;m=8499</A></DIV>
<DIV class=msgQuote>
<DIV name="quote"><B>jcteague said...</B><BR>What is the best approach for 
dealing with inheritance in your problem domain? For instance, my company does a 
lot of insurance work. There are many types of insurance policies, Whole Life vs 
Term Life. When creating a quote, there is some level of shared work and also 
quite a bit of polymorphism. In this scenario, the Manager pattern has been a 
little limiting. How would you incorporate an inheritance structure with 
NetTiers.<BR><BR>I think that is is part of using the component model as well as 
a database design that elegantly handles inheritance and use of Views to 
represent them. <BR><BR>I really like the extending with partial classes use 
case. That will make some very interesting implementations.</DIV></DIV>
<DIV>&nbsp;</DIV>
<DIV>ok, here it goes...&nbsp;&nbsp;<IMG alt=shocked 
src="http://forum.codesmithtools.com/emoticons/shocked.gif" border=0 
emot=":shocked:"> </DIV>
<DIV>&nbsp;</DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">Let’s take a look at 
the following problem domains insurance and loan underwriting, more 
specifically, contracts. <SPAN style="mso-spacerun: yes">&nbsp;</SPAN>There are 
many industries that can drive a developer nuts.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>One of them is of course insurance, and 
the other is loan underwriting, especially mortgage loans.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>They change so often, and always create 
new products, with a new set terms and conditions, and you learn quickly to be 
very weary of your architecture because it can change at any moment.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>
<o:p></o:p></SPAN>
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">I remember reading an 
article in the Wall Street Journal about<B></B><B></B><B></B> insurance and how 
the industry has the ability to change the entire financial stability of the 
Global Market.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>In the 1970’s, FTC 
issued findings in Whole Life Insurance, and said that the product was not 
beneficial paid a measly 1.5% in interest.<SPAN style="mso-spacerun: yes">&nbsp; 
</SPAN>As a result, the industry decided they needed to revamp its entire 
product line. So they said, the heck with whole life, we need a new product, 
let’s create Universal life insurance, and solve all our problems, and the 
interest earned would now be closer to 15%.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>Their revenue streams now positive and 
the sale of the most beneficial job (insurance sales) in the late 70’s and 80’s 
created a massive shift of money.<SPAN style="mso-spacerun: yes">&nbsp; 
</SPAN>Trillions of dollars were transferred throughout the end of the century, 
in the largest money transfer of any kind in the history of the world.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN><SPAN 
style="mso-spacerun: yes">&nbsp;&nbsp;</SPAN>
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">My point is, the 
products the insurance industry offers varies often, and can have a significant 
impact on the financial market in a hurry.<SPAN style="mso-spacerun: yes">&nbsp; 
</SPAN>This can lead to the suits scrambling to have departments create a new 
product in a hurry.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>This brings us 
full circle to you, the poor developer left to create this “Magical” solution 
tomorrow, that was needed yesterday by the suits to gain a stronghold on the 
changing market. 
<o:p></o:p></SPAN>
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">I will give you my 
perspective from my limited business intelligence knowledge in insurance, and 
give my perspective on a more general design on contracts and policies.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>This domain basically revolves around a 
set of terms and a set of conditions, tied to a policy holder. 
<o:p></o:p></SPAN>
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><B 
style="mso-bidi-font-weight: normal"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">Terms:
<o:p></o:p></SPAN></B> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">Typically these terms 
(or definition), can join 2 or more people or business entities and an 
obligation.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>The term defines the 
obligations and is considered the “body” of the policy.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>Take for example a Term Life Insurance 
product.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>I, the underwriter, will 
pay out to your policy of 100,000 dollars to your beneficiary, if you die within 
the next term length x years. <SPAN style="mso-spacerun: yes">&nbsp;</SPAN>You, 
the policy holder, will pay us 30 dollars a month, for term length x years.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>
<o:p></o:p></SPAN>
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">The problems you’re 
left with are, since these are set in stone as a contract, how do you maintain 
new products that might arise, and still maintain a good grasp on the policies 
that are already in place?<SPAN style="mso-spacerun: yes">&nbsp;&nbsp; 
</SPAN>How do you make adjustments to the policy, riders, etc., and still keep 
the terms in tact and know whether or not that adjustment was made prior to or 
after any particular date.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>We’ll 
talk about<B></B><B></B><B></B> your inheritance model in just a 
bit.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><B 
style="mso-bidi-font-weight: normal"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">Conditions:
<o:p></o:p></SPAN></B> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">The next portion is 
the conditions, which are by definition always includes the unknown and 
variables that would break the obligations and the policy is no longer valid. 
<SPAN style="mso-spacerun: yes">&nbsp;&nbsp;</SPAN>An example would be, if you 
jump off a bridge, we, the underwriter will not pay out any money.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>There are a series of these, which would 
be considered mostly the policy rules if these are broken this is not 
valid.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">I hear what you’re 
saying about<B></B><B></B><B></B> using inheritance to determine a whole life 
vs. term policy in way that inheritance makes sense.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN><SPAN 
style="mso-spacerun: yes">&nbsp;</SPAN>The problem here is that the products 
behavior can change, and they can change often.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>They can change from year to year, and 
their conditions can change.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>You 
can add a rider on your policy, in mid-stream, and those conditions can change 
as well.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">In OO, we’re first 
taught about<B></B><B></B><B></B> inheritance and that’s really the hook.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>Look see, a Car is a Vehicle, and a 
Truck is a Vehicle too. <SPAN style="mso-spacerun: yes">&nbsp;&nbsp;</SPAN>The 
IS-A construct makes sense and makes us believe that inheritance will solve all 
our problems.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>I’d like to say that 
a 
<o:p></o:p></SPAN>
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">Well that’s great and 
all, but the reality is that there is a huge difference in the components that 
make up these cars, and they potentially change every year.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>Just go into your local auto parts 
dealer and see the massive books they have on parts for individual 
cars.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">So here’s my 
recommendation, and I’ve attached the sample code as well, because this editor 
applies breaks and it’s difficult to see. You will be able to see that the 
architecture and patterns in use, make it possible to not have to scramble all 
the time, even in a complex development environment, like yours.<SPAN 
style="mso-spacerun: yes">&nbsp;&nbsp; </SPAN>I recommend and show that using 
inheritance is good, but only for Type Matching only and not for behavior.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>Behavior typically varies the most, and 
changes the most. and behavior should be left to the Processors.&nbsp; This 
whole manager pattern follow the <B></B><B></B><B></B>open/Closed Principle, 
meaning, the architecture is left <B></B><B></B><B></B>open for inclusion but 
closed for modification,&nbsp;<SPAN style="mso-spacerun: yes">&nbsp;</SPAN>so 
you are able to add additional products at any time, and it will not affect any 
current code.<SPAN style="mso-spacerun: yes">&nbsp; </SPAN>Or if you have to 
suddenly change a product, you may do so without affecting any other 
code(nothing like bringing down an entire system).<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>You will never be left having to manager 
a fury of if/then/else conditional logic, as all of the code as it’s place and 
we’re always separating out the code for the differing products.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>The code is not in one place as in the 
Components pattern by itself, however, in very large systems, it’s easier to 
manage many files because the different parts of the overall entity usually 
follow an organizational pattern to them as well.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>So behavior will always be found in a 
single <B></B><B></B><B></B>location.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana"><SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>So this statement works,</SPAN><SPAN 
style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; mso-bidi-font-family: 'Courier New'; mso-no-proof: yes"> 
but there’s really nothing to TermLifePolicy, because the actual implementation 
is in the body and processors.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana"><SPAN 
style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</SPAN></SPAN><SPAN 
style="FONT-SIZE: 10pt; COLOR: blue; FONT-FAMILY: 'Courier New'; mso-no-proof: yes">if</SPAN><SPAN 
style="FONT-SIZE: 10pt; FONT-FAMILY: 'Courier New'; mso-no-proof: yes"> (policy 
<SPAN style="COLOR: blue">is</SPAN> TermLifePolicy)
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; mso-bidi-font-family: 'Courier New'; mso-no-proof: yes">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; mso-bidi-font-family: 'Courier New'; mso-no-proof: yes">All 
of the inheritance is mostly used only for type matching and all of the 
implemlentation code favors composition when coding toward an interface.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>The HAS-A Construct lends itself great 
with the Strategy Pattern, and does not tie yourself down with coupling.<SPAN 
style="mso-spacerun: yes">&nbsp; </SPAN>and lies within the body of the entity, 
Terms, Conditions, and PolicyHolder, using a Strategy pattern. I’m using a 
marriage of both the manager pattern and the Components pattern to show you that 
there is still flexibity in using both patterns, or I could use extensively one 
without the other and still be able to manage. 
<o:p></o:p></SPAN>
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; mso-bidi-font-family: 'Courier New'; mso-no-proof: yes">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; FONT-FAMILY: Verdana; mso-bidi-font-family: 'Courier New'; mso-no-proof: yes">I 
hope this helps, I’m not sure it does, please let me know if I just made things 
more confusing.
<o:p></o:p></SPAN> 
<DIV></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>&nbsp;</o:p></SPAN> 

<DIV></DIV><SPAN 
style="FONT-SIZE: 8pt; COLOR: black; FONT-FAMILY: Verdana">
<o:p>
<DIV class=msgQuoteWrap>&nbsp;</DIV>
<DIV class=msgQuoteWrap><B>See attached version for cleaner look, the editor 
messes it up.</B> 
<DIV class=msgCode>
<DIV name="code"><FONT color=#0000ff size=2>
<DIV>using</FONT><FONT size=2><FONT color=#000000> 
System;</FONT></DIV></FONT><FONT color=#0000ff size=2>
<DIV>using</FONT><FONT size=2><FONT color=#000000> 
System.Collections.Generic;</FONT></FONT></DIV>
<DIV><FONT size=2><FONT color=#000000></FONT>&nbsp;</DIV></FONT><FONT 
color=#0000ff size=2>
<DIV>namespace</FONT><FONT size=2><FONT color=#000000> 
FunWithInsurance</FONT></DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#808080 size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#808080 size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Basically the manager or component is responsible for </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
implementation of security authorization, logging auditing</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> and 
upmost behavior verbs, ie. Create(), Save(), Get(), Delete(), 
CreateQuote()</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> I'm 
using a Manager here for my example.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> The 
context is your meta data used to maintain a healthy 
application</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> PolicyManager</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#0000ff size=2>public</FONT><FONT size=2> PolicyManager() { 
}</FONT></DIV>
<DIV><FONT size=2></FONT>&nbsp;</DIV>
<DIV><FONT size=2></FONT>&nbsp;</DIV>
<DIV><FONT size=2>&nbsp;</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> Create Policy</FONT></DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
CreatePolicy(IPolicy policy, </FONT><FONT color=#0000ff size=2>out</FONT><FONT 
size=2> Context context)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#0000ff size=2>if</FONT><FONT size=2> (!this.HasRights(context, 
ActionType.Create))</DIV>
<DIV>{</DIV>
<DIV>&nbsp;&nbsp;&nbsp; Log.SecurityLog(policy, context, 
ActionType.Create);</DIV>
<DIV></FONT><FONT color=#0000ff size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#0000ff size=2>&nbsp;&nbsp;&nbsp;&nbsp;throw</FONT><FONT 
size=2> </FONT><FONT color=#0000ff size=2>new</FONT><FONT size=2> </FONT><FONT 
color=#008080 size=2>Exception</FONT><FONT size=2>(</FONT><FONT color=#800000 
size=2>"This action is not allowed."</FONT><FONT size=2>);</DIV>
<DIV>}</DIV>
<DIV>&nbsp;</DIV>
<DIV></FONT><FONT color=#008000 size=2>// Before Event Handling: 
</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// Now is a good time to subscribe or 
fire to necessary events </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// that happen BEFORE you hand off a 
policy to Create </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// ex. Notifications and Messaging, or 
Invalid State</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>try</DIV></FONT><FONT size=2>
<DIV>{</DIV>
<DIV>&nbsp;</DIV>
<DIV></FONT><FONT color=#008000 size=2>&nbsp;&nbsp;&nbsp; // Get the 
processor</DIV></FONT><FONT size=2>
<DIV>&nbsp;&nbsp;&nbsp; PolicyProcessor policyProcessor = 
ProcessorFactory.Create(policy);</DIV>
<DIV></DIV>
<DIV></FONT><FONT color=#008000 size=2>&nbsp;&nbsp;&nbsp; //Call the 
processor</DIV></FONT><FONT size=2>
<DIV>&nbsp;&nbsp; IPolicy policy = policyProcessor.ProcessCreate(policy, 
context);</DIV>
<DIV>&nbsp;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>catch</FONT><FONT size=2> (</FONT><FONT 
color=#008080 size=2>Exception</FONT><FONT size=2> exc)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#008000 size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#008000 size=2>&nbsp;&nbsp;&nbsp; //log exception, object, 
context, and verb</DIV></FONT><FONT size=2>
<DIV>&nbsp;&nbsp;&nbsp; Log.ExceptionLog(exc, policy, context, 
Action.Create);</DIV>
<DIV>}</DIV>
<DIV>&nbsp;</DIV>
<DIV></DIV>
<DIV></FONT><FONT color=#008000 size=2>// Post Event Handling</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#008000 size=2>// Now is a good time to subscribe or 
fire to necessary events </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// that happen AFTER a policy get's 
processed from Create</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// ex. Notifications and Messaging, or 
Invalid State</DIV></FONT><FONT size=2>
<DIV></DIV>
<DIV></FONT><FONT color=#008000 size=2>//Since this type of information is 
extremely sensitive we log all actions</DIV></FONT><FONT size=2>
<DIV>Log.Entry(policy, context, ActionType.Create);</DIV>
<DIV></FONT><FONT color=#008000 size=2></FONT>&nbsp;</DIV>
<DIV><FONT color=#008000 size=2>// Return entity</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> 
policy;</FONT></DIV>
<DIV><FONT size=2>&nbsp;</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> 
</FONT></DIV></FONT><FONT color=#0000ff size=2>
<DIV>&nbsp;</DIV>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> Save Policy</FONT></DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Notice there is no actual implementation here. I'm really just here to keep 
things moving around</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> and 
ensure that the health of my application is in order. </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Think of a manager in a store. The manager really only walks around and handles 
exceptional cases. </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> The 
manager does not actually do any work, other than </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 1. 
Overrides (Security and Auth - based on context)</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 2. 
Angry Customers (thrown Exceptions)</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 3. 
Handles Manager On Duty (MOD) Calls (Event Management)</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 4. 
<B></B><B></B><B></B>opens and Locks the Store (The manager object should be the 
entry point for all things in your complex application)</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param name="policy"&gt;</FONT><FONT 
color=#008000 size=2>entity</FONT><FONT color=#808080 
size=2>&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param name="context"&gt;</FONT><FONT 
color=#008000 size=2>context can enclose security authorization and 
anything</FONT><FONT color=#808080 size=2>&lt;/param&gt;</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;returns&gt;</FONT><FONT color=#008000 
size=2>IPolicy as a typed Policy</FONT><FONT color=#808080 
size=2>&lt;/returns&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
SavePolicy(IPolicy policy, </FONT><FONT color=#0000ff size=2>out</FONT><FONT 
size=2> Context context)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> 
(!this.HasRights(context, ActionType.Save))</DIV>
<DIV>{</DIV>
<DIV>Audit.SecurityLog(policy, context, ActionType.Save);</DIV>
<DIV></FONT><FONT color=#0000ff size=2>throw</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>new</FONT><FONT size=2> </FONT><FONT color=#008080 
size=2>Exception</FONT><FONT size=2>(</FONT><FONT color=#800000 size=2>"This 
action is not allowed."</FONT><FONT size=2>);</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#008000 size=2>// Before Event Handling: 
</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// Now is a good time to subscribe or 
fire to necessary events </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// that happen BEFORE you hand off a 
policy to Create </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// ex. Notifications and Messaging, or 
Invalid State</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>try</DIV></FONT><FONT size=2>
<DIV>{</DIV>
<DIV></FONT><FONT color=#008000 size=2>// Get the processor</DIV></FONT><FONT 
size=2>
<DIV>PolicyProcessor policyProcessor = ProcessorFactory.Create(policy, 
context);</DIV>
<DIV></FONT><FONT color=#008000 size=2>//Call the processor</DIV></FONT><FONT 
size=2>
<DIV>IPolicy policy = policyProcessor.ProcessSave();</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>catch</FONT><FONT size=2> (</FONT><FONT 
color=#008080 size=2>Exception</FONT><FONT size=2> exc)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#008000 size=2>//log exception, object, context, and 
verb</DIV></FONT><FONT size=2>
<DIV>Log.ExceptionLog(exc, policy, context, Action.Save);</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#008000 size=2>// Post Event Handling</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#008000 size=2>// Now is a good time to subscribe or 
fire to necessary events </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// that happen AFTER a policy get's 
processed from Create</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// ex. Notifications and Messaging, or 
Invalid State</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>//Since this type of information is 
extremely sensitive we log all actions</DIV></FONT><FONT size=2>
<DIV>Log.Entry(policy, c, ActionType.Save);</DIV>
<DIV></FONT><FONT color=#008000 size=2>// Return entity</FONT></DIV>
<DIV><FONT color=#008000 size=2>&nbsp;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> policy;</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> 
</FONT></DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> 
ProcessorFactory</FONT></DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> ProcessorFactory</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>static</FONT><FONT size=2> PolicyProcessor Create(IPolicy 
policy, Context context)</DIV>
<DIV>{ </DIV>
<DIV></FONT><FONT color=#008000 size=2>// use a property in Policy to create a 
new policy processor to use. </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// You can get fancy by using reflection 
and Activator.CreateInstance, to determine this as well.</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#008000 size=2>// ensure that you pass in both the 
policy and context to processor. </DIV></FONT><FONT size=2>
<DIV>}</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> </FONT></DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> Policy 
Processors</FONT></DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> PolicyProcessor</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
ProcessCreate();</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
ProcessSave();</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
ProcessDelete();</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
ProcessGetBy();</DIV>
<DIV>}</DIV>
<DIV>&nbsp;</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> 
TermLifeProcessor</FONT></DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
this process is responsible for the actual implementations to for my particular 
policy.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> TermLifeProcessor : 
PolicyProcessor</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>private</FONT><FONT size=2> IPolicy 
policy;</DIV>
<DIV></FONT><FONT color=#0000ff size=2>private</FONT><FONT size=2> Context 
context;</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> The 
factory is responsible for the creation of the Processor, and assigning the 
policy and context.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param 
name="policy"&gt;&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param 
name="context"&gt;&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV>TermLifeProcessor(IPolicy policy, Context context)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>this</FONT><FONT size=2>.policy = 
policy;</DIV>
<DIV></FONT><FONT color=#0000ff size=2>this</FONT><FONT size=2>.context = 
context;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> All 
the real magic is done in here</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
this process is responsible for these steps to save my policy.</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 1. 
it has to validate and save the terms</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 2. 
it has to validate and save the conditions</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 3. 
it has to validate and save my policyholder info, </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 4. 
which would in turn call the policyholdermanager//</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 5. 
which would validate and save my policyholder rider info, you get the 
idea.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param 
name="policy"&gt;&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param 
name="context"&gt;&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 
size=2>&lt;returns&gt;&lt;/returns&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
ProcessSave()</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> 
(IsEntityValid(policy))</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> 
(context.HasTransaction </DIV>
<DIV>&amp;&amp; context.TransactionManager != </FONT><FONT color=#0000ff 
size=2>null</FONT><FONT size=2> </DIV>
<DIV>&amp;&amp; context.TransactionManager.Is<B></B><B></B><B></B>open)</DIV>
<DIV>{</DIV>
<DIV>
<DIV>DataRepository.PolicyProvider.Save(context.TransactionManager, 
policy);</DIV>DataRepository.TermsProvider.Save(context.TransactionManager, 
policy.TermsCollection);</DIV>
<DIV>DataRepository.ConditionsProvider.Save(context.TransactionManager, 
policy.ConditionsCollection);</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#008000 size=2>// or if modeled correctly, you can just 
call Deep save</DIV></FONT><FONT size=2>
<DIV></DIV>
<DIV>}</DIV>
<DIV></DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> IPolicy 
ProcessCreate()</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#008000 size=2>//same body type as 
ProcessSave()</DIV></FONT><FONT size=2>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
check the entity, along with the children this processor is responsible 
for.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> for 
this particular product</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 
size=2>&lt;returns&gt;&lt;/returns&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>bool</FONT><FONT size=2> IsEntityValid()</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>bool</FONT><FONT size=2> isValid = 
</FONT><FONT color=#0000ff size=2>true</FONT><FONT size=2>;</DIV>
<DIV></DIV>
<DIV></FONT><FONT color=#008000 size=2>// You can do your type 
checking</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> (!(policy 
</FONT><FONT color=#0000ff size=2>is</FONT><FONT size=2> TermLifePolicy))</DIV>
<DIV>{</DIV>
<DIV>isValid = </FONT><FONT color=#0000ff size=2>false</FONT><FONT 
size=2>;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2>(policy.Coverage 
&gt; Policy.MaxCoverage)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>this</FONT><FONT 
size=2>.context.Messages.Add(</FONT><FONT color=#0000ff size=2>new</FONT><FONT 
size=2> Message(</FONT><FONT color=#800000 size=2>"The coverage amount is 
invalid."</FONT><FONT size=2>, MessageType.ProcessorError));</DIV>
<DIV>isValid = </FONT><FONT color=#0000ff size=2>false</FONT><FONT 
size=2>;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> 
(policy.Term.TermLength &gt; Policy.Term.MaxTermLength)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>this</FONT><FONT 
size=2>.context.Messages.Add(</FONT><FONT color=#0000ff size=2>new</FONT><FONT 
size=2> Message(</FONT><FONT color=#800000 size=2>"The term length is invalid, 
it can not exceed 30 years."</FONT><FONT size=2>, 
MessageType.ProcessorError));</DIV>
<DIV>isValid = </FONT><FONT color=#0000ff size=2>false</FONT><FONT 
size=2>;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> isValid;</DIV>
<DIV>}</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> </FONT></DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> WholeLifeProcessor : 
PolicyProcessor</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#008000 size=2>// All the work with the entities goes in 
here. </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// same as above, just with different 
business rules</DIV></FONT><FONT size=2>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</DIV>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> BLL Context and 
Stuff</FONT></DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>enum</FONT><FONT size=2> ActionType</DIV>
<DIV>{ </DIV>
<DIV>Create,</DIV>
<DIV>Save,</DIV>
<DIV>Process,</DIV>
<DIV>Read,</DIV>
<DIV>Get,</DIV>
<DIV>CreateQuote</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
This can be considered the Meta-Data Class</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> can 
contain current user, roles, groups, permissions</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
pages/forms affected</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
AuditTrail things like that.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
transaction enlistment</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Warnings and Errors that can be sent back to the UI</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> </FONT><FONT color=#008080 
size=2>Context</DIV></FONT><FONT size=2>
<DIV>{ </DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> 
SecurityPrincipal User</DIV>
<DIV>{ </DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> { } </DIV>
<DIV>}</DIV>
<DIV></DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Able to wrap the transaction manager for enlistment.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> 
DataAccessLayer.TransactionManager TransactionManager</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> { }</DIV>
<DIV></FONT><FONT color=#0000ff size=2>set</FONT><FONT size=2> { }</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#008000 size=2>// messages that can be delivered back to 
the UI, for showing</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#008080 size=2>List</FONT><FONT size=2>&lt;Message&gt; MessageList;</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> </FONT></DIV>
<DIV>&nbsp;</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> Business Entity 
classes</FONT></DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> Person : Entities.Person</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>string</FONT><FONT size=2> Name;</DIV>
<DIV></FONT><FONT color=#0000ff size=2>string</FONT><FONT size=2> Age;</DIV>
<DIV></FONT><FONT color=#0000ff size=2>string</FONT><FONT size=2> 
Relationship;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> PolicyHolder </DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> Person 
Assignee;</DIV>
<DIV></FONT><FONT color=#008080 size=2>List</FONT><FONT size=2>&lt;Person&gt; 
Riders;</DIV>
<DIV></FONT><FONT color=#008080 size=2>List</FONT><FONT size=2>&lt;Person&gt; 
Benificiary;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>interface</FONT><FONT size=2> IPolicy</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>virtual</FONT><FONT size=2> Entities.TermCollection 
Terms</DIV>
<DIV>{ </FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2>; </FONT><FONT 
color=#0000ff size=2>set</FONT><FONT size=2>; }</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>virtual</FONT><FONT size=2> Entities.ConditionCollection 
Conditions</DIV>
<DIV>{ </FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2>; </FONT><FONT 
color=#0000ff size=2>set</FONT><FONT size=2>; }</DIV>
<DIV>}</DIV>
<DIV>&nbsp;</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> TermLifePolicy : Entities.Policy, 
IPolicy</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> TermCollection 
Terms</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> {</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> (terms == 
</FONT><FONT color=#0000ff size=2>null</FONT><FONT size=2>)</DIV>
<DIV>terms = TermLifeTerm.GetTermsByPolicyId(</FONT><FONT color=#0000ff 
size=2>this</FONT><FONT size=2>.PolicyId, </FONT><FONT color=#0000ff 
size=2>this</FONT><FONT size=2>.Context);</DIV>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> terms; </DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> 
ConditionCollection Conditions</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</DIV></FONT><FONT size=2>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> (conditions == 
</FONT><FONT color=#0000ff size=2>null</FONT><FONT size=2>)</DIV>
<DIV>conditions = TermLifeCondition.GetConditionByPolicyId(</FONT><FONT 
color=#0000ff size=2>this</FONT><FONT size=2>.PolicyId, </FONT><FONT 
color=#0000ff size=2>this</FONT><FONT size=2>.Context);</DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> WholeLifePolicy : 
Entities.Policy</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> TermCollection 
Terms</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</DIV></FONT><FONT size=2>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> (terms == 
</FONT><FONT color=#0000ff size=2>null</FONT><FONT size=2>)</DIV>
<DIV>terms = WholeLifeTerm.GetTermsByPolicyId(</FONT><FONT color=#0000ff 
size=2>this</FONT><FONT size=2>.PolicyId, </FONT><FONT color=#0000ff 
size=2>this</FONT><FONT size=2>.Context);</DIV>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> terms;</DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> 
ConditionCollection Conditions</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</DIV></FONT><FONT size=2>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>if</FONT><FONT size=2> (conditions == 
</FONT><FONT color=#0000ff size=2>null</FONT><FONT size=2>)</DIV>
<DIV>conditions = WholeLifeCondition.GetConditionByPolicyId(</FONT><FONT 
color=#0000ff size=2>this</FONT><FONT size=2>.PolicyId, </FONT><FONT 
color=#0000ff size=2>this</FONT><FONT size=2>.Context);</DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Inheritance for Type Matching Only, </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> No 
Actual Behavior implementation here</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
favor using compositon, HAS-A relationships to fullfil </DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Whole Life Term specific implementation needs</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> WholeLifeTerm : Terms</DIV>
<DIV>{</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> Create Mapping 
Methods</FONT></DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> If 
you do not have a static factory creational pattern in the DAL, 
</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
like i posted in the forums</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
http://forum.codesmithtools.com/default.aspx?f=19&amp;p=1&amp;m=8534</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Posted 11/7/2005 7:52 PM (GMT -6)</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
(about<B></B><B></B><B></B> halfway down the page)</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Then you will have to map your entities to your Decorator 
Objects.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param 
name="t"&gt;&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 
size=2>&lt;returns&gt;&lt;/returns&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>static</FONT><FONT size=2> WholeLifeTerm 
Create(Entities.Term t)</DIV>
<DIV>{</DIV>
<DIV>WholeLifeTerm w = </FONT><FONT color=#0000ff size=2>new</FONT><FONT size=2> 
WholeLifeTerm();</DIV>
<DIV></FONT><FONT color=#0000ff size=2>this</FONT><FONT size=2>.termID = 
t.TermId;</DIV>
<DIV></FONT><FONT color=#0000ff size=2>this</FONT><FONT size=2>.specificTerm = 
GetSpecificTermFromSomewhere();</DIV>
<DIV></DIV>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> w;</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>static</FONT><FONT size=2> TermCollection Create 
(Entities.TermCollection terms)</DIV>
<DIV>{</DIV>
<DIV>TermCollection tc = </FONT><FONT color=#0000ff size=2>new</FONT><FONT 
size=2> TermCollection();</DIV>
<DIV></FONT><FONT color=#0000ff size=2>foreach</FONT><FONT size=2>(Term t 
</FONT><FONT color=#0000ff size=2>in</FONT><FONT size=2> terms)</DIV>
<DIV>c.Add(Create(t));</DIV>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> tc;</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> </FONT></DIV>
<DIV>&nbsp;</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> My 
Terms Data Access</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;param 
name="policyId"&gt;&lt;/param&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 
size=2>&lt;returns&gt;&lt;/returns&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>static</FONT><FONT size=2> Entities.TermsCollection 
GetTermsByPolicy(</FONT><FONT color=#0000ff size=2>int</FONT><FONT size=2> 
policyId)</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#008000 size=2>// having to map, because the 
NetTiers.DAL is being used as is out of the box.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// if we are creating and using 
inheritance for Type Matching, then you'll have to map to your business 
type</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// otherwise, if you use a creational 
factory in the DAL, then you can have those types be created when you 
</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// specify what type to 
create.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#008000 size=2>// More Info on creational factory 
pattern: See the summary in the Create Method above.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>return</FONT><FONT size=2> 
Create(DataRepository.TermsProvider.GetTermsByPolicyId(policyId));</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> MySpecificTerm 
SpecificTerm</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> { }</DIV>
<DIV></FONT><FONT color=#0000ff size=2>set</FONT><FONT size=2> { }</DIV>
<DIV>}</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#region</FONT><FONT size=2><FONT color=#000000> More Terms and Conditions - 
</FONT></DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Inheritance for Type Matching Only, </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> No 
Actual Behavior implementation here</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
favor using compositon, HAS-A relationships to </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
fullfil Whole Life Condition specific implementation needs</DIV></FONT><FONT 
size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> SEE 
IMPLEMENTATION ABOVE as it's the same but now dealing with 
Conditions.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> WholeLifeCondition : 
Conditions</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> 
MySpecificCondition SpecificCondition</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> { }</DIV>
<DIV></FONT><FONT color=#0000ff size=2>set</FONT><FONT size=2> { }</DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Inheritance for Type Matching Only, </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> No 
Actual Behavior implementation here</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
favor using compositon, HAS-A relationships to fullfil Term Life Term specific 
implementation needs</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> SEE 
IMPLEMENTATION ABOVE as it's the same but now dealing with 
Conditions.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> TermLifeTerm : Term</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> MySpecificTerm 
SpecificTerm</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> { }</DIV>
<DIV></FONT><FONT color=#0000ff size=2>set</FONT><FONT size=2> { } </DIV>
<DIV>}</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Inheritance for Type Matching Only, </DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> No 
Actual Behavior Implementation Here</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
favor using compositon, HAS-A relationships to fullfil term-life specific 
implementation needs</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> SEE 
IMPLEMENTATION ABOVE as it's the same but now dealing with 
Conditions.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> TermLIfeCondition : 
Condition</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> 
MySpecificCondition SpecificCondition</DIV>
<DIV>{</DIV>
<DIV></FONT><FONT color=#0000ff size=2>get</FONT><FONT size=2> { }</DIV>
<DIV></FONT><FONT color=#0000ff size=2>set</FONT><FONT size=2> { }</DIV>
<DIV>}</DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> </FONT></DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Basic Term, inherits from generated entity.</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> Term : Entities.Term</DIV>
<DIV>{</DIV>
<DIV>}</DIV>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
Basic Condition table, inherits from Entity.Condition</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#808080 size=2>///</FONT><FONT color=#008000 size=2> 
</FONT><FONT color=#808080 size=2>&lt;/summary&gt;</DIV></FONT><FONT size=2>
<DIV></FONT><FONT color=#0000ff size=2>public</FONT><FONT size=2> </FONT><FONT 
color=#0000ff size=2>class</FONT><FONT size=2> Condition : 
Entities.Condition</DIV>
<DIV>{ </DIV>
<DIV>}</DIV></FONT><FONT color=#0000ff size=2>
<DIV>#endregion</FONT><FONT size=2><FONT color=#000000> </FONT></DIV>
<DIV>}</DIV></FONT></DIV></DIV></CODE></DIV>
<P class=MsoNormal style="MARGIN: 0in 0in 0pt"></o:p></SPAN></QUOTE>
<DIV></DIV>
<P></P>
<P>
<HR align=left width="50%" SIZE=1>

<DIV>Robert</DIV>
<DIV>-------------------------------------<BR>&nbsp;Member of the .NetTiers 
team</DIV>
<DIV><A href="http://www.nettiers.com" 
target=_blank>http://www.nettiers.com</A><BR>------------------------------------- 

<P></P></DIV>
<P></P><!-- Edit -->
<P><I>Post Edited (Robert Hinojosa) : 11/11/2005 8:52:19 PM GMT</I></P><BR>
<TABLE class=tblStd id=Table1 cellSpacing=0 cellPadding=3 width="100%" 
  border=0></TABLE><BR><B>Fichier attaché : </B><BR><A 
href="http://forum.codesmithtools.com/attach.aspx?a=706" target=_blank>InsuranceFun.zip</A> &nbsp; 4KB 
(application/x-zip-compressed) 
<DIV class=msgXsm>Le fichier a été téléchargé 16 fois.</DIV>

</asp:Content>