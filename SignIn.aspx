<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SignIn.aspx.vb" Inherits="SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Login</title>
<link rel="shortcut icon" href="Images/favicon.ico" />
<link type="text/css" href="css/mystyle.css" rel="stylesheet"  />
<link type="text/css" href="css/reset.css" rel="stylesheet" />
<link type="text/css" href="css/module.css" rel="stylesheet" />
<link type="text/css" href="css/main.css" rel="stylesheet" />
<script type="text/javascript" src="scripts/jquery.min.js"></script>
<script type="text/javascript" src="Scripts/Disable_rightclick.js"></script>
<script type="text/javascript" src="Scripts/Footer.js"></script>
<script type="text/javascript" src="Scripts/Disable_BackButton.js"></script>
<script src="../../jquery.js" temp_src="jquery.js" type="text/javascript"></script>
<style>
.button {
    background-color: #4FA0F2; 
    padding: 2px 4px;
    font: 13px sans-serif;
    text-decoration: none;
    border: 1px solid #4FA0F2;
    border-color: #4FA0F2 #444 #444 #4FA0F2;
    color: white;
    font-size:14px;
    font-weight:bold
}
</style>


   

      <script language="javascript" type="text/javascript">
          var OAUTHURL = 'https://accounts.google.com/o/oauth2/auth?';
          var VALIDURL = 'https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=';
          var SCOPE = 'https://www.googleapis.com/auth/userinfo.profile https://www.googleapis.com/auth/userinfo.email';
          var CLIENTID = '909901386442-1mrujvob4p7bi7ftpa80vb7uk3puhotc.apps.googleusercontent.com';
          var REDIRECT = 'https://ipcservices.bits-pilani.ac.in/BAS';
          var LOGOUT = 'http://accounts.google.com/Logout';
          var TYPE = 'token';
          var _url = OAUTHURL + 'scope=' + SCOPE + '&client_id=' + CLIENTID + '&redirect_uri=' + REDIRECT + '&response_type=' + TYPE;
          var acToken;
          var tokenType;
          var expiresIn;
          var user;
          var loggedIn = false;

          function login() {
              var win = window.open(_url, "windowname1", 'width=800, height=600');
              var pollTimer = window.setInterval(function () {
                  try {
                      console.log(win.document.URL);
                      if (win.document.URL.indexOf(REDIRECT) != -1) {
                          window.clearInterval(pollTimer);
                          var url = win.document.URL;
                          acToken = gup(url, 'access_token');
                          tokenType = gup(url, 'token_type');
                          expiresIn = gup(url, 'expires_in');
                          win.close();
                          validateToken(acToken);

                      }
                  } catch (e) {
                  }
              }, 500);
          }

          gapi.client.load('oauth2', 'v2', function () {
              gapi.client.oauth2.userinfo.get()
                .execute(function (resp) {
                    // Shows user email
                    console.log(resp.email);
                });
          });


          function validateToken(token) {
              $.ajax({
                  url: VALIDURL + token,
                  data: null,
                  success: function (responseText) {
                      getUserInfo();
                      loggedIn = true;
                      $('#loginText').hide();
                      $('#myEmail').hide();
                      $('#linkPage').show();
                      $('#logoutText').show();
                  },
                  dataType: "jsonp"
              });
          }


          function getUserInfo() {
              $.ajax({
                  url: 'https://www.googleapis.com/oauth2/v1/userinfo?access_token=' + acToken,
                  data: null,
                  success: function (resp) {
                      user = resp;
                      console.log(user);
                      //$('#lblName').text('Welcome ' + user.name + ', Please click here for get access');

                      $('#lblName').text(user.name);
                      $('#lblEmail').text(user.email);

                      //Check BITS Pilani
                      var domain_matche = /@(.*)$/.exec(user.email);
                      var domain_name = domain_matche[1].substring(0, domain_matche[1].indexOf(".", 0))
                      if (domain_name == "gmail") {
                          loggedIn = false;
                          $('#loginText').hide();
                          $('#myEmail').hide();
                          $('#linkPage').hide();
                          $('#logoutText').hide();
                          // alert("not a valid email");
                          window.location = "mailerror.aspx";
                      }
                      //End Check BITS Pilani

                      //                   document.getElementById("lblName").innerHTML = user.name;
                      //                    document.getElementById("lblEmail").innerHTML = user.email;


                      var myvar = user.name;
                      var myvar1 = user.email;
                      $("#<%= HiddenField1.ClientID%>").val(user.name);
                      $("#<%= HiddenField2.ClientID%>").val(user.email);






                      $.ajax({
                          type: "POST",
                          url: "dashboard.aspx/addSession",
                          data: "{'name':'" + myvar + "','email':'" + myvar1 + "'}",
                          contentType: "application/json; charset=utf-8",
                          dataType: "json",
                          success: function (msg) {
                              // alert("Working");
                          },
                          error: function (err) {
                              //alert("Not Working");
                          }
                      });




                      //                    $('#imgHolder').attr('src', user.picture);
                  },
                  dataType: "jsonp"
              });
          }
          //credits: http://www.netlobo.com/url_query_string_javascript.html
          function gup(url, name) {
              name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
              var regexS = "[\\#&]" + name + "=([^&#]*)";
              var regex = new RegExp(regexS);
              var results = regex.exec(url);
              if (results == null)
                  return "";
              else
                  return results[1];
          }
          function startLogoutPolling() {
              $('#loginText').show();
              $('#myEmail').show();
              $('#linkPage').hide();
              $('#logoutText').hide();
              loggedIn = false;
              $('#uName').text('Welcome ');
              $('#imgHolder').attr('src', 'none.jpg');
          }

    </script>

