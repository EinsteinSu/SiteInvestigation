;#DropDB SiteInvestigationEasyTest

#Application SiteInvestigationWin
#Application SiteInvestigationWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef SiteInvestigationWin

*Action About...
 
*Action OK

#EndIf

#IfDef SiteInvestigationWeb
*Action Navigation(My Details)
#EndIf