</head>
<body>
    <form id="form1" runat="server">
     <div id="main" align="center">
        <table id="t1" border="0" cellpadding="0" cellspacing="0" width="100% "
            bgcolor="White">
             <tr>
                <td>
                    <div id="Div1" align="left">
                        <div class="headerWrapper">
                            <div class="headerWrapperFix">
                                <h1 class="hidden">
                                    BITS Pilani Goa Campus</h1>
                                <div class="logoWrapper">
                                    <a href="http://universe.bits-pilani.ac.in/Pilani"target="_new">
                                        <img src="Images/BITS_Pilani_campus_logo.gif" alt="BITS Pilani Pilani Campus" />
                                    </a>
                                    
                                </div>
                                 
                               
                              <ul class="siteInfo" style="right: 110px; width: 360px; top: 20px; height: 60px">
                                    <li style="width: 435px">
                                        <p class="siteLog" style="text-align: center">
                                            <span style="font-size: 1.1em"><span style="font-size: 0.8em">BITS Approval System</span> </span>
                                        </p>
                                    </li>
                                </ul>

                               

                                <ul class="commonNav">
                                    <li><a href="http://universe.bits-pilani.ac.in/" target="_blank">University Home</a></li>
                                    <li><a href="http://universe.bits-pilani.ac.in/Pilani" target="_blank">Pilani Campus Home </a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%" style="height: 300px">
                        <tr>
                            <td id="contentpane" style="width: 100%; vertical-align: top">
                                <div align="center">
                                    <br /><br />
    <div align="center">
<table border="0" id="table_attendance_details" cellpadding="0" width="80%" cellspacing="0" >
    <tbody>

         <tr><td style="height:90px"></td></tr>

      

		<tr valign="top">
			<td class="head_already" style="height: 30px"> <div style="text-align: center">
			 <span>Department / Division / Unit / Centre Login</span></div>
			 </td>
		</tr>
	</tbody>
	</table><br />
    </div>

                                <!--
                                 <div style="text-align: right"> 
                                 <a href="#" temp_href="#" style="display:none; font-size: 16px; color: Blue; font-weight: bold; " id="logoutText" target='myIFrame' onclick="myIFrame.location='https://www.google.com/accounts/Logout'; startLogoutPolling();return false;"> Click here to logout </a>
                                 </div>
                                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Log in using your BITS Pilani, Email Account" style="height: 35px;width:450px" />
                                -->

                         <input onClick='login();' id="loginText"' type="button" 
                            value="Log in using your BITS Pilani, Email Account" align="middle" 
                            style="border-style: outset; height: 30px" />
                        
                         <iframe name='myIFrame' id="myIFrame" style='display:none'></iframe><br /><br />
                        
                         <div id="myEmail"><span style="font-size:16px">Example : <em>xyz@pilani.bits-pilani.ac.in</em></span></div>

    
                          <br />
                                <div align="center">
                                <asp:Button ID="linkPage" runat="server" Text="Please click here to Continue" style="display: none;font-size: 14px;" Width="600px"></asp:Button>
                                    <asp:Button ID="Button2" runat="server" Text="Button" />
                               </div>

                         
                            <br /><br />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                              <asp:HiddenField ID="HiddenField2" runat="server" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
        </table>
    </div>
         <footer id="webfooter">
                    <div class="footerWrapper">
                    </div>
                    <div id="Div2" align="left">
                        <div class="cpInfoFixWrapper">
                            <div class="cpInfoFix">
                                <p class="info">
                                    An institution deemed to be a University estd. vide Sec.3 of the UGC Act,1956 under
                                    notification # F.12-23/63.U-2 of Jun 18,1964
                                </p>
                                <p>
                                    &copy; 2021 Centre for Software Development,SDET Unit, BITS-Pilani (Pilani Campus)
                                </p>
                               
                            </div>
                        </div></div>
                     </footer> 
    </form>
</body>
</html>