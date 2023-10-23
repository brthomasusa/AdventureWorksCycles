ë
\/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Components/BasicGrid.razor.cs
	namespace 	
AWC
 
. 
Client 
. 

Components 
{ 
public 

partial 
class 
	BasicGrid "
<" #
TItem# (
>( )
{ 
[ 	
	Parameter	 
] 
public 
RenderFragment )
?) *
TableHeader+ 6
{7 8
get9 <
;< =
set> A
;A B
}C D
[ 	
	Parameter	 
] 
public 
RenderFragment )
<) *
TItem* /
>/ 0
?0 1
RowTemplate2 =
{> ?
get@ C
;C D
setE H
;H I
}J K
[		 	
	Parameter			 
]		 
public		 
RenderFragment		 )
?		) *
TableFooter		+ 6
{		7 8
get		9 <
;		< =
set		> A
;		A B
}		C D
[

 	
	Parameter

	 
]

 
public

 
IReadOnlyList

 (
<

( )
TItem

) .
>

. /
?

/ 0
Items

1 6
{

7 8
get

9 <
;

< =
set

> A
;

A B
}

C D
} 
} À
U/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/DependencyInjection.cs
	namespace 	
AWC
 
. 
Client 
{ 
public		 

static		 
class		 
DependencyInjection		 +
{

 
public 
static 
IServiceCollection (
AddMappings) 4
(4 5
this5 9
IServiceCollection: L
servicesM U
)U V
{ 	
var 
config 
= 
TypeAdapterConfig *
.* +
GlobalSettings+ 9
;9 :
config 
. 
Scan 
( 
Assembly  
.  ! 
GetExecutingAssembly! 5
(5 6
)6 7
)7 8
;8 9
config 
. 
Default 
.  
NameMatchingStrategy /
(/ 0 
NameMatchingStrategy0 D
.D E

IgnoreCaseE O
)O P
;P Q
services 
. 
AddSingleton !
(! "
config" (
)( )
;) *
services 
. 
	AddScoped 
< 
IMapper &
,& '
ServiceMapper( 5
>5 6
(6 7
)7 8
;8 9
return 
services 
; 
} 	
public 
static 
IServiceCollection (
AddFluentValidation) <
(< =
this= A
IServiceCollectionB T
servicesU ]
)] ^
{ 	
services 
. %
AddValidatorsFromAssembly .
(. /
typeof/ 5
(5 6
App6 9
)9 :
.: ;
Assembly; C
)C D
;D E
return 
services 
; 
} 	
public 
static 
IServiceCollection (
	AddFluxor) 2
(2 3
this3 7
IServiceCollection8 J
servicesK S
)S T
{ 	
var   
currentAssembly   
=    !
typeof  " (
(  ( )
Program  ) 0
)  0 1
.  1 2
Assembly  2 :
;  : ;
services!! 
.!! 
	AddFluxor!! 
(!! 
options!! &
=>!!' )
{"" 
options## 
.## 
ScanAssemblies## &
(##& '
currentAssembly##' 6
)##6 7
;##7 8
options%% 
.%% 
UseReduxDevTools%% (
(%%( )
)%%) *
;%%* +
}'' 
)'' 
;'' 
return)) 
services)) 
;)) 
}** 	
}++ 
},, ûû
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/CreateWorker/Pages/CreateWorkerDialog.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
CreateWorker- 9
.9 :
Pages: ?
{ 
public 

partial 
class 
CreateWorkerDialog +
:, -
ComponentBase. ;
{ 
private 
static 
IEnumerable "
<" #
MaritalStatuses# 2
>2 3
MaritalStatuses4 C
=>D F
SimpleLookupsG T
.T U
GetMaritalStatusesU g
(g h
)h i
;i j
private 
static 
IEnumerable "
<" #
Gender# )
>) *
Genders+ 2
=>3 5
SimpleLookups6 C
.C D

GetGendersD N
(N O
)O P
;P Q
private 
static 
IEnumerable "
<" #
	NameStyle# ,
>, -

NameStyles. 8
=>9 ;
SimpleLookups< I
.I J
GetNameStylesJ W
(W X
)X Y
;Y Z
private 
static 
IEnumerable "
<" #$
EmailPromotionPreference# ;
>; <%
EmailPromotionPreferences= V
=>W Y
SimpleLookupsZ g
.g h(
GetEmailPromotionPreference	h É
(
É Ñ
)
Ñ Ö
;
Ö Ü
private 
static 
IEnumerable "
<" #
PhoneNumberType# 2
>2 3
PhoneNumberTypes4 D
=>E G
SimpleLookupsH U
.U V
GetPhoneNumberTypesV i
(i j
)j k
;k l
private 
static 
IEnumerable "
<" #
PayFrequency# /
>/ 0
PayFrequencies1 ?
=>@ B
SimpleLookupsC P
.P Q
GetPayFrequenciesQ b
(b c
)c d
;d e
private 
static 
IEnumerable "
<" #
SalariedFlag# /
>/ 0
SalariedFlags1 >
=>? A
SimpleLookupsB O
.O P
GetSalariedFlagsP `
(` a
)a b
;b c
private 
const 
int 

UNSELECTED $
=% &
-' (
$num( )
;) *
private 
double 
payRate 
; 
private 
int 
payFrequency  
=! "

UNSELECTED# -
;- .
private 
int 
shiftId 
; 
private 
int 
departmentId  
;  !
private "
EmployeeGenericCommand &
employee' /
=0 1
new2 5
(5 6
)6 7
;7 8
private 
List 
< 
DepartmentId !
>! "
?" #
departments$ /
;/ 0
private   
List   
<   
	ManagerId   
>   
?    
managers  ! )
;  ) *
private!! 
List!! 
<!! 
ShiftId!! 
>!! 
?!! 
shifts!! %
;!!% &
private"" 
List"" 
<"" 
	StateCode"" 
>"" 
?""  

stateCodes""! +
;""+ ,
[$$ 	
Inject$$	 
]$$ 
private$$ 
DialogService$$ &
?$$& '
DialogService$$( 5
{$$6 7
get$$8 ;
;$$; <
set$$= @
;$$@ A
}$$B C
[%% 	
Inject%%	 
]%% 
private%% 
NotificationService%% ,
?%%, -
NotificationService%%. A
{%%B C
get%%D G
;%%G H
set%%I L
;%%L M
}%%N O
[&& 	
Inject&&	 
]&& 
private&& &
IEmployeeRepositoryService&& 3
?&&3 4
EmployeeRepository&&5 G
{&&H I
get&&J M
;&&M N
set&&O R
;&&R S
}&&T U
['' 	
Inject''	 
]'' 
private'' %
ICompanyRepositoryService'' 2
?''2 3
CompanyRepository''4 E
{''F G
get''H K
;''K L
set''M P
;''P Q
}''R S
	protected)) 
override)) 
async))  
Task))! %
OnInitializedAsync))& 8
())8 9
)))9 :
{** 	
await++ 
LoadLookups++ 
(++ 
)++ 
;++   
LoadEmployeeDefaults,,  
(,,  !
),,! "
;,," #
await.. 
base.. 
... 
OnInitializedAsync.. )
(..) *
)..* +
;..+ ,
}// 	
	protected11 
async11 
Task11 
LoadLookups11 (
(11( )
)11) *
{22 	
Result33 
<33 
List33 
<33 
DepartmentId33 $
>33$ %
>33% &
departmentResult33' 7
=338 9
await33: ?
CompanyRepository33@ Q
!33Q R
.33R S
GetDepartmentIDs33S c
(33c d
)33d e
;33e f
if44 
(44 
departmentResult44  
.44  !
	IsFailure44! *
)44* +
{55 !
ShowErrorNotification66 %
.66% &
	ShowError66& /
(66/ 0
NotificationService77 '
!77' (
,77( )
departmentResult88 $
.88$ %
Error88% *
.88* +
Message88+ 2
)99 
;99 
}:: 
departments<< 
=<< 
departmentResult<< *
.<<* +
Value<<+ 0
;<<0 1
Result>> 
<>> 
List>> 
<>> 
	ManagerId>> !
>>>! "
>>>" #
managerResult>>$ 1
=>>2 3
await>>4 9
EmployeeRepository>>: L
!>>L M
.>>M N
GetManagerIDs>>N [
(>>[ \
)>>\ ]
;>>] ^
if?? 
(?? 
managerResult?? 
.?? 
	IsFailure?? '
)??' (
{@@ !
ShowErrorNotificationAA %
.AA% &
	ShowErrorAA& /
(AA/ 0
NotificationServiceBB '
!BB' (
,BB( )
managerResultCC !
.CC! "
ErrorCC" '
.CC' (
MessageCC( /
)DD 
;DD 
}EE 
managersGG 
=GG 
managerResultGG $
.GG$ %
ValueGG% *
;GG* +
ResultII 
<II 
ListII 
<II 
ShiftIdII 
>II  
>II  !
shiftResultII" -
=II. /
awaitII0 5
CompanyRepositoryII6 G
!IIG H
.IIH I
GetShiftIDsIII T
(IIT U
)IIU V
;IIV W
ifJJ 
(JJ 
shiftResultJJ 
.JJ 
	IsFailureJJ %
)JJ% &
{KK !
ShowErrorNotificationLL %
.LL% &
	ShowErrorLL& /
(LL/ 0
NotificationServiceMM '
!MM' (
,MM( )
shiftResultNN 
.NN  
ErrorNN  %
.NN% &
MessageNN& -
)OO 
;OO 
}PP 
shiftsRR 
=RR 
shiftResultRR  
.RR  !
ValueRR! &
;RR& '
ResultTT 
<TT 
ListTT 
<TT 
	StateCodeTT !
>TT! "
>TT" #
stateCodeResultTT$ 3
=TT4 5
awaitTT6 ;
EmployeeRepositoryTT< N
!TTN O
.TTO P
GetStateCodesTTP ]
(TT] ^
)TT^ _
;TT_ `
ifUU 
(UU 
stateCodeResultUU 
.UU  
	IsFailureUU  )
)UU) *
{VV !
ShowErrorNotificationWW %
.WW% &
	ShowErrorWW& /
(WW/ 0
NotificationServiceXX '
!XX' (
,XX( )
stateCodeResultYY #
.YY# $
ErrorYY$ )
.YY) *
MessageYY* 1
)ZZ 
;ZZ 
}[[ 

stateCodes]] 
=]] 
stateCodeResult]] (
.]]( )
Value]]) .
;]]. /
}^^ 	
private`` 
void``  
LoadEmployeeDefaults`` )
(``) *
)``* +
{aa 	
employeebb 
.bb 
	NameStylebb 
=bb  

UNSELECTEDbb! +
;bb+ ,
employeecc 
.cc 
PhoneNumberTypeIDcc &
=cc' (

UNSELECTEDcc) 3
;cc3 4
employeedd 
.dd 
EmailPromotiondd #
=dd$ %

UNSELECTEDdd& 0
;dd0 1
employeeee 
.ee 
VacationHoursee "
=ee# $
-ee% &
$numee& (
;ee( )
employeeff 
.ff 
SickLeaveHoursff #
=ff$ %

UNSELECTEDff& 0
;ff0 1
employeegg 
.gg 
Activegg 
=gg 
truegg "
;gg" #
}hh 	
	protectedjj 
asyncjj 
Taskjj 

FormSubmitjj '
(jj' (
)jj( )
{kk 	
tryll 
{mm  
AddDepartmentHistorynn $
(nn$ %
)nn% &
;nn& '
AddPayHistoryoo 
(oo 
)oo 
;oo  
Resultqq 
<qq 
intqq 
>qq 
resultqq "
=qq# $
awaitqq% *
EmployeeRepositoryqq+ =
!qq= >
.qq> ?
CreateEmployeeqq? M
(qqM N
employeeqqN V
)qqV W
;qqW X
ifss 
(ss 
resultss 
.ss 
	IsSuccessss $
)ss$ %
{tt 
DialogServiceuu !
!uu! "
.uu" #
Closeuu# (
(uu( )
employeeuu) 1
)uu1 2
;uu2 3
}vv 
elseww 
{xx !
ShowErrorNotificationyy )
.yy) *
	ShowErroryy* 3
(yy3 4
NotificationServicezz +
!zz+ ,
,zz, -
result{{ 
.{{ 
Error{{ $
.{{$ %
Message{{% ,
)|| 
;|| 
}}} 
} 
catch
ÄÄ 
(
ÄÄ 
System
ÄÄ 
.
ÄÄ 
	Exception
ÄÄ #
ex
ÄÄ$ &
)
ÄÄ& '
{
ÅÅ #
ShowErrorNotification
ÇÇ %
.
ÇÇ% &
	ShowError
ÇÇ& /
(
ÇÇ/ 0!
NotificationService
ÉÉ '
!
ÉÉ' (
,
ÉÉ( )
Helpers
ÑÑ 
.
ÑÑ !
GetExceptionMessage
ÑÑ /
(
ÑÑ/ 0
ex
ÑÑ0 2
)
ÑÑ2 3
)
ÖÖ 
;
ÖÖ 
}
ÜÜ 
}
áá 	
	protected
ââ 
void
ââ %
CloseCreateWorkerDialog
ââ .
(
ââ. /
)
ââ/ 0
=>
ää 
DialogService
ää 
!
ää 
.
ää 
Close
ää #
(
ää# $
null
ää$ (
)
ää( )
;
ää) *
private
åå 
void
åå 
OnShiftChanged
åå #
(
åå# $
object
åå$ *
value
åå+ 0
)
åå0 1
{
çç 	
Console
éé 
.
éé 
	WriteLine
éé 
(
éé 
$"
éé  
$str
éé  2
{
éé2 3
value
éé3 8
.
éé8 9
ToJson
éé9 ?
(
éé? @
)
éé@ A
}
ééA B
$str
ééB M
{
ééM N
shiftId
ééN U
}
ééU V
"
ééV W
)
ééW X
;
ééX Y
}
èè 	
private
ëë 
static
ëë 
bool
ëë 
ValidateBirthday
ëë ,
(
ëë, -
DateTime
ëë- 5
	birthdate
ëë6 ?
)
ëë? @
{
íí 	
return
ìì 
	birthdate
ìì 
>=
ìì 
new
ìì  #
DateTime
ìì$ ,
(
ìì, -
$num
ìì- 1
,
ìì1 2
$num
ìì3 4
,
ìì4 5
$num
ìì6 7
,
ìì7 8
$num
ìì9 :
,
ìì: ;
$num
ìì< =
,
ìì= >
$num
ìì? @
,
ìì@ A
DateTimeKind
ììB N
.
ììN O
Local
ììO T
)
ììT U
&&
ììV X
	birthdate
îî 
<=
îî 
DateTime
îî  (
.
îî( )
Today
îî) .
.
îî. /
AddYears
îî/ 7
(
îî7 8
-
îî8 9
$num
îî9 ;
)
îî; <
;
îî< =
}
ññ 	
private
òò 
static
òò 
bool
òò 
ValidateHireDate
òò ,
(
òò, -
DateTime
òò- 5
hireDate
òò6 >
)
òò> ?
{
ôô 	
return
öö 
hireDate
öö 
>=
öö 
new
öö "
DateTime
öö# +
(
öö+ ,
$num
öö, 0
,
öö0 1
$num
öö2 3
,
öö3 4
$num
öö5 6
,
öö6 7
$num
öö8 9
,
öö9 :
$num
öö; <
,
öö< =
$num
öö> ?
,
öö? @
DateTimeKind
ööA M
.
ööM N
Local
ööN S
)
ööS T
&&
ööU W
hireDate
õõ 
<=
õõ 
DateTime
õõ '
.
õõ' (
Today
õõ( -
.
õõ- .
AddDays
õõ. 5
(
õõ5 6
$num
õõ6 7
)
õõ7 8
;
õõ8 9
}
úú 	
private
ûû 
bool
ûû %
ValidateSelectedManager
ûû ,
(
ûû, -
int
ûû- 0
	managerId
ûû1 :
)
ûû: ;
{
üü 	
	ManagerId
†† 
?
†† 
mgr
†† 
=
†† 
managers
†† %
!
††% &
.
††& '
Find
††' +
(
††+ ,
m
††, -
=>
††. 0
m
††1 2
.
††2 3
BusinessEntityID
††3 C
==
††D F
	managerId
††G P
)
††P Q
;
††Q R
return
¢¢ 
mgr
¢¢ 
is
¢¢ 
not
¢¢ 
null
¢¢ "
;
¢¢" #
}
££ 	
private
•• 
bool
•• *
ValidateSelectedDepartmentID
•• 1
(
••1 2
int
••2 5
departmentId
••6 B
)
••B C
{
¶¶ 	
DepartmentId
ßß 
?
ßß 

department
ßß $
=
ßß% &
departments
ßß' 2
!
ßß2 3
.
ßß3 4
Find
ßß4 8
(
ßß8 9
d
ßß9 :
=>
ßß; =
d
ßß> ?
.
ßß? @
DepartmentID
ßß@ L
==
ßßM O
departmentId
ßßP \
)
ßß\ ]
;
ßß] ^
return
©© 

department
©© 
is
©©  
not
©©! $
null
©©% )
;
©©) *
}
™™ 	
private
¨¨ 
bool
¨¨ 8
*ValidateManagerAndEmployeeInSameDepartment
¨¨ ?
(
¨¨? @
int
¨¨@ C
	managerId
¨¨D M
,
¨¨M N
int
¨¨O R
departmentId
¨¨S _
)
¨¨_ `
{
≠≠ 	
	ManagerId
ÆÆ 
?
ÆÆ 
mgr
ÆÆ 
=
ÆÆ 
managers
ÆÆ %
!
ÆÆ% &
.
ÆÆ& '
Find
ÆÆ' +
(
ÆÆ+ ,
m
ÆÆ, -
=>
ÆÆ. 0
m
ÆÆ1 2
.
ÆÆ2 3
BusinessEntityID
ÆÆ3 C
==
ÆÆD F
	managerId
ÆÆG P
&&
ÆÆQ S
m
ØØ1 2
.
ØØ2 3
DepartmentID
ØØ3 ?
==
ØØ@ B
departmentId
ØØC O
)
ØØO P
;
ØØP Q
return
±± 
mgr
±± 
is
±± 
not
±± 
null
±± "
;
±±" #
}
≤≤ 	
private
¥¥ 
bool
¥¥ %
ValidateSelectedShiftID
¥¥ ,
(
¥¥, -
int
¥¥- 0
shiftId
¥¥1 8
)
¥¥8 9
{
µµ 	
ShiftId
∂∂ 
?
∂∂ 
shift
∂∂ 
=
∂∂ 
shifts
∂∂ #
!
∂∂# $
.
∂∂$ %
Find
∂∂% )
(
∂∂) *
d
∂∂* +
=>
∂∂, .
d
∂∂/ 0
.
∂∂0 1
ShiftID
∂∂1 8
==
∂∂9 ;
shiftId
∂∂< C
)
∂∂C D
;
∂∂D E
return
∏∏ 
shift
∏∏ 
is
∏∏ 
not
∏∏ 
null
∏∏  $
;
∏∏$ %
}
ππ 	
private
ªª 
bool
ªª '
ValidateSelectedStateCode
ªª .
(
ªª. /
int
ªª/ 2
stateProvinceId
ªª3 B
)
ªªB C
{
ºº 	
	StateCode
ΩΩ 
?
ΩΩ 
	stateCode
ΩΩ  
=
ΩΩ! "

stateCodes
ΩΩ# -
!
ΩΩ- .
.
ΩΩ. /
Find
ΩΩ/ 3
(
ΩΩ3 4
s
ΩΩ4 5
=>
ΩΩ6 8
s
ΩΩ9 :
.
ΩΩ: ;
StateProvinceID
ΩΩ; J
==
ΩΩK M
stateProvinceId
ΩΩN ]
)
ΩΩ] ^
;
ΩΩ^ _
return
øø 
	stateCode
øø 
is
øø 
not
øø  #
null
øø$ (
;
øø( )
}
¿¿ 	
private
¬¬ 
static
¬¬ 
bool
¬¬ &
ValidateNationalIdNumber
¬¬ 4
(
¬¬4 5
string
¬¬5 ;

nationalId
¬¬< F
)
¬¬F G
{
√√ 	
Regex
ƒƒ 
regex
ƒƒ 
=
ƒƒ 
nationalIdRegex
ƒƒ )
(
ƒƒ) *
)
ƒƒ* +
;
ƒƒ+ ,
Match
≈≈ 
match
≈≈ 
=
≈≈ 
regex
≈≈ 
.
≈≈  
Match
≈≈  %
(
≈≈% &

nationalId
≈≈& 0
??
≈≈1 3
string
≈≈4 :
.
≈≈: ;
Empty
≈≈; @
)
≈≈@ A
;
≈≈A B
return
«« 
match
«« 
.
«« 
Success
««  
;
««  !
}
»» 	
[
   	
GeneratedRegex
  	 
(
   
$str
   $
)
  $ %
]
  % &
private
ÀÀ 
static
ÀÀ 
partial
ÀÀ 
Regex
ÀÀ $
nationalIdRegex
ÀÀ% 4
(
ÀÀ4 5
)
ÀÀ5 6
;
ÀÀ6 7
private
ÕÕ 
void
ÕÕ "
AddDepartmentHistory
ÕÕ )
(
ÕÕ) *
)
ÕÕ* +
{
ŒŒ 	
employee
œœ 
.
œœ !
DepartmentHistories
œœ (
=
œœ) *
new
œœ+ .
(
œœ. /
)
œœ/ 0
{
–– 
new
—— &
DepartmentHistoryCommand
—— ,
(
——, -
)
——- .
{
““ 
BusinessEntityID
”” $
=
””% &
$num
””' (
,
””( )
DepartmentID
‘‘  
=
‘‘! "
departmentId
‘‘# /
,
‘‘/ 0
ShiftID
’’ 
=
’’ 
shiftId
’’ %
,
’’% &
	StartDate
÷÷ 
=
÷÷ 
employee
÷÷  (
.
÷÷( )
HireDate
÷÷) 1
}
◊◊ 
}
ÿÿ 
;
ÿÿ 
}
ŸŸ 	
private
€€ 
void
€€ 
AddPayHistory
€€ "
(
€€" #
)
€€# $
{
‹‹ 	
employee
›› 
.
›› 
PayHistories
›› !
=
››" #
new
››$ '
(
››' (
)
››( )
{
ﬁﬁ 
new
ﬂﬂ 
PayHistoryCommand
ﬂﬂ %
(
ﬂﬂ% &
)
ﬂﬂ& '
{
‡‡ 
BusinessEntityID
·· $
=
··% &
$num
··' (
,
··( )
RateChangeDate
‚‚ "
=
‚‚# $
employee
‚‚% -
.
‚‚- .
HireDate
‚‚. 6
,
‚‚6 7
Rate
„„ 
=
„„ 
(
„„ 
decimal
„„ #
)
„„# $
payRate
„„$ +
,
„„+ ,
PayFrequency
‰‰  
=
‰‰! "
payFrequency
‰‰# /
}
ÂÂ 
}
ÊÊ 
;
ÊÊ 
}
ÁÁ 	
}
ËË 
}ÈÈ ™,
ì/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Pages/UpdateCompanyDetailsPage.razor.cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Features

 
.

 
HumanResources

 ,
.

, - 
UpdateCompanyDetails

- A
.

A B
Pages

B G
{ 
public 

partial 
class $
UpdateCompanyDetailsPage 1
{ 
[ 	
Inject	 
] 
private 
IState 
<  %
UpdateCompanyDetailsState  9
>9 :
?: ;%
UpdateCompanyDetailsState< U
{V W
getX [
;[ \
set] `
;` a
}b c
[ 	
Inject	 
] 
private 
IDispatcher $
?$ %

Dispatcher& 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
[ 	
Inject	 
] 
private 
NavigationManager *
?* +

NavManager, 6
{7 8
get9 <
;< =
set> A
;A B
}C D
[ 	
Inject	 
] 
	protected 
NotificationService .
?. /
NotificationService0 C
{D E
getF I
;I J
setK N
;N O
}P Q
private 
bool 
Loading 
=> %
UpdateCompanyDetailsState  9
!9 :
.: ;
Value; @
.@ A
LoadingA H
;H I
private 
readonly 
Variant  
variant! (
=) *
Variant+ 2
.2 3
Filled3 9
;9 :
	protected 
override 
void 
OnInitialized  -
(- .
). /
{ 	
if 
( 
! %
UpdateCompanyDetailsState *
!* +
.+ ,
Value, 1
.1 2

StateCodes2 <
!< =
.= >
Any> A
(A B
)B C
)C D
{ 

Dispatcher 
! 
. 
Dispatch $
($ %
new% ( 
LoadStateCodesAction) =
(= >
)> ?
)? @
;@ A
} 
if 
( 
! %
UpdateCompanyDetailsState *
!* +
.+ ,
Value, 1
.1 2
Initialized2 =
)= >
{ 

Dispatcher 
! 
. 
Dispatch $
($ %
new% (.
"LoadCompanyDetailsForEditingAction) K
(K L%
UpdateCompanyDetailsStateL e
!e f
.f g
Valueg l
.l m
	CompanyIDm v
)v w
)w x
;x y
}   
base"" 
."" 
OnInitialized"" 
("" 
)""  
;""  !
}## 	
private%% 
void%% 
OnValidSubmit%% "
(%%" #
)%%# $
{&& 	

Dispatcher'' 
!'' 
.'' 
Dispatch''  
(''  !
new''! $,
 UpdateCompanyDetailsSubmitAction''% E
(''E F%
UpdateCompanyDetailsState''F _
!''_ `
.''` a
Value''a f
.''f g
CommandModel''g s
!''s t
)''t u
)''u v
;''v w

NavManager(( 
!(( 
.(( 

NavigateTo(( "
(((" #
$str((# k
)((k l
;((l m
})) 	
private++ 
void++ 
OnInvalidSubmit++ $
(++$ %
)++% &
{,, 	
NotificationService-- 
!--  
.--  !
Notify--! '
(--' (
new.. 
NotificationMessage.. '
{// 
Severity00 
=00  
NotificationSeverity00 3
.003 4
Error004 9
,009 :
Style11 
=11 
$str11 W
,11W X
Detail22 
=22 
$str22 I
,22I J
Duration33 
=33 
$num33 #
}44 
)55 
;55 
}66 	
private88 
void88 
OnCancelEdit88 !
(88! "
MouseEventArgs88" 0
_881 2
)882 3
{99 	

Dispatcher:: 
!:: 
.:: 
Dispatch::  
(::  !
new::! $)
SetUpdateInitializeFlagAction::% B
(::B C
false::C H
)::H I
)::I J
;::J K

NavManager;; 
!;; 
.;; 

NavigateTo;; "
(;;" #
$str;;# k
);;k l
;;;l m
}<< 	
private>> 
static>> 
bool>> 
ValidateEIN>> '
(>>' (
string>>( .
ein>>/ 2
)>>2 3
{?? 	
return@@ 
EinRegex@@ 
(@@ 
)@@ 
.@@ 
IsMatch@@ %
(@@% &
ein@@& )
)@@) *
;@@* +
}AA 	
[CC 	
GeneratedRegexCC	 
(CC 
$strCC 0
)CC0 1
]CC1 2
privateDD 
staticDD 
partialDD 
RegexDD $
EinRegexDD% -
(DD- .
)DD. /
;DD/ 0
}EE 
}FF ·
ó/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/LoadCompanyDetailsForEditingAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record .
"LoadCompanyDetailsForEditingAction ;
(; <
int< ?
	CompanyID@ I
)I J
;J K
} ı
â/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/LoadStateCodesAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record  
LoadStateCodesAction -
(- .
int. 1$
SuppressSonarqubeWarning2 J
=K L
$numM N
)N O
;O P
} Ÿ
ê/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/LoadStateCodesFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record '
LoadStateCodesFailureAction 4
(4 5
string5 ;
ErrorMessage< H
)H I
;I J
} ô
ê/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/LoadStateCodesSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record '
LoadStateCodesSuccessAction 4
(4 5
List5 9
<9 :
	StateCode: C
>C D
?D E

StateCodesF P
)P Q
;Q R
} ı
â/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/SetLoadingFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record  
SetLoadingFlagAction -
(- .
int. 1$
SuppressSonarqubeWarning2 J
=K L
$numM N
)N O
;O P
} ‹
í/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/SetUpdateInitializeFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record )
SetUpdateInitializeFlagAction 6
(6 7
bool7 ;
IsInitialized< I
)I J
;J K
} ˘Y
ê/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsEffects.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
class '
UpdateCompanyDetailsEffects 3
:4 5
Effect6 <
<< =.
"LoadCompanyDetailsForEditingAction= _
>_ `
{ 
private 
readonly 
GrpcChannel $
_channel% -
;- .
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
NotificationService , 
_notificationService- A
;A B
public '
UpdateCompanyDetailsEffects *
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
NotificationService 
notificationService  3
) 	
{ 	
_channel 
= 
channel 
; 
_mapper 
= 
mapper 
;  
_notificationService  
=! "
notificationService# 6
;6 7
}   	
["" 	
EffectMethod""	 
("" 
typeof"" 
(""  
LoadStateCodesAction"" 1
)""1 2
)""2 3
]""3 4
public## 
async## 
Task## 
LoadStateCodes## (
(##( )
IDispatcher##) 4

dispatcher##5 ?
)##? @
{$$ 	
try%% 
{&& 
var'' 
client'' 
='' 
new''  
LookupsContract''! 0
.''0 1!
LookupsContractClient''1 F
(''F G
_channel''G O
)''O P
;''P Q
var(( 
stream(( 
=(( 
client(( #
.((# $
GetStateCodesUsa(($ 4
(((4 5
new((5 8
Empty((9 >
(((> ?
)((? @
)((@ A
.((A B
ResponseStream((B P
;((P Q
List** 
<** 
	StateCode** 
>** 

stateCodes**  *
=**+ ,
new**- 0
(**0 1
)**1 2
;**2 3
while,, 
(,, 
await,, 
stream,, #
.,,# $
MoveNext,,$ ,
(,,, -
default,,- 4
),,4 5
),,5 6
{-- "
grpc_StateProvinceCode.. *
code..+ /
=..0 1
stream..2 8
...8 9
Current..9 @
;..@ A

stateCodes// 
.// 
Add// "
(//" #
_mapper//# *
.//* +
Map//+ .
<//. /
	StateCode/// 8
>//8 9
(//9 :
code//: >
)//> ?
)//? @
;//@ A
}00 

dispatcher11 
.11 
Dispatch11 #
(11# $
new11$ ''
LoadStateCodesSuccessAction11( C
(11C D

stateCodes11D N
)11N O
)11O P
;11P Q
}22 
catch33 
(33 
	Exception33 
ex33 
)33  
{44  
_notificationService55 $
!55$ %
.55% &
Notify55& ,
(55, -
new66 
NotificationMessage66 +
{77 
Severity88  
=88! " 
NotificationSeverity88# 7
.887 8
Error888 =
,88= >
Style99 
=99 
$str99  [
,99[ \
Detail:: 
=::  
Helpers::! (
.::( )
GetExceptionMessage::) <
(::< =
ex::= ?
)::? @
,::@ A
Duration;;  
=;;! "
$num;;# (
}<< 
)== 
;== 

dispatcher?? 
.?? 
Dispatch?? #
(??# $
new??$ ''
LoadStateCodesFailureAction??( C
(??C D
Helpers??D K
.??K L
GetExceptionMessage??L _
(??_ `
ex??` b
)??b c
)??c d
)??d e
;??e f
}@@ 
}AA 	
publicCC 
overrideCC 
asyncCC 
TaskCC "
HandleAsyncCC# .
(DD 	.
"LoadCompanyDetailsForEditingActionEE .
actionEE/ 5
,EE5 6
IDispatcherFF 

dispatcherFF "
)GG 	
{HH 	
tryII 
{JJ 

dispatcherKK 
.KK 
DispatchKK #
(KK# $
newKK$ ' 
SetLoadingFlagActionKK( <
(KK< =
)KK= >
)KK> ?
;KK? @
varMM 
clientMM 
=MM 
newMM  
CompanyContractMM! 0
.MM0 1!
CompanyContractClientMM1 F
(MMF G
_channelMMG O
)MMO P
;MMP Q
ItemRequestNN 
requestNN #
=NN$ %
newNN& )
(NN) *
)NN* +
{NN, -
IdNN. 0
=NN1 2
actionNN3 9
.NN9 :
	CompanyIDNN: C
}NND E
;NNE F&
grpc_CompanyGenericCommandOO *
grpcResponseOO+ 7
=OO8 9
awaitOO: ?
clientOO@ F
.OOF G"
GetCompanyForEditAsyncOOG ]
(OO] ^
requestOO^ e
)OOe f
;OOf g!
CompanyGenericCommandQQ %
modelQQ& +
=QQ, -
_mapperQQ. 5
.QQ5 6
MapQQ6 9
<QQ9 :!
CompanyGenericCommandQQ: O
>QQO P
(QQP Q
grpcResponseQQQ ]
)QQ] ^
;QQ^ _

dispatcherSS 
.SS 
DispatchSS #
(SS# $
newSS$ '7
+UpdateCompanyDetailsInitializeSuccessActionSS( S
(SSS T
modelSST Y
)SSY Z
)SSZ [
;SS[ \
}TT 
catchUU 
(UU 
	ExceptionUU 
exUU 
)UU  
{VV  
_notificationServiceWW $
!WW$ %
.WW% &
NotifyWW& ,
(WW, -
newXX 
NotificationMessageXX +
{YY 
SeverityZZ  
=ZZ! " 
NotificationSeverityZZ# 7
.ZZ7 8
ErrorZZ8 =
,ZZ= >
Style[[ 
=[[ 
$str[[  [
,[[[ \
Detail\\ 
=\\  
Helpers\\! (
.\\( )
GetExceptionMessage\\) <
(\\< =
ex\\= ?
)\\? @
,\\@ A
Duration]]  
=]]! "
$num]]# (
}^^ 
)__ 
;__ 

dispatcheraa 
.aa 
Dispatchaa #
(aa# $
newaa$ '7
+UpdateCompanyDetailsInitializeFailureActionaa( S
(aaS T
HelpersaaT [
.aa[ \
GetExceptionMessageaa\ o
(aao p
exaap r
)aar s
)aas t
)aat u
;aau v
}bb 
}cc 	
[ee 	
EffectMethodee	 
]ee 
publicff 
asyncff 
Taskff ,
 SubmitUpdatedCompanyCommandModelff :
(gg 	,
 UpdateCompanyDetailsSubmitActionhh ,
actionhh- 3
,hh3 4
IDispatcherii 

dispatcherii "
)jj 	
{kk 	
tryll 
{mm 
varnn 
clientnn 
=nn 
newnn  
CompanyContractnn! 0
.nn0 1!
CompanyContractClientnn1 F
(nnF G
_channelnnG O
)nnO P
;nnP Q&
grpc_CompanyGenericCommandoo *
cmdoo+ .
=oo/ 0
_mapperoo1 8
.oo8 9
Mapoo9 <
<oo< =&
grpc_CompanyGenericCommandoo= W
>ooW X
(ooX Y
actionooY _
.oo_ `
CommandModeloo` l
)ool m
;oom n
GenericResponsepp 
responsepp  (
=pp) *
awaitpp+ 0
clientpp1 7
.pp7 8
UpdateAsyncpp8 C
(ppC D
cmdppD G
)ppG H
;ppH I
ifrr 
(rr 
responserr 
.rr 
Successrr $
)rr$ %
{ss 

dispatchertt 
.tt 
Dispatchtt '
(tt' (
newtt( +$
ViewInitializeFlagActiontt, D
(ttD E
falsettE J
)ttJ K
)ttK L
;ttL M

dispatcheruu 
.uu 
Dispatchuu '
(uu' (
newuu( +'
SetViewCompanyDetailsActionuu, G
(uuG H
cmduuH K
.uuK L
	CompanyIduuL U
)uuU V
)uuV W
;uuW X 
_notificationServiceww (
!ww( )
.ww) *
Notifyww* 0
(ww0 1
newxx 
NotificationMessagexx /
{yy 
Severityzz $
=zz% & 
NotificationSeverityzz' ;
.zz; <
Successzz< C
,zzC D
Style{{ !
={{" #
$str{{$ _
,{{_ `
Detail|| "
=||# $
$str||% P
,||P Q
Duration}} $
=}}% &
$num}}' +
}~~ 
) 
; 
}
ÄÄ 
else
ÅÅ 
{
ÇÇ 

dispatcher
ÉÉ 
.
ÉÉ 
Dispatch
ÉÉ '
(
ÉÉ' (
new
ÉÉ( +5
'UpdateCompanyDetailsSubmitFailureAction
ÉÉ, S
(
ÉÉS T
$str
ÉÉT r
)
ÉÉr s
)
ÉÉs t
;
ÉÉt u"
_notificationService
ÖÖ (
!
ÖÖ( )
.
ÖÖ) *
Notify
ÖÖ* 0
(
ÖÖ0 1
new
ÜÜ !
NotificationMessage
ÜÜ /
{
áá 
Severity
àà $
=
àà% &"
NotificationSeverity
àà' ;
.
àà; <
Error
àà< A
,
ààA B
Style
ââ !
=
ââ" #
$str
ââ$ _
,
ââ_ `
Detail
ää "
=
ää# $
$str
ää% C
,
ääC D
Duration
ãã $
=
ãã% &
$num
ãã' ,
}
åå 
)
çç 
;
çç 
}
éé 
}
èè 
catch
êê 
(
êê 
	Exception
êê 
ex
êê 
)
êê  
{
ëë "
_notificationService
íí $
!
íí$ %
.
íí% &
Notify
íí& ,
(
íí, -
new
ìì !
NotificationMessage
ìì +
{
îî 
Severity
ïï  
=
ïï! ""
NotificationSeverity
ïï# 7
.
ïï7 8
Error
ïï8 =
,
ïï= >
Style
ññ 
=
ññ 
$str
ññ  [
,
ññ[ \
Detail
óó 
=
óó  
Helpers
óó! (
.
óó( )!
GetExceptionMessage
óó) <
(
óó< =
ex
óó= ?
)
óó? @
,
óó@ A
Duration
òò  
=
òò! "
$num
òò# (
}
ôô 
)
öö 
;
öö 

dispatcher
úú 
.
úú 
Dispatch
úú #
(
úú# $
new
úú$ '5
'UpdateCompanyDetailsSubmitFailureAction
úú( O
(
úúO P
Helpers
úúP W
.
úúW X!
GetExceptionMessage
úúX k
(
úúk l
ex
úúl n
)
úún o
)
úúo p
)
úúp q
;
úúq r
}
ùù 
}
ûû 	
}
üü 
}†† ◊
ê/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
class '
UpdateCompanyDetailsFeature 3
:4 5
Feature6 =
<= >%
UpdateCompanyDetailsState> W
>W X
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, B
;B C
	protected

 
override

 %
UpdateCompanyDetailsState

 4
GetInitialState

5 D
(

D E
)

E F
=>

G I
new 
( 
) 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  

Submitting 
= 
false "
," #
	Submitted 
= 
false !
,! "
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,
CommandModel 
= 
new "!
CompanyGenericCommand# 8
(8 9
)9 :
,: ;
	CompanyID 
= 
$num 
, 

StateCodes 
= 
new  
(  !
)! "
} 
; 
} 
} ˘
†/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsInitializeFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record 7
+UpdateCompanyDetailsInitializeFailureAction D
(D E
stringE K
ErrorMessageL X
)X Y
;Y Z
} à
†/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsInitializeSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record 7
+UpdateCompanyDetailsInitializeSuccessAction D
(D E!
CompanyGenericCommandE Z
CommandModel[ g
)g h
;h i
} Ω3
ë/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

static 
class (
UpdateCompanyDetailsReducers 4
{ 
[ 	
ReducerMethod	 
] 
public 
static %
UpdateCompanyDetailsState /,
 OnLoadingStateCodesSuccessAction0 P
(		 	%
UpdateCompanyDetailsState

 %
state

& +
,

+ ,'
LoadStateCodesSuccessAction '
action( .
) 	
{ 	
return 
state 
with 
{ 

StateCodes 
= 
action #
.# $

StateCodes$ .
} 
; 
} 	
[ 	
ReducerMethod	 
] 
public 
static %
UpdateCompanyDetailsState /,
 OnLoadingStateCodesFailureAction0 P
( 	%
UpdateCompanyDetailsState %
state& +
,+ ,'
LoadStateCodesFailureAction '
action( .
) 	
{ 	
return 
state 
with 
{ 
ErrorMessage 
= 
action %
.% &
ErrorMessage& 2
} 
; 
} 	
[!! 	
ReducerMethod!!	 
(!! 
typeof!! 
(!!  
SetLoadingFlagAction!! 2
)!!2 3
)!!3 4
]!!4 5
public"" 
static"" %
UpdateCompanyDetailsState"" /)
OnLoadingCompanyDetailsAction""0 M
(## 	%
UpdateCompanyDetailsState$$ %
state$$& +
)%% 	
{&& 	
return'' 
state'' 
with'' 
{(( 
Loading)) 
=)) 
true)) 
}** 
;** 
}++ 	
[-- 	
ReducerMethod--	 
]-- 
public.. 
static.. %
UpdateCompanyDetailsState.. /#
OnSetInitializationFlag..0 G
(// 	%
UpdateCompanyDetailsState00 %
state00& +
,00+ ,)
SetUpdateInitializeFlagAction11 )
action11* 0
)22 	
{33 	
return44 
state44 
with44 
{55 
Initialized66 
=66 
action66 $
.66$ %
IsInitialized66% 2
}77 
;77 
}88 	
[:: 	
ReducerMethod::	 
]:: 
public;; 
static;; %
UpdateCompanyDetailsState;; /9
-OnUpdateCompanyDetailsInitializeSuccessAction;;0 ]
(<< 	%
UpdateCompanyDetailsState== %
state==& +
,==+ ,7
+UpdateCompanyDetailsInitializeSuccessAction>> 7
action>>8 >
)?? 	
{@@ 	
returnAA 
stateAA 
withAA 
{BB 
InitializedCC 
=CC 
trueCC "
,CC" #
LoadingDD 
=DD 
falseDD 
,DD  

SubmittingEE 
=EE 
falseEE "
,EE" #
	SubmittedFF 
=FF 
falseFF !
,FF! "
ErrorMessageGG 
=GG 
stringGG %
.GG% &
EmptyGG& +
,GG+ ,
CommandModelHH 
=HH 
actionHH %
.HH% &
CommandModelHH& 2
,HH2 3
}II 
;II 
}JJ 	
[LL 	
ReducerMethodLL	 
]LL 
publicMM 
staticMM %
UpdateCompanyDetailsStateMM /=
1OnGetCompanyDetailsInitializeFailureMessageActionMM0 a
(NN 	%
UpdateCompanyDetailsStateOO %
stateOO& +
,OO+ ,7
+UpdateCompanyDetailsInitializeFailureActionPP 7
actionPP8 >
)QQ 	
{RR 	
returnSS 
stateSS 
withSS 
{TT 
ErrorMessageUU 
=UU 
actionUU %
.UU% &
ErrorMessageUU& 2
,UU2 3
LoadingVV 
=VV 
falseVV 
,VV  
InitializedWW 
=WW 
falseWW #
}XX 
;XX 
}YY 	
[[[ 	
ReducerMethod[[	 
([[ 
typeof[[ 
([[ ,
 UpdateCompanyDetailsSubmitAction[[ >
)[[> ?
)[[? @
][[@ A
public\\ 
static\\ %
UpdateCompanyDetailsState\\ /
OnSubmit\\0 8
(\\8 9%
UpdateCompanyDetailsState\\9 R
state\\S X
)\\X Y
{]] 	
return^^ 
state^^ 
with^^ 
{__ 

Submitting`` 
=`` 
true`` !
}aa 
;aa 
}bb 	
[dd 	
ReducerMethoddd	 
]dd 
publicee 
staticee %
UpdateCompanyDetailsStateee /
OnSubmitSuccessee0 ?
(ff 	%
UpdateCompanyDetailsStategg %
stategg& +
,gg+ ,3
'UpdateCompanyDetailsSubmitSuccessActionhh 3
_hh4 5
)ii 	
{jj 	
returnkk 
statekk 
withkk 
{ll 
Initializedmm 
=mm 
falsemm #
,mm# $

Submittingnn 
=nn 
falsenn "
,nn" #
	Submittedoo 
=oo 
trueoo  
,oo  !
}pp 
;pp 
}qq 	
[ss 	
ReducerMethodss	 
]ss 
publictt 
statictt %
UpdateCompanyDetailsStatett /
OnSubmitFailurett0 ?
(uu 	%
UpdateCompanyDetailsStatevv %
statevv& +
,vv+ ,3
'UpdateCompanyDetailsSubmitFailureActionww 3
actionww4 :
)xx 	
{yy 	
returnzz 
statezz 
withzz 
{{{ 

Submitting|| 
=|| 
false|| "
,||" #
	Submitted}} 
=}} 
false}} !
,}}! "
ErrorMessage~~ 
=~~ 
action~~ %
.~~% &
ErrorMessage~~& 2
} 
; 
}
ÄÄ 	
}
ÅÅ 
}ÇÇ Ù
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsState.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record %
UpdateCompanyDetailsState 2
{ 
public 
bool 
Initialized 
{  !
get" %
;% &
init' +
;+ ,
}- .
public		 
bool		 
Loading		 
{		 
get		 !
;		! "
init		# '
;		' (
}		) *
public

 
bool

 

Submitting

 
{

  
get

! $
;

$ %
init

& *
;

* +
}

, -
public 
bool 
	Submitted 
{ 
get  #
;# $
init% )
;) *
}+ ,
public 
string 
? 
ErrorMessage #
{$ %
get& )
;) *
init+ /
;/ 0
}1 2
public 
int 
	CompanyID 
{ 
get "
;" #
init$ (
;( )
}* +
public !
CompanyGenericCommand $
?$ %
CommandModel& 2
{3 4
get5 8
;8 9
init: >
;> ?
}@ A
public 
List 
< 
	StateCode 
> 
? 

StateCodes  *
{+ ,
get- 0
;0 1
init2 6
;6 7
}8 9
} 
} Ú
ï/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsSubmitAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record ,
 UpdateCompanyDetailsSubmitAction 9
(9 :!
CompanyGenericCommand: O
CommandModelP \
)\ ]
;] ^
} Ò
ú/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsSubmitFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record 3
'UpdateCompanyDetailsSubmitFailureAction @
(@ A
stringA G
ErrorMessageH T
)T U
;U V
} õ
ú/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateCompanyDetails/Store/UpdateCompanyDetailsSubmitSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., - 
UpdateCompanyDetails- A
.A B
StoreB G
{ 
public 

sealed 
record 3
'UpdateCompanyDetailsSubmitSuccessAction @
(@ A
intA D$
SuppressSonarqubeWarningE ]
=^ _
$num` a
)a b
;b c
} ≈c
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/UpdateWorker/Pages/UpdateWorkerDialog.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
UpdateWorker- 9
.9 :
Pages: ?
{ 
public 

partial 
class 
UpdateWorkerDialog +
:, -
ComponentBase. ;
{ 
private 
static 
IEnumerable "
<" #
MaritalStatuses# 2
>2 3
MaritalStatuses4 C
=>D F
SimpleLookupsG T
.T U
GetMaritalStatusesU g
(g h
)h i
;i j
private 
static 
IEnumerable "
<" #
Gender# )
>) *
Genders+ 2
=>3 5
SimpleLookups6 C
.C D

GetGendersD N
(N O
)O P
;P Q
private 
static 
IEnumerable "
<" #
	NameStyle# ,
>, -

NameStyles. 8
=>9 ;
SimpleLookups< I
.I J
GetNameStylesJ W
(W X
)X Y
;Y Z
private 
static 
IEnumerable "
<" #$
EmailPromotionPreference# ;
>; <%
EmailPromotionPreferences= V
=>W Y
SimpleLookupsZ g
.g h(
GetEmailPromotionPreference	h É
(
É Ñ
)
Ñ Ö
;
Ö Ü
private 
static 
IEnumerable "
<" #
PhoneNumberType# 2
>2 3
PhoneNumberTypes4 D
=>E G
SimpleLookupsH U
.U V
GetPhoneNumberTypesV i
(i j
)j k
;k l
private 
static 
IEnumerable "
<" #
SalariedFlag# /
>/ 0
SalariedFlags1 >
=>? A
SimpleLookupsB O
.O P
GetSalariedFlagsP `
(` a
)a b
;b c
[ 	
	Parameter	 
( "
CaptureUnmatchedValues )
=* +
true, 0
)0 1
]1 2
public 
IReadOnlyDictionary "
<" #
string# )
,) *
dynamic+ 2
>2 3
?3 4

Attributes5 ?
{@ A
getB E
;E F
setG J
;J K
}L M
[ 	
	Parameter	 
] 
public 
dynamic "
?" #
BusinessEntityID$ 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
private 
bool 
	isLoading 
; 
private "
EmployeeGenericCommand &
?& '
employee( 0
;0 1
private 
List 
< 
	ManagerId 
> 
?  
managers! )
;) *
private 
List 
< 
	StateCode 
> 
?  

stateCodes! +
;+ ,
[   	
Inject  	 
]   
private   
DialogService   &
?  & '
DialogService  ( 5
{  6 7
get  8 ;
;  ; <
set  = @
;  @ A
}  B C
[!! 	
Inject!!	 
]!! 
private!! 
NotificationService!! ,
?!!, -
NotificationService!!. A
{!!B C
get!!D G
;!!G H
set!!I L
;!!L M
}!!N O
["" 	
Inject""	 
]"" 
private"" &
IEmployeeRepositoryService"" 3
?""3 4
EmployeeRepository""5 G
{""H I
get""J M
;""M N
set""O R
;""R S
}""T U
	protected$$ 
override$$ 
async$$  
Task$$! %
OnInitializedAsync$$& 8
($$8 9
)$$9 :
{%% 	
await&& 
Load&& 
(&& 
)&& 
;&& 
await'' 
base'' 
.'' 
OnInitializedAsync'' )
('') *
)''* +
;''+ ,
}(( 	
private** 
async** 
Task** 
Load** 
(**  
)**  !
{++ 	
	isLoading,, 
=,, 
true,, 
;,, 
Result.. 
<.. "
EmployeeGenericCommand.. )
>..) *
result..+ 1
=..2 3
await..4 9
EmployeeRepository..: L
!..L M
...M N 
GetEmployeeForUpdate..N b
(..b c
BusinessEntityID..c s
)..s t
;..t u
if00 
(00 
result00 
.00 
	IsFailure00  
)00  !
{11 !
ShowErrorNotification22 %
.22% &
	ShowError22& /
(22/ 0
NotificationService33 '
!33' (
,33( )
result44 
.44 
Error44  
.44  !
Message44! (
)55 
;55 
}66 
else77 
{88 
employee99 
=99 
result99 !
.99! "
Value99" '
;99' (
}:: 
await<< 
LoadLookups<< 
(<< 
)<< 
;<<  
	isLoading>> 
=>> 
false>> 
;>> 
}?? 	
	protectedAA 
asyncAA 
TaskAA 
LoadLookupsAA (
(AA( )
)AA) *
{BB 	
ResultCC 
<CC 
ListCC 
<CC 
	ManagerIdCC !
>CC! "
>CC" #
managerResultCC$ 1
=CC2 3
awaitCC4 9
EmployeeRepositoryCC: L
!CCL M
.CCM N
GetManagerIDsCCN [
(CC[ \
)CC\ ]
;CC] ^
ifDD 
(DD 
managerResultDD 
.DD 
	IsFailureDD '
)DD' (
{EE !
ShowErrorNotificationFF %
.FF% &
	ShowErrorFF& /
(FF/ 0
NotificationServiceGG '
!GG' (
,GG( )
managerResultHH !
.HH! "
ErrorHH" '
.HH' (
MessageHH( /
)II 
;II 
}JJ 
managersLL 
=LL 
managerResultLL $
.LL$ %
ValueLL% *
;LL* +
ResultNN 
<NN 
ListNN 
<NN 
	StateCodeNN !
>NN! "
>NN" #
stateCodeResultNN$ 3
=NN4 5
awaitNN6 ;
EmployeeRepositoryNN< N
!NNN O
.NNO P
GetStateCodesNNP ]
(NN] ^
)NN^ _
;NN_ `
ifOO 
(OO 
stateCodeResultOO 
.OO  
	IsFailureOO  )
)OO) *
{PP !
ShowErrorNotificationQQ %
.QQ% &
	ShowErrorQQ& /
(QQ/ 0
NotificationServiceRR '
!RR' (
,RR( )
stateCodeResultSS #
.SS# $
ErrorSS$ )
.SS) *
MessageSS* 1
)TT 
;TT 
}UU 

stateCodesWW 
=WW 
stateCodeResultWW (
.WW( )
ValueWW) .
;WW. /
}XX 	
	protectedZZ 
asyncZZ 
TaskZZ 

FormSubmitZZ '
(ZZ' (
)ZZ( )
{[[ 	
try\\ 
{]] 
Result^^ 
result^^ 
=^^ 
await^^  %
EmployeeRepository^^& 8
!^^8 9
.^^9 :
UpdateEmployee^^: H
(^^H I
employee^^I Q
!^^Q R
)^^R S
;^^S T
if`` 
(`` 
result`` 
.`` 
	IsSuccess`` $
)``$ %
{aa 
DialogServicebb !
!bb! "
.bb" #
Closebb# (
(bb( )
employeebb) 1
)bb1 2
;bb2 3
}cc 
elsedd 
{ee !
ShowErrorNotificationff )
.ff) *
	ShowErrorff* 3
(ff3 4
NotificationServicegg +
!gg+ ,
,gg, -
resulthh 
.hh 
Errorhh $
.hh$ %
Messagehh% ,
)ii 
;ii 
}jj 
}ll 
catchmm 
(mm 
Systemmm 
.mm 
	Exceptionmm #
exmm$ &
)mm& '
{nn !
ShowErrorNotificationoo %
.oo% &
	ShowErroroo& /
(oo/ 0
NotificationServicepp '
!pp' (
,pp( )
Helpersqq 
.qq 
GetExceptionMessageqq /
(qq/ 0
exqq0 2
)qq2 3
)rr 
;rr 
}ss 
}tt 	
	protectedvv 
voidvv #
CloseUpdateWorkerDialogvv .
(vv. /
)vv/ 0
=>ww 
DialogServiceww 
!ww 
.ww 
Closeww #
(ww# $
nullww$ (
)ww( )
;ww) *
privateyy 
staticyy 
boolyy 
ValidateBirthdayyy ,
(yy, -
DateTimeyy- 5
	birthdateyy6 ?
)yy? @
{zz 	
return{{ 
	birthdate{{ 
>={{ 
new{{  #
DateTime{{$ ,
({{, -
$num{{- 1
,{{1 2
$num{{3 4
,{{4 5
$num{{6 7
,{{7 8
$num{{9 :
,{{: ;
$num{{< =
,{{= >
$num{{? @
,{{@ A
DateTimeKind{{B N
.{{N O
Local{{O T
){{T U
&&{{V X
	birthdate|| 
<=|| 
DateTime||  (
.||( )
Today||) .
.||. /
AddYears||/ 7
(||7 8
-||8 9
$num||9 ;
)||; <
;||< =
}}} 	
private 
static 
bool 
ValidateHireDate ,
(, -
DateTime- 5
hireDate6 >
)> ?
{
ÄÄ 	
return
ÅÅ 
hireDate
ÅÅ 
>=
ÅÅ 
new
ÅÅ "
DateTime
ÅÅ# +
(
ÅÅ+ ,
$num
ÅÅ, 0
,
ÅÅ0 1
$num
ÅÅ2 3
,
ÅÅ3 4
$num
ÅÅ5 6
,
ÅÅ6 7
$num
ÅÅ8 9
,
ÅÅ9 :
$num
ÅÅ; <
,
ÅÅ< =
$num
ÅÅ> ?
,
ÅÅ? @
DateTimeKind
ÅÅA M
.
ÅÅM N
Local
ÅÅN S
)
ÅÅS T
&&
ÅÅU W
hireDate
ÇÇ 
<=
ÇÇ 
DateTime
ÇÇ '
.
ÇÇ' (
Today
ÇÇ( -
.
ÇÇ- .
AddDays
ÇÇ. 5
(
ÇÇ5 6
$num
ÇÇ6 7
)
ÇÇ7 8
;
ÇÇ8 9
}
ÉÉ 	
private
ÖÖ 
bool
ÖÖ '
ValidateSelectedStateCode
ÖÖ .
(
ÖÖ. /
int
ÖÖ/ 2
stateProvinceId
ÖÖ3 B
)
ÖÖB C
{
ÜÜ 	
	StateCode
áá 
?
áá 
	stateCode
áá  
=
áá! "

stateCodes
áá# -
!
áá- .
.
áá. /
Find
áá/ 3
(
áá3 4
s
áá4 5
=>
áá6 8
s
áá9 :
.
áá: ;
StateProvinceID
áá; J
==
ááK M
stateProvinceId
ááN ]
)
áá] ^
;
áá^ _
return
ââ 
	stateCode
ââ 
is
ââ 
not
ââ  #
null
ââ$ (
;
ââ( )
}
ää 	
private
åå 
static
åå 
bool
åå &
ValidateNationalIdNumber
åå 4
(
åå4 5
string
åå5 ;

nationalId
åå< F
)
ååF G
{
çç 	
Regex
éé 
regex
éé 
=
éé 
nationalIdRegex
éé )
(
éé) *
)
éé* +
;
éé+ ,
Match
èè 
match
èè 
=
èè 
regex
èè 
.
èè  
Match
èè  %
(
èè% &

nationalId
èè& 0
??
èè1 3
string
èè4 :
.
èè: ;
Empty
èè; @
)
èè@ A
;
èèA B
return
ëë 
match
ëë 
.
ëë 
Success
ëë  
;
ëë  !
}
íí 	
[
îî 	
GeneratedRegex
îî	 
(
îî 
$str
îî $
)
îî$ %
]
îî% &
private
ïï 
static
ïï 
partial
ïï 
Regex
ïï $
nationalIdRegex
ïï% 4
(
ïï4 5
)
ïï5 6
;
ïï6 7
}
òò 
}ôô ç
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Pages/ViewCompanyDetailPage.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Pages@ E
{ 
public 

partial 
class !
ViewCompanyDetailPage .
{		 
[

 	
Inject

	 
]

 
private

 
IState

 
<

  "
ViewCompanyDetailState

  6
>

6 7
?

7 8"
ViewCompanyDetailState

9 O
{

P Q
get

R U
;

U V
set

W Z
;

Z [
}

\ ]
[ 	
Inject	 
] 
private 
IDispatcher $
?$ %

Dispatcher& 0
{1 2
get3 6
;6 7
set8 ;
;; <
}= >
[ 	
Inject	 
] 
private 
NavigationManager *
?* +

NavManager, 6
{7 8
get9 <
;< =
set> A
;A B
}C D
private 
CompanyDetails 
? 
DetailsModel  ,
=>- /"
ViewCompanyDetailState0 F
!F G
.G H
ValueH M
.M N
DetailsModelN Z
;Z [
private 
bool 
Loading 
=> "
ViewCompanyDetailState  6
!6 7
.7 8
Value8 =
.= >
Loading> E
;E F
	protected 
override 
void 
OnInitialized  -
(- .
). /
{ 	
if 
( 
! "
ViewCompanyDetailState '
!' (
.( )
Value) .
.. /
Initialized/ :
): ;
{ 

Dispatcher 
! 
. 
Dispatch $
($ %
new% ('
SetViewCompanyDetailsAction) D
(D E"
ViewCompanyDetailStateE [
![ \
.\ ]
Value] b
.b c
	CompanyIDc l
)l m
)m n
;n o
} 
base 
. 
OnInitialized 
( 
)  
;  !
} 	
private 
void 
EditButtonClicked &
(& '
)' (
{ 	

NavManager 
! 
. 

NavigateTo "
(" #
$str# q
)q r
;r s
} 	
} 
} Ò
á/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/SetLoadingFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

sealed 
record  
SetLoadingFlagAction -
(- .
int. 1$
SuppressSonarqubeWarning2 J
=K L
$numM N
)N O
;O P
} ª
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/SetViewCompanyDetailsAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

record '
SetViewCompanyDetailsAction -
(- .
int. 1
	CompanyID2 ;
); <
;< =
} Ô
ã/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewCompanyDetailEffects.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{		 
public

 

sealed

 
class

 $
ViewCompanyDetailEffects

 0
:

1 2
Effect

3 9
<

9 :'
SetViewCompanyDetailsAction

: U
>

U V
{ 
private 
readonly 
GrpcChannel $
?$ %
_channel& .
;. /
private 
readonly 
IMapper  
_mapper! (
;( )
public $
ViewCompanyDetailEffects '
(' (
GrpcChannel( 3
channel4 ;
,; <
IMapper= D
mapperE K
)K L
=> 
( 
_channel 
, 
_mapper !
)! "
=# $
(% &
channel& -
,- .
mapper/ 5
)5 6
;6 7
public 
override 
async 
Task "
HandleAsync# .
( 	'
SetViewCompanyDetailsAction '
action( .
,. /
IDispatcher 

dispatcher "
) 	
{ 	
try 
{ 

dispatcher 
. 
Dispatch #
(# $
new$ ' 
SetLoadingFlagAction( <
(< =
)= >
)> ?
;? @
gRPC 
. 
	Contracts 
. 
Shared %
.% &
ItemRequest& 1
request2 9
=: ;
new< ?
(? @
)@ A
{B C
IdD F
=G H
actionI O
.O P
	CompanyIDP Y
}Z [
;[ \
var 
client 
= 
new  
CompanyContract! 0
.0 1!
CompanyContractClient1 F
(F G
_channelG O
)O P
;P Q"
grpc_CompanyForDisplay &
grpcResponse' 3
=4 5
await6 ;
client< B
.B C%
GetCompanyForDisplayAsyncC \
(\ ]
request] d
)d e
;e f
CompanyDetails   
model   $
=  % &
_mapper  ' .
.  . /
Map  / 2
<  2 3
CompanyDetails  3 A
>  A B
(  B C
grpcResponse  C O
)  O P
;  P Q

dispatcher"" 
."" 
Dispatch"" #
(""# $
new""$ '+
ViewCompanyDetailsSuccessAction""( G
(""G H
model""H M
)""M N
)""N O
;""O P

dispatcher## 
.## 
Dispatch## #
(### $
new##$ '$
ViewInitializeFlagAction##( @
(##@ A
true##A E
)##E F
)##F G
;##G H
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 

dispatcher'' 
.'' 
Dispatch'' #
(''# $
new''$ '2
&ViewCompanyDetailsFailureMessageAction''( N
(''N O
Helpers''O V
.''V W
GetExceptionMessage''W j
(''j k
ex''k m
)''m n
)''n o
)''o p
;''p q
}(( 
})) 	
}** 
}++ ®
å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewCompanyDetailReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

static 
class %
ViewCompanyDetailReducers 1
{ 
[ 	
ReducerMethod	 
( 
typeof 
(  
SetLoadingFlagAction 2
)2 3
)3 4
]4 5
public 
static "
ViewCompanyDetailState ,)
OnLoadingCompanyDetailsAction- J
(		 	"
ViewCompanyDetailState

 "
state

# (
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
true 
} 
; 
} 	
[ 	
ReducerMethod	 
] 
public 
static "
ViewCompanyDetailState ,%
OnSetInitializeFlagAction- F
( 	"
ViewCompanyDetailState "
state# (
,( )$
ViewInitializeFlagAction $
action% +
) 	
{ 	
return 
state 
with 
{ 
Initialized 
= 
action $
.$ %
IsInitialized% 2
} 
; 
} 	
[   	
ReducerMethod  	 
]   
public!! 
static!! "
ViewCompanyDetailState!! ,,
 OnGetCompanyDetailsSuccessAction!!- M
("" 	"
ViewCompanyDetailState## "
state### (
,##( )+
ViewCompanyDetailsSuccessAction$$ +
action$$, 2
)%% 	
{&& 	
return'' 
state'' 
with'' 
{(( 
DetailsModel)) 
=)) 
action)) %
.))% &
DetailModel))& 1
,))1 2
Loading** 
=** 
false** 
,**  
Initialized++ 
=++ 
true++ "
},, 
;,, 
}-- 	
[// 	
ReducerMethod//	 
]// 
public00 
static00 "
ViewCompanyDetailState00 ,3
'OnGetCompanyDetailsFailureMessageAction00- T
(11 	"
ViewCompanyDetailState22 "
state22# (
,22( )2
&ViewCompanyDetailsFailureMessageAction33 2
action333 9
)44 	
{55 	
return66 
state66 
with66 
{77 
ErrorMessage88 
=88 
action88 %
.88% &
ErrorMessage88& 2
,882 3
Loading99 
=99 
false99 
,99  
Initialized:: 
=:: 
false:: #
};; 
;;; 
}<< 	
}== 
}>> Î
ô/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewCompanyDetailsFailureMessageAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

sealed 
record 2
&ViewCompanyDetailsFailureMessageAction ?
(? @
string@ F
ErrorMessageG S
)S T
;T U
} ì
å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewCompanyDetailsFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

sealed 
class %
ViewCompanyDetailsFeature 1
:2 3
Feature4 ;
<; <"
ViewCompanyDetailState< R
>R S
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, ?
;? @
	protected		 
override		 "
ViewCompanyDetailState		 1
GetInitialState		2 A
(		A B
)		B C
=>		D F
new

 
(

 
)

 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,
DetailsModel 
= 
null #
,# $
	CompanyID 
= 
$num 
} 
; 
} 
} ‰
í/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewCompanyDetailsSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

sealed 
record +
ViewCompanyDetailsSuccessAction 8
(8 9
CompanyDetails9 G
DetailModelH S
)S T
;T U
} …

â/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewCompanyDetailState.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

sealed 
record "
ViewCompanyDetailState /
{ 
public 
bool 
Initialized 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
bool 
Loading 
{ 
get !
;! "
init# '
;' (
}) *
public		 
string		 
?		 
ErrorMessage		 #
{		$ %
get		& )
;		) *
init		+ /
;		/ 0
}		1 2
public

 
int

 
	CompanyID

 
{

 
get

 "
;

" #
init

$ (
;

( )
}

* +
public 
CompanyDetails 
? 
DetailsModel +
{, -
get. 1
;1 2
init3 7
;7 8
}9 :
} 
} Œ
ã/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewCompanyDetails/Store/ViewInitializeFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewCompanyDetails- ?
.? @
Store@ E
{ 
public 

sealed 
record $
ViewInitializeFlagAction 1
(1 2
bool2 6
IsInitialized7 D
)D E
;E F
} ‡;
â/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Pages/ViewDepartmentsPage.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Pages= B
{ 
public 

partial 
class 
ViewDepartmentsPage ,
{ 
private 
bool 
	isLoading 
; 
private 
IEnumerable 
< 
DepartmentDetails -
>- .
?. /
departmentDetails0 A
;A B
private 
int 
count 
; 
private 
readonly 
IEnumerable $
<$ %
int% (
>( )
pageSizeOptions* 9
=: ;
new< ?
List@ D
<D E
intE H
>H I
(I J
)J K
{L M
$numN O
,O P
$numQ S
,S T
$numU W
,W X
$numY [
}\ ]
;] ^
	protected 
NotificationService %
?% &
NotificationService' :
{; <
get= @
;@ A
setB E
;E F
}G H
[ 	
Inject	 
] 
private 
GrpcChannel $
?$ %
GrpcChannel& 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
[ 	
Inject	 
] 
private 
IMapper  
?  !
Mapper" (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
	protected 
async 
Task 
LoadDepartmentData /
(/ 0
LoadDataArgs0 <
args= A
)A B
{ 	
try 
{ 
string 
searchField "
=# $
string% +
.+ ,
Empty, 1
;1 2
string   
searchCriteria   %
=  & '
string  ( .
.  . /
Empty  / 4
;  4 5
if"" 
("" 
args"" 
."" 
Filters""  
is""! #
not""$ '
null""( ,
)"", -
{## 
List$$ 
<$$ 
FilterDescriptor$$ )
>$$) *
descriptors$$+ 6
=$$7 8
args$$9 =
.$$= >
Filters$$> E
.$$E F
ToList$$F L
($$L M
)$$M N
;$$N O
FilterDescriptor%% $
?%%$ %
filterDescriptor%%& 6
=&& 
descriptors&& %
.&&% &
Find&&& *
(&&* +
x&&+ ,
=>&&- /
!&&0 1
string&&1 7
.&&7 8
IsNullOrEmpty&&8 E
(&&E F
x&&F G
.&&G H
Property&&H P
)&&P Q
&&&&R T
!&&U V
string&&V \
.&&\ ]
IsNullOrEmpty&&] j
(&&j k
x&&k l
.&&l m
FilterValue&&m x
.&&x y
ToString	&&y Å
(
&&Å Ç
)
&&Ç É
)
&&É Ñ
)
&&Ñ Ö
;
&&Ö Ü
if(( 
((( 
filterDescriptor(( (
is(() +
not((, /
null((0 4
)((4 5
{)) 
searchField** #
=**$ %
filterDescriptor**& 6
.**6 7
Property**7 ?
;**? @
searchCriteria++ &
=++' (
filterDescriptor++) 9
.++9 :
FilterValue++: E
.++E F
ToString++F N
(++N O
)++O P
!++P Q
;++Q R
},, 
}--  
StringSearchCriteria// $
criteria//% -
=//. /
new//0 3
(00 
searchField11 
,11  
searchCriteria22 "
,22" #
!33 
string33 
.33 
IsNullOrEmpty33 )
(33) *
args33* .
.33. /
OrderBy33/ 6
)336 7
?338 9
args33: >
.33> ?
OrderBy33? F
:33G H
string33I O
.33O P
Empty33P U
,33U V
$num44 
,44 
$num55 
,55 
args66 
.66 
Skip66 
??66  
default66! (
,66( )
args77 
.77 
Top77 
??77 
default77  '
)88 
;88 
	isLoading:: 
=:: 
true::  
;::  !
await<< 
GetDepartments<< $
(<<$ %
criteria<<% -
)<<- .
;<<. /
	isLoading>> 
=>> 
false>> !
;>>! "
await@@ 
InvokeAsync@@ !
(@@! "
StateHasChanged@@" 1
)@@1 2
;@@2 3
}BB 
catchCC 
(CC 
	ExceptionCC 
exCC 
)CC  
{DD 
NotificationServiceEE #
!EE# $
.EE$ %
NotifyEE% +
(EE+ ,
newFF 
NotificationMessageFF +
{GG 
SeverityHH  
=HH! " 
NotificationSeverityHH# 7
.HH7 8
ErrorHH8 =
,HH= >
StyleII 
=II 
$strII  [
,II[ \
DetailJJ 
=JJ  
HelpersJJ! (
.JJ( )
GetExceptionMessageJJ) <
(JJ< =
exJJ= ?
)JJ? @
,JJ@ A
DurationKK  
=KK! "
$numKK# '
}LL 
)MM 
;MM 
}NN 
}OO 	
privateQQ 
asyncQQ 
TaskQQ 
GetDepartmentsQQ )
(QQ) * 
StringSearchCriteriaQQ* >
criteriaQQ? G
)QQG H
{RR 	
varSS 
clientSS 
=SS 
newSS 
CompanyContractSS ,
.SS, -!
CompanyContractClientSS- B
(SSB C
GrpcChannelSSC N
)SSN O
;SSO P&
grpc_GetCompanyDepartmentsTT &
grpcResponseTT' 3
=TT4 5
awaitUU 
clientUU 
.UU +
GetDepartmentsSearchByNameAsyncUU <
(UU< =
MapperUU= C
!UUC D
.UUD E
MapUUE H
<UUH I%
grpc_StringSearchCriteriaUUI b
>UUb c
(UUc d
criteriaUUd l
)UUl m
)UUm n
;UUn o
ListWW 
<WW 
DepartmentDetailsWW "
>WW" #
departmentsWW$ /
=WW0 1
newWW2 5
(WW5 6
)WW6 7
;WW7 8
grpcResponseXX 
.XX 
GrpcDepartmentsXX (
.XX( )
ToListXX) /
(XX/ 0
)XX0 1
.YY( )
ForEachYY) 0
(YY0 1
grpcDeptYY1 9
=>YY: <
departmentsYY= H
.YYH I
AddYYI L
(YYL M
MapperYYM S
.YYS T
MapYYT W
<YYW X
DepartmentDetailsYYX i
>YYi j
(YYj k
grpcDeptYYk s
)YYs t
)YYt u
)YYu v
;YYv w
departmentDetails[[ 
=[[ 
departments[[  +
;[[+ ,
count\\ 
=\\ 
grpcResponse\\  
.\\  !
GrpcMetaData\\! -
[\\- .
$str\\. :
]\\: ;
;\\; <
}]] 	
}^^ 
}__ —
Ñ/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/GetDepartmentsAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

sealed 
record  
GetDepartmentsAction -
(- . 
StringSearchCriteria. B
SearchCriteriaC Q
)Q R
;R S
} œ
ã/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/GetDepartmentsFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

sealed 
record '
GetDepartmentsFailureAction 4
(4 5
string5 ;
ErrorMessage< H
)H I
;I J
} Ç
ã/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/GetDepartmentsSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

record '
GetDepartmentsSuccessAction -
(- .
List. 2
<2 3
DepartmentDetails3 D
>D E
DepartmentsF Q
,Q R
MetaDataS [
MetaData\ d
,d e 
StringSearchCriteriaf z
SearchCriteria	{ â
)
â ä
;
ä ã
} Î
Ñ/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/SetLoadingFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

sealed 
record  
SetLoadingFlagAction -
(- .
int. 1$
SuppressSonarqubeWarning2 J
=K L
$numM N
)N O
;O P
} å+
Ü/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/ViewDepartmentsEffects.cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Features

 
.

 
HumanResources

 ,
.

, -
ViewDepartments

- <
.

< =
Store

= B
{ 
public 

class "
ViewDepartmentsEffects '
:( )
Effect* 0
<0 1 
GetDepartmentsAction1 E
>E F
{ 
private 
readonly 
GrpcChannel $
_channel% -
;- .
private 
readonly 
NotificationService , 
_notificationService- A
;A B
private 
readonly 
IMapper  
_mapper! (
;( )
public "
ViewDepartmentsEffects %
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
NotificationService 
notificationService  3
) 	
{ 	
_channel 
= 
channel 
; 
_mapper 
= 
mapper 
;  
_notificationService  
=! "
notificationService# 6
;6 7
} 	
public 
override 
async 
Task "
HandleAsync# .
( 	 
GetDepartmentsAction    
action  ! '
,  ' (
IDispatcher!! 

dispatcher!! "
)"" 	
{## 	
try$$ 
{%% 

dispatcher&& 
.&& 
Dispatch&& #
(&&# $
new&&$ ' 
SetLoadingFlagAction&&( <
(&&< =
)&&= >
)&&> ?
;&&? @
var(( 
client(( 
=(( 
new((  
CompanyContract((! 0
.((0 1!
CompanyContractClient((1 F
(((F G
_channel((G O
)((O P
;((P Q&
grpc_GetCompanyDepartments)) *
grpcResponse))+ 7
=))8 9
await** 
client**  
.**  !+
GetDepartmentsSearchByNameAsync**! @
(**@ A
_mapper**A H
.**H I
Map**I L
<**L M%
grpc_StringSearchCriteria**M f
>**f g
(**g h
action**h n
.**n o
SearchCriteria**o }
)**} ~
)**~ 
;	** Ä
List,, 
<,, 
DepartmentDetails,, &
>,,& '
departments,,( 3
=,,4 5
new,,6 9
(,,9 :
),,: ;
;,,; <
grpcResponse-- 
.-- 
GrpcDepartments-- ,
.--, -
ToList--- 3
(--3 4
)--4 5
..., -
ForEach..- 4
(..4 5
grpcDept..5 =
=>..> @
departments..A L
...L M
Add..M P
(..P Q
_mapper..Q X
...X Y
Map..Y \
<..\ ]
DepartmentDetails..] n
>..n o
(..o p
grpcDept..p x
)..x y
)..y z
)..z {
;..{ |
MetaData00 
metaData00 !
=00" #
new00$ '
(00' (
)00( )
{11 

TotalCount22 
=22  
grpcResponse22! -
.22- .
GrpcMetaData22. :
[22: ;
$str22; G
]22G H
,22H I
PageSize33 
=33 
grpcResponse33 +
.33+ ,
GrpcMetaData33, 8
[338 9
$str339 C
]33C D
,33D E
CurrentPage44 
=44  !
grpcResponse44" .
.44. /
GrpcMetaData44/ ;
[44; <
$str44< I
]44I J
,44J K

TotalPages55 
=55  
grpcResponse55! -
.55- .
GrpcMetaData55. :
[55: ;
$str55; G
]55G H
}66 
;66 

dispatcher88 
.88 
Dispatch88 #
(88# $
new88$ ''
GetDepartmentsSuccessAction88( C
(88C D
departments88D O
,88O P
metaData88Q Y
,88Y Z
action88[ a
.88a b
SearchCriteria88b p
)88p q
)88q r
;88r s
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;;  
_notificationService<< $
!<<$ %
.<<% &
Notify<<& ,
(<<, -
new== 
NotificationMessage== +
{>> 
Severity??  
=??! " 
NotificationSeverity??# 7
.??7 8
Error??8 =
,??= >
Style@@ 
=@@ 
$str@@  [
,@@[ \
DetailAA 
=AA  
HelpersAA! (
.AA( )
GetExceptionMessageAA) <
(AA< =
exAA= ?
)AA? @
,AA@ A
DurationBB  
=BB! "
$numBB# (
}CC 
)DD 
;DD 

dispatcherFF 
.FF 
DispatchFF #
(FF# $
newFF$ ''
GetDepartmentsFailureActionFF( C
(FFC D
HelpersFFD K
.FFK L
GetExceptionMessageFFL _
(FF_ `
exFF` b
)FFb c
)FFc d
)FFd e
;FFe f
}GG 
}HH 	
}II 
}JJ Ë
Ü/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/ViewDepartmentsFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

sealed 
class "
ViewDepartmentsFeature .
:/ 0
Feature1 8
<8 9 
ViewDepartmentsState9 M
>M N
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, =
;= >
	protected

 
override

  
ViewDepartmentsState

 /
GetInitialState

0 ?
(

? @
)

@ A
=>

B D
new 
( 
) 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,
DepartmentList 
=  
new! $
($ %
)% &
,& '
MetaData 
= 
new 
( 
)  
{! "
CurrentPage# .
=/ 0
$num1 2
,2 3
PageSize4 <
== >
$num? A
}B C
,C D
SearchCriteria 
=  
new! $ 
StringSearchCriteria% 9
( 
SearchField 
:  
$str! '
,' (
SearchCriteria "
:" #
string$ *
.* +
Empty+ 0
,0 1
OrderBy 
: 
$str #
,# $

PageNumber 
: 
$num  !
,! "
PageSize 
: 
$num  
,  !
Skip 
: 
$num 
, 
Take 
: 
$num 
) 
} 
; 
} 
} √
á/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/ViewDepartmentsReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

static 
class #
ViewDepartmentsReducers /
{ 
[ 	
ReducerMethod	 
( 
typeof 
(  
SetLoadingFlagAction 2
)2 3
)3 4
]4 5
public 
static  
ViewDepartmentsState *-
!OnLoadingCompanyDepartmentsAction+ L
(		 	 
ViewDepartmentsState

  
state

! &
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
true 
} 
; 
} 	
[ 	
ReducerMethod	 
] 
public 
static  
ViewDepartmentsState *0
$OnGetCompanyDepartmentsSuccessAction+ O
( 	 
ViewDepartmentsState  
state! &
,& ''
GetDepartmentsSuccessAction '
action( .
) 	
{ 	
return 
state 
with 
{ 
DepartmentList 
=  
action! '
.' (
Departments( 3
,3 4
MetaData 
= 
action !
.! "
MetaData" *
,* +
Loading 
= 
false 
,  
Initialized 
= 
true "
," #
SearchCriteria   
=    
action  ! '
.  ' (
SearchCriteria  ( 6
}!! 
;!! 
}"" 	
[$$ 	
ReducerMethod$$	 
]$$ 
public%% 
static%%  
ViewDepartmentsState%% *7
+OnGetCompanyDepartmentsFailureMessageAction%%+ V
(&& 	 
ViewDepartmentsState''  
state''! &
,''& ''
GetDepartmentsFailureAction(( '
action((( .
))) 	
{** 	
return++ 
state++ 
with++ 
{,, 
ErrorMessage-- 
=-- 
action-- %
.--% &
ErrorMessage--& 2
,--2 3
Loading.. 
=.. 
false.. 
,..  
Initialized// 
=// 
false// #
}00 
;00 
}11 	
}22 
}33 ≈
Ñ/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewDepartments/Store/ViewDepartmentsState.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewDepartments- <
.< =
Store= B
{ 
public 

sealed 
record  
ViewDepartmentsState -
{ 
public		 
bool		 
Initialized		 
{		  !
get		" %
;		% &
init		' +
;		+ ,
}		- .
public

 
bool

 
Loading

 
{

 
get

 !
;

! "
init

# '
;

' (
}

) *
public 
string 
? 
ErrorMessage #
{$ %
get& )
;) *
init+ /
;/ 0
}1 2
public 
List 
< 
DepartmentDetails %
>% &
?& '
DepartmentList( 6
{7 8
get9 <
;< =
init> B
;B C
}D E
public 
MetaData 
? 
MetaData !
{" #
get$ '
;' (
set) ,
;, -
}. /
public  
StringSearchCriteria #
?# $
SearchCriteria% 3
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
} 
} ·
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewWorkerDetails/Pages/ViewEmployeeDialog.razor.cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Features

 
.

 
HumanResources

 ,
.

, -
ViewWorkerDetails

- >
.

> ?
Pages

? D
{ 
public 

partial 
class 
ViewEmployeeDialog +
:, -
ComponentBase. ;
{ 
private 
bool 
	isLoading 
; 
private 
EmployeeDetails 
?  
employee! )
;) *
[ 	
	Parameter	 
( "
CaptureUnmatchedValues )
=* +
true, 0
)0 1
]1 2
public 
IReadOnlyDictionary "
<" #
string# )
,) *
dynamic+ 2
>2 3
?3 4

Attributes5 ?
{@ A
getB E
;E F
setG J
;J K
}L M
[ 	
	Parameter	 
] 
public 
dynamic "
?" #
BusinessEntityID$ 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
[ 	
Inject	 
] 
private 
DialogService &
?& '
DialogService( 5
{6 7
get8 ;
;; <
set= @
;@ A
}B C
[ 	
Inject	 
] 
private 
NotificationService ,
?, -
NotificationService. A
{B C
getD G
;G H
setI L
;L M
}N O
[ 	
Inject	 
] 
private &
IEmployeeRepositoryService 3
?3 4
EmployeeRepository5 G
{H I
getJ M
;M N
setO R
;R S
}T U
	protected 
override 
async  
Task! %
OnInitializedAsync& 8
(8 9
)9 :
{ 	
await 
Load 
( 
) 
; 
await 
base 
. 
OnInitializedAsync )
() *
)* +
;+ ,
} 	
private 
async 
Task 
Load 
(  
)  !
{ 	
	isLoading   
=   
true   
;   
Result"" 
<"" 
EmployeeDetails"" "
>""" #
result""$ *
=""+ ,
await""- 2
EmployeeRepository""3 E
!""E F
.""F G
GetEmployeeDetails""G Y
(""Y Z
BusinessEntityID""Z j
)""j k
;""k l
if$$ 
($$ 
result$$ 
.$$ 
	IsFailure$$  
)$$  !
{%% !
ShowErrorNotification&& %
.&&% &
	ShowError&&& /
(&&/ 0
NotificationService'' '
!''' (
,''( )
result(( 
.(( 
Error((  
.((  !
Message((! (
))) 
;)) 
}** 
else++ 
{,, 
employee-- 
=-- 
result-- !
.--! "
Value--" '
;--' (
}.. 
	isLoading00 
=00 
false00 
;00 
}11 	
	protected33 
void33 &
CloseEmployeeDetailsDialog33 1
(331 2
)332 3
{44 	
DialogService55 
!55 
.55 
Close55  
(55  !
null55! %
)55% &
;55& '
}66 	
}77 
}88 Èã
Å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Features/HumanResources/ViewWorkers/Pages/ViewWorkersPage.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Features 
. 
HumanResources ,
., -
ViewWorkers- 8
.8 9
Pages9 >
{ 
public 

partial 
class 
ViewWorkersPage (
:) *
ComponentBase+ 8
{ 
private 
const 
int 
VIEW_EMPLOYEE '
=( )
$num* +
;+ ,
private 
const 
int 
EDIT_EMPLOYEE '
=( )
$num* +
;+ ,
private 
const 
int 
DELETE_EMPLOYEE )
=* +
$num, -
;- .
private 
bool 
	isLoading 
; 
private 
int 
count 
; 
private 
int 
selectedEmployeeID &
;& '
private 
IEnumerable 
< 
EmployeeListItem ,
>, -
?- .
employeeListItems/ @
;@ A
private 
readonly 
IEnumerable $
<$ %
int% (
>( )
pageSizeOptions* 9
=: ;
new< ?
List@ D
<D E
intE H
>H I
(I J
)J K
{L M
$numN O
,O P
$numQ S
,S T
$numU W
,W X
$numY [
}\ ]
;] ^
private 
RadzenDataGrid 
< 
EmployeeListItem /
>/ 0
?0 1 
employeeListItemGrid2 F
;F G
[ 	
Inject	 
] 
	protected 
NotificationService .
?. /
NotificationService0 C
{D E
getF I
;I J
setK N
;N O
}P Q
[ 	
Inject	 
] 
	protected 
DialogService (
?( )
DialogService* 7
{8 9
get: =
;= >
set? B
;B C
}D E
[   	
Inject  	 
]   
	protected   
ContextMenuService   -
?  - .
ContextMenuService  / A
{  B C
get  D G
;  G H
set  I L
;  L M
}  N O
[!! 	
Inject!!	 
]!! 
private!! &
IEmployeeRepositoryService!! 3
?!!3 4
EmployeeRepository!!5 G
{!!H I
get!!J M
;!!M N
set!!O R
;!!R S
}!!T U
	protected## 
async## 
Task##  
LoadEmployeeListData## 1
(##1 2
LoadDataArgs##2 >
args##? C
)##C D
{$$ 	
try%% 
{&& 
string'' 
searchField'' "
=''# $
string''% +
.''+ ,
Empty'', 1
;''1 2
string(( 
searchCriteria(( %
=((& '
string((( .
.((. /
Empty((/ 4
;((4 5
if** 
(** 
args** 
.** 
Filters**  
is**! #
not**$ '
null**( ,
)**, -
{++ 
List,, 
<,, 
FilterDescriptor,, )
>,,) *
descriptors,,+ 6
=,,7 8
args,,9 =
.,,= >
Filters,,> E
.,,E F
ToList,,F L
(,,L M
),,M N
;,,N O
FilterDescriptor-- $
?--$ %
filterDescriptor--& 6
=.. 
descriptors.. %
...% &
Find..& *
(..* +
x..+ ,
=>..- /
!..0 1
string..1 7
...7 8
IsNullOrEmpty..8 E
(..E F
x..F G
...G H
Property..H P
)..P Q
&&..R T
!..U V
string..V \
...\ ]
IsNullOrEmpty..] j
(..j k
x..k l
...l m
FilterValue..m x
...x y
ToString	..y Å
(
..Å Ç
)
..Ç É
)
..É Ñ
)
..Ñ Ö
;
..Ö Ü
if00 
(00 
filterDescriptor00 (
is00) +
not00, /
null000 4
)004 5
{11 
searchField22 #
=22$ %
filterDescriptor22& 6
.226 7
Property227 ?
;22? @
searchCriteria33 &
=33' (
filterDescriptor33) 9
.339 :
FilterValue33: E
.33E F
ToString33F N
(33N O
)33O P
!33P Q
;33Q R
}44 
}55  
StringSearchCriteria77 $
criteria77% -
=77. /
new770 3
(88 
searchField99 
,99  
searchCriteria:: "
,::" #
!;; 
string;; 
.;; 
IsNullOrEmpty;; )
(;;) *
args;;* .
.;;. /
OrderBy;;/ 6
);;6 7
?;;8 9
args;;: >
.;;> ?
OrderBy;;? F
:;;G H
string;;I O
.;;O P
Empty;;P U
,;;U V
$num<< 
,<< 
$num== 
,== 
args>> 
.>> 
Skip>> 
??>>  
default>>! (
,>>( )
args?? 
.?? 
Top?? 
???? 
default??  '
)@@ 
;@@ 
	isLoadingBB 
=BB 
trueBB  
;BB  !
awaitDD  
GetEmployeeListItemsDD *
(DD* +
criteriaDD+ 3
)DD3 4
;DD4 5
	isLoadingFF 
=FF 
falseFF !
;FF! "
awaitHH 
InvokeAsyncHH !
(HH! "
StateHasChangedHH" 1
)HH1 2
;HH2 3
}JJ 
catchKK 
(KK 
	ExceptionKK 
exKK 
)KK  
{LL !
ShowErrorNotificationMM %
.MM% &
	ShowErrorMM& /
(MM/ 0
NotificationServiceNN '
!NN' (
,NN( )
HelpersOO 
.OO 
GetExceptionMessageOO /
(OO/ 0
exOO0 2
)OO2 3
)PP 
;PP 
}QQ 
}RR 	
privateTT 
asyncTT 
TaskTT  
GetEmployeeListItemsTT /
(TT/ 0 
StringSearchCriteriaTT0 D
criteriaTTE M
)TTM N
{UU 	
ResultVV 
<VV 
	PagedListVV 
<VV 
EmployeeListItemVV -
>VV- .
>VV. /
resultVV0 6
=VV7 8
awaitVV9 >
EmployeeRepositoryVV? Q
!VVQ R
.VVR S 
GetEmployeeListItemsVVS g
(VVg h
criteriaVVh p
)VVp q
;VVq r
ifXX 
(XX 
resultXX 
.XX 
	IsFailureXX  
)XX  !
{YY !
ShowErrorNotificationZZ %
.ZZ% &
	ShowErrorZZ& /
(ZZ/ 0
NotificationService[[ '
![[' (
,[[( )
result\\ 
.\\ 
Error\\  
.\\  !
Message\\! (
)]] 
;]] 
}^^ 
else__ 
{`` 
employeeListItemsaa !
=aa" #
resultaa$ *
.aa* +
Valueaa+ 0
.aa0 1
Itemsaa1 6
;aa6 7
countbb 
=bb 
resultbb 
.bb 
Valuebb $
.bb$ %
MetaDatabb% -
!bb- .
.bb. /

TotalCountbb/ 9
;bb9 :
}cc 
}dd 	
privateff 
voidff 
ShowContextMenuff $
(ff$ %
MouseEventArgsff% 3
argsff4 8
,ff8 9
dynamicff: A
dataffB F
)ffF G
{gg 	
selectedEmployeeIDhh 
=hh  
datahh! %
.hh% &
BusinessEntityIDhh& 6
;hh6 7
ContextMenuServicejj 
!jj 
.jj  
Openjj  $
(jj$ %
argsjj% )
,jj) *
newkk 
Listkk 
<kk 
ContextMenuItemkk (
>kk( )
{kk* +
newll 
ContextMenuItemll #
(ll# $
)ll$ %
{ll% &
Textll' +
=ll, -
$strll. 4
,ll4 5
Valuell6 ;
=ll< =
$numll> ?
,ll? @
IconllA E
=llF G
$strllH T
}llU V
,llV W
newmm 
ContextMenuItemmm #
(mm# $
)mm$ %
{mm% &
Textmm' +
=mm, -
$strmm. 4
,mm4 5
Valuemm6 ;
=mm< =
$nummm> ?
,mm? @
IconmmA E
=mmF G
$strmmH N
}mmO P
,mmP Q
newnn 
ContextMenuItemnn #
(nn# $
)nn$ %
{nn% &
Textnn' +
=nn, -
$strnn. 6
,nn6 7
Valuenn8 =
=nn> ?
$numnn@ A
,nnA B
IconnnC G
=nnH I
$strnnJ Z
}nn[ \
,nn\ ]
}oo 
,oo 
OnMenuItemClickoo 
)oo  
;oo  !
}pp 	
privaterr 
asyncrr 
voidrr 
OnMenuItemClickrr *
(rr* +
MenuItemEventArgsrr+ <
argsrr= A
)rrA B
{ss 	
switchtt 
(tt 
argstt 
.tt 
Valuett 
)tt 
{uu 
casevv 
VIEW_EMPLOYEEvv "
:vv" #
awaitww "
ShowViewEmployeeDialogww 0
(ww0 1
)ww1 2
;ww2 3
breakxx 
;xx 
caseyy 
EDIT_EMPLOYEEyy "
:yy" #
awaitzz "
ShowUpdateWorkerDialogzz 0
(zz0 1
)zz1 2
;zz2 3
break{{ 
;{{ 
case|| 
DELETE_EMPLOYEE|| $
:||$ %
await}} !
ConfirmEmployeeDelete}} /
(}}/ 0
)}}0 1
;}}1 2
break~~ 
;~~ 
default 
: !
NotificationService
ÄÄ '
!
ÄÄ' (
.
ÄÄ( )
Notify
ÄÄ) /
(
ÅÅ 
new
ÇÇ !
NotificationMessage
ÇÇ /
(
ÇÇ/ 0
)
ÇÇ0 1
{
ÉÉ 
Severity
ÑÑ $
=
ÑÑ% &"
NotificationSeverity
ÑÑ' ;
.
ÑÑ; <
Error
ÑÑ< A
,
ÑÑA B
Summary
ÖÖ #
=
ÖÖ$ %
$str
ÖÖ& -
,
ÖÖ- .
Detail
ÜÜ "
=
ÜÜ# $
$str
ÜÜ% >
}
áá 
)
àà 
;
àà 
break
ââ 
;
ââ 
}
ää  
ContextMenuService
åå 
!
åå 
.
åå  
Close
åå  %
(
åå% &
)
åå& '
;
åå' (
}
çç 	
private
èè 
async
èè 
Task
èè $
ShowViewEmployeeDialog
èè 1
(
èè1 2
)
èè2 3
{
êê 	
await
ëë 
DialogService
ëë 
!
ëë  
.
ëë  !
	OpenAsync
ëë! *
<
ëë* + 
ViewEmployeeDialog
ëë+ =
>
ëë= >
(
íí 
$str
ìì .
,
ìì. /
new
îî 

Dictionary
îî "
<
îî" #
string
îî# )
,
îî) *
object
îî+ 1
>
îî1 2
(
îî2 3
)
îî3 4
{
îî5 6
{
îî7 8
$str
îî9 K
,
îîK L 
selectedEmployeeID
îîM _
}
îî` a
}
îîb c
,
îîc d
new
ïï 
DialogOptions
ïï %
(
ïï% &
)
ïï& '
{
ïï( )
Width
ïï* /
=
ïï0 1
$str
ïï2 :
,
ïï: ;
Height
ïï< B
=
ïïC D
$str
ïïE L
,
ïïL M
	Resizable
ïïN W
=
ïïX Y
true
ïïZ ^
,
ïï^ _
	Draggable
ïï` i
=
ïïj k
true
ïïl p
}
ïïq r
)
ññ 
;
ññ 
await
òò "
employeeListItemGrid
òò &
!
òò& '
.
òò' (
Reload
òò( .
(
òò. /
)
òò/ 0
;
òò0 1
await
öö 
InvokeAsync
öö 
(
öö 
(
öö 
)
öö  
=>
öö! #
StateHasChanged
öö$ 3
(
öö3 4
)
öö4 5
)
öö5 6
;
öö6 7
}
õõ 	
private
ùù 
async
ùù 
Task
ùù $
ShowCreateWorkerDialog
ùù 1
(
ùù1 2
)
ùù2 3
{
ûû 	
await
üü 
DialogService
üü 
!
üü  
.
üü  !
	OpenAsync
üü! *
<
üü* + 
CreateWorkerDialog
üü+ =
>
üü= >
(
üü> ?
$str
†† 
,
††  
null
°° 
,
°° 
new
¢¢ 
DialogOptions
¢¢ !
(
¢¢! "
)
¢¢" #
{
¢¢$ %
Width
¢¢& +
=
¢¢, -
$str
¢¢. 6
,
¢¢6 7
Height
¢¢8 >
=
¢¢? @
$str
¢¢A H
,
¢¢H I
	Resizable
¢¢J S
=
¢¢T U
true
¢¢V Z
,
¢¢Z [
	Draggable
¢¢\ e
=
¢¢f g
true
¢¢h l
,
¢¢l m
CloseDialogOnEsc
¢¢n ~
=¢¢ Ä
false¢¢Å Ü
}¢¢á à
)
££ 
;
££ 
await
•• "
employeeListItemGrid
•• &
!
••& '
.
••' (
Reload
••( .
(
••. /
)
••/ 0
;
••0 1
await
ßß 
InvokeAsync
ßß 
(
ßß 
(
ßß 
)
ßß  
=>
ßß! #
StateHasChanged
ßß$ 3
(
ßß3 4
)
ßß4 5
)
ßß5 6
;
ßß6 7
}
®® 	
private
™™ 
async
™™ 
Task
™™ $
ShowUpdateWorkerDialog
™™ 1
(
™™1 2
)
™™2 3
{
´´ 	
await
¨¨ 
DialogService
¨¨ 
!
¨¨  
.
¨¨  !
	OpenAsync
¨¨! *
<
¨¨* + 
UpdateWorkerDialog
¨¨+ =
>
¨¨= >
(
≠≠ 
$str
ÆÆ #
,
ÆÆ# $
new
ØØ 

Dictionary
ØØ "
<
ØØ" #
string
ØØ# )
,
ØØ) *
object
ØØ+ 1
>
ØØ1 2
(
ØØ2 3
)
ØØ3 4
{
ØØ5 6
{
ØØ7 8
$str
ØØ9 K
,
ØØK L 
selectedEmployeeID
ØØM _
}
ØØ` a
}
ØØb c
,
ØØc d
new
∞∞ 
DialogOptions
∞∞ %
(
∞∞% &
)
∞∞& '
{
∞∞( )
Width
∞∞* /
=
∞∞0 1
$str
∞∞2 :
,
∞∞: ;
Height
∞∞< B
=
∞∞C D
$str
∞∞E L
,
∞∞L M
	Resizable
∞∞N W
=
∞∞X Y
true
∞∞Z ^
,
∞∞^ _
	Draggable
∞∞` i
=
∞∞j k
true
∞∞l p
,
∞∞p q
CloseDialogOnEsc∞∞r Ç
=∞∞É Ñ
false∞∞Ö ä
}∞∞ã å
)
±± 
;
±± 
await
≥≥ "
employeeListItemGrid
≥≥ &
!
≥≥& '
.
≥≥' (
Reload
≥≥( .
(
≥≥. /
)
≥≥/ 0
;
≥≥0 1
await
µµ 
InvokeAsync
µµ 
(
µµ 
(
µµ 
)
µµ  
=>
µµ! #
StateHasChanged
µµ$ 3
(
µµ3 4
)
µµ4 5
)
µµ5 6
;
µµ6 7
}
∂∂ 	
private
∏∏ 
async
∏∏ 
Task
∏∏ #
ConfirmEmployeeDelete
∏∏ 0
(
∏∏0 1
)
∏∏1 2
{
ππ 	
try
∫∫ 
{
ªª 
if
ΩΩ 
(
ΩΩ 
await
ΩΩ 
DialogService
ΩΩ '
!
ΩΩ' (
.
ΩΩ( )
Confirm
ΩΩ) 0
(
ΩΩ0 1
$str
ΩΩ1 _
,
ΩΩ_ `
$str
ΩΩa v
)
ΩΩv w
==
ΩΩx z
true
ΩΩ{ 
)ΩΩ Ä
{
ææ 
Result
øø 
result
øø !
=
øø" #
await
øø$ ) 
EmployeeRepository
øø* <
!
øø< =
.
øø= >
DeleteEmployee
øø> L
(
øøL M 
selectedEmployeeID
øøM _
)
øø_ `
;
øø` a
if
¡¡ 
(
¡¡ 
result
¡¡ 
.
¡¡ 
	IsFailure
¡¡ (
)
¡¡( )
{
¬¬ #
ShowErrorNotification
√√ -
.
√√- .
	ShowError
√√. 7
(
√√7 8!
NotificationService
ƒƒ /
!
ƒƒ/ 0
,
ƒƒ0 1
result
≈≈ "
.
≈≈" #
Error
≈≈# (
.
≈≈( )
Message
≈≈) 0
)
≈≈0 1
;
≈≈1 2
}
∆∆ 
else
«« 
{
»» 
await
…… "
employeeListItemGrid
…… 2
!
……2 3
.
……3 4
Reload
……4 :
(
……: ;
)
……; <
;
……< =
await
   
InvokeAsync
   )
(
  ) *
(
  * +
)
  + ,
=>
  - /
StateHasChanged
  0 ?
(
  ? @
)
  @ A
)
  A B
;
  B C
}
ÀÀ 
}
ÃÃ 
}
ÕÕ 
catch
ŒŒ 
(
ŒŒ 
	Exception
ŒŒ 
ex
ŒŒ 
)
ŒŒ  
{
œœ #
ShowErrorNotification
–– %
.
––% &
	ShowError
––& /
(
––/ 0!
NotificationService
—— '
!
——' (
,
——( )
Helpers
““ 
.
““ !
GetExceptionMessage
““ /
(
““/ 0
ex
““0 2
)
““2 3
)
““3 4
;
““4 5
}
”” 
}
‘‘ 	
}
’’ 
}÷÷ Ä
u/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Interfaces/HumanResources/ICompanyRepositoryService.cs
	namespace 	
AWC
 
. 
Client 
. 

Interfaces 
.  
HumanResources  .
{ 
public 

	interface %
ICompanyRepositoryService .
{ 
Task 
< 
Result 
< 
List 
< 
DepartmentId %
>% &
>& '
>' (
GetDepartmentIDs) 9
(9 :
): ;
;; <
Task		 
<		 
Result		 
<		 
List		 
<		 
ShiftId		  
>		  !
>		! "
>		" #
GetShiftIDs		$ /
(		/ 0
)		0 1
;		1 2
}

 
} Ì
v/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Interfaces/HumanResources/IEmployeeRepositoryService.cs
	namespace 	
AWC
 
. 
Client 
. 

Interfaces 
.  
HumanResources  .
{ 
public		 

	interface		 &
IEmployeeRepositoryService		 /
{

 
Task 
< 
Result 
< 
EmployeeDetails #
># $
>$ %
GetEmployeeDetails& 8
(8 9
int9 <
businessEntityID= M
)M N
;N O
Task 
< 
Result 
< 
AWC 
. 
Shared 
. 
Commands '
.' (
HumanResources( 6
.6 7"
EmployeeGenericCommand7 M
>M N
>N O 
GetEmployeeForUpdateP d
(d e
inte h
businessEntityIDi y
)y z
;z {
Task 
< 
Result 
< 
	PagedList 
< 
EmployeeListItem .
>. /
>/ 0
>0 1 
GetEmployeeListItems2 F
(F G 
StringSearchCriteriaG [
criteria\ d
)d e
;e f
Task 
< 
Result 
< 
List 
< 
	StateCode "
>" #
># $
>$ %
GetStateCodes& 3
(3 4
)4 5
;5 6
Task 
< 
Result 
< 
List 
< 
	ManagerId "
>" #
># $
>$ %
GetManagerIDs& 3
(3 4
)4 5
;5 6
Task 
< 
Result 
< 
int 
> 
> 
CreateEmployee (
(( )
AWC) ,
., -
Shared- 3
.3 4
Commands4 <
.< =
HumanResources= K
.K L"
EmployeeGenericCommandL b
employeec k
)k l
;l m
Task 
< 
Result 
> 
UpdateEmployee #
(# $
AWC$ '
.' (
Shared( .
.. /
Commands/ 7
.7 8
HumanResources8 F
.F G"
EmployeeGenericCommandG ]
employee^ f
)f g
;g h
Task 
< 
Result 
> 
DeleteEmployee #
(# $
int$ '
businessEntityId( 8
)8 9
;9 :
} 
} ¥
I/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Program.cs
var 
builder 
= "
WebAssemblyHostBuilder $
.$ %
CreateDefault% 2
(2 3
args3 7
)7 8
;8 9
builder 
. 
RootComponents 
. 
Add 
< 
App 
> 
(  
$str  &
)& '
;' (
builder 
. 
RootComponents 
. 
Add 
< 

HeadOutlet %
>% &
(& '
$str' 4
)4 5
;5 6
builder 
. 
Services 
. 
AddMappings 
( 
) 
; 
builder 
. 
Services 
. 
AddFluentValidation $
($ %
)% &
;& '
builder 
. 
Services 
. 
	AddFluxor 
( 
) 
; 
builder 
. 
Services 
. 
	AddScoped 
< 
DialogService (
>( )
() *
)* +
;+ ,
builder 
. 
Services 
. 
	AddScoped 
< 
NotificationService .
>. /
(/ 0
)0 1
;1 2
builder 
. 
Services 
. 
	AddScoped 
< 
TooltipService )
>) *
(* +
)+ ,
;, -
builder 
. 
Services 
. 
	AddScoped 
< 
ContextMenuService -
>- .
(. /
)/ 0
;0 1
builder 
. 
Services 
. 
	AddScoped 
< &
IEmployeeRepositoryService 5
,5 6%
EmployeeRepositoryService7 P
>P Q
(Q R
)R S
;S T
builder 
. 
Services 
. 
	AddScoped 
< %
ICompanyRepositoryService 4
,4 5$
CompanyRepositoryService6 N
>N O
(O P
)P Q
;Q R
builder 
. 
Services 
. 
AddSingleton 
( 
services &
=>' )
{ 
var 
navigationManager 
= 
services $
.$ %
GetRequiredService% 7
<7 8
NavigationManager8 I
>I J
(J K
)K L
;L M
var 

backendUrl 
= 
navigationManager &
.& '
BaseUri' .
;. /
var 
httpHandler 
= 
new 
GrpcWebHandler (
(( )
GrpcWebMode) 4
.4 5
GrpcWeb5 <
,< =
new> A
HttpClientHandlerB S
(S T
)T U
)U V
;V W
return!! 

GrpcChannel!! 
.!! 

ForAddress!! !
(!!! "

backendUrl!!" ,
,!!, -
new!!. 1
GrpcChannelOptions!!2 D
{!!E F
HttpHandler!!G R
=!!S T
httpHandler!!U `
}!!a b
)!!b c
;!!c d
}"" 
)"" 
;"" 
await$$ 
builder$$ 
.$$ 
Build$$ 
($$ 
)$$ 
.$$ 
RunAsync$$ 
($$ 
)$$  
;$$  !
	namespace&& 	
AWC&&
 
.&& 
Client&& 
{'' 
public(( 

partial(( 
class(( 
Program((  
{)) 
}++ 
},, Å/
r/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/CompanyRepositoryService.cs
	namespace		 	
AWC		
 
.		 
Client		 
.		 
Services		 
.		 
HumanResources		 ,
{

 
public 

sealed 
class $
CompanyRepositoryService 0
:1 2%
ICompanyRepositoryService3 L
{ 
private 
readonly 
IDispatcher $
?$ %
_dispatcher& 1
;1 2
private 
readonly 
IState 
<  #
DepartmentIdLookupState  7
>7 8
?8 9"
_departmentLookupState: P
;P Q
private 
readonly 
IState 
<  
ShiftIdLookupState  2
>2 3
?3 4
_shiftLookupState5 F
;F G
public $
CompanyRepositoryService '
( 	
IDispatcher 

dispatcher "
," #
IState 
< #
DepartmentIdLookupState *
>* +!
departmentLookupState, A
,A B
IState 
< 
ShiftIdLookupState %
>% &
shiftLookupState' 7
) 	
{ 	
_dispatcher 
= 

dispatcher $
;$ %"
_departmentLookupState "
=# $!
departmentLookupState% :
;: ;
_shiftLookupState 
= 
shiftLookupState  0
;0 1
} 	
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
DepartmentId& 2
>2 3
>3 4
>4 5
GetDepartmentIDs6 F
(F G
)G H
{ 	
try 
{   
if!! 
(!! 
!!! "
_departmentLookupState!! +
!!!+ ,
.!!, -
Value!!- 2
.!!2 3
DepartmentIds!!3 @
!!!@ A
.!!A B
Any!!B E
(!!E F
)!!F G
)!!G H
{""  
TaskCompletionSource## (
<##( )
List##) -
<##- .
DepartmentId##. :
>##: ;
>##; <
tcs##= @
=##A B
new##C F
(##F G
)##G H
;##H I
_dispatcher$$ 
!$$  
.$$  !
Dispatch$$! )
($$) *
new$$* -'
LoadDepartmentIdAsyncAction$$. I
($$I J
tcs$$J M
)$$M N
)$$N O
;$$O P
await%% 
tcs%% 
.%% 
Task%% "
;%%" #
return&& 
tcs&& 
.&& 
Task&& #
.&&# $
Result&&$ *
;&&* +
}'' 
else(( 
{)) 
return** "
_departmentLookupState** 1
!**1 2
.**2 3
Value**3 8
.**8 9
DepartmentIds**9 F
!**F G
;**G H
}++ 
},, 
catch-- 
(-- 
	Exception-- 
ex-- 
)--  
{.. 
return// 
Result// 
<// 
List// "
<//" #
DepartmentId//# /
>/// 0
>//0 1
.//1 2
Failure//2 9
<//9 :
List//: >
<//> ?
DepartmentId//? K
>//K L
>//L M
(//M N
new//N Q
Error//R W
(//W X
$str00 ?
,00? @
Helpers11 
.11 
GetExceptionMessage11 /
(11/ 0
ex110 2
)112 3
)113 4
)22 
;22 
}33 
}44 	
public66 
async66 
Task66 
<66 
Result66  
<66  !
List66! %
<66% &
ShiftId66& -
>66- .
>66. /
>66/ 0
GetShiftIDs661 <
(66< =
)66= >
{77 	
try88 
{99 
if:: 
(:: 
!:: 
_shiftLookupState:: &
!::& '
.::' (
Value::( -
.::- .
ShiftIds::. 6
!::6 7
.::7 8
Any::8 ;
(::; <
)::< =
)::= >
{;;  
TaskCompletionSource<< (
<<<( )
List<<) -
<<<- .
ShiftId<<. 5
><<5 6
><<6 7
tcs<<8 ;
=<<< =
new<<> A
(<<A B
)<<B C
;<<C D
_dispatcher== 
!==  
.==  !
Dispatch==! )
(==) *
new==* -"
LoadShiftIdAsyncAction==. D
(==D E
tcs==E H
)==H I
)==I J
;==J K
await>> 
tcs>> 
.>> 
Task>> "
;>>" #
return?? 
tcs?? 
.?? 
Task?? #
.??# $
Result??$ *
;??* +
}@@ 
elseAA 
{BB 
returnCC 
_shiftLookupStateCC ,
!CC, -
.CC- .
ValueCC. 3
.CC3 4
ShiftIdsCC4 <
!CC< =
;CC= >
}DD 
}EE 
catchFF 
(FF 
	ExceptionFF 
exFF 
)FF  
{GG 
returnHH 
ResultHH 
<HH 
ListHH "
<HH" #
ShiftIdHH# *
>HH* +
>HH+ ,
.HH, -
FailureHH- 4
<HH4 5
ListHH5 9
<HH9 :
ShiftIdHH: A
>HHA B
>HHB C
(HHC D
newHHD G
ErrorHHH M
(HHM N
$strII :
,II: ;
HelpersJJ 
.JJ 
GetExceptionMessageJJ /
(JJ/ 0
exJJ0 2
)JJ2 3
)JJ3 4
)KK 
;KK 
}LL 
}MM 	
}NN 
}OO Áπ
s/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/EmployeeRepositoryService.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
{ 
public 

sealed 
class %
EmployeeRepositoryService 1
:2 3&
IEmployeeRepositoryService4 N
{ 
private 
readonly 
GrpcChannel $
?$ %
_channel& .
;. /
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
IDispatcher $
?$ %
_dispatcher& 1
;1 2
private 
readonly 
IState 
<   
ManagerIdLookupState  4
>4 5
?5 6
_managerLookupState7 J
;J K
private 
readonly 
IState 
<  !
StateCodesLookupState  5
>5 6
?6 7!
_stateCodeLookupState8 M
;M N
public %
EmployeeRepositoryService (
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
IDispatcher 

dispatcher "
," #
IState 
<  
ManagerIdLookupState '
>' (
managerLookupState) ;
,; <
IState   
<   !
StateCodesLookupState   (
>  ( ) 
stateCodeLookupState  * >
)!! 	
{"" 	
_channel## 
=## 
channel## 
;## 
_mapper$$ 
=$$ 
mapper$$ 
;$$ 
_dispatcher%% 
=%% 

dispatcher%% $
;%%$ %
_managerLookupState&& 
=&&  !
managerLookupState&&" 4
;&&4 5!
_stateCodeLookupState'' !
=''" # 
stateCodeLookupState''$ 8
;''8 9
}(( 	
public** 
async** 
Task** 
<** 
Result**  
<**  !
AWC**! $
.**$ %
Shared**% +
.**+ ,
Commands**, 4
.**4 5
HumanResources**5 C
.**C D"
EmployeeGenericCommand**D Z
>**Z [
>**[ \ 
GetEmployeeForUpdate**] q
(**q r
int**r u
businessEntityID	**v Ü
)
**Ü á
{++ 	
try,, 
{-- 
var.. 
client.. 
=.. 
new..  
EmployeeContract..! 1
...1 2"
EmployeeContractClient..2 H
(..H I
_channel..I Q
)..Q R
;..R S
ItemRequest// 
request// #
=//$ %
new//& )
(//) *
)//* +
{//, -
Id//. 0
=//1 2
businessEntityID//3 C
}//D E
;//E F'
grpc_EmployeeGenericCommand00 +
grpcResponse00, 8
=009 :
await00; @
client00A G
.00G H#
GetEmployeeForEditAsync00H _
(00_ `
request00` g
)00g h
;00h i
List22 
<22 
AWC22 
.22 
Shared22 
.22  
Commands22  (
.22( )
HumanResources22) 7
.227 8$
DepartmentHistoryCommand228 P
>22P Q
departments22R ]
=22^ _
new22` c
(22c d
)22d e
;22e f
List33 
<33 
AWC33 
.33 
Shared33 
.33  
Commands33  (
.33( )
HumanResources33) 7
.337 8
PayHistoryCommand338 I
>33I J
payHistories33K W
=33X Y
new33Z ]
(33] ^
)33^ _
;33_ `
grpcResponse55 
.55 
DepartmentHistories55 0
.550 1
ToList551 7
(557 8
)558 9
.559 :
ForEach55: A
(55A B
dept55B F
=>55G I
departments66 
.66  
Add66  #
(66# $
_mapper66$ +
.66+ ,
Map66, /
<66/ 0
AWC660 3
.663 4
Shared664 :
.66: ;
Commands66; C
.66C D
HumanResources66D R
.66R S$
DepartmentHistoryCommand66S k
>66k l
(66l m
dept66m q
)66q r
)66r s
)77 
;77 
grpcResponse99 
.99 
PayHistories99 )
.99) *
ToList99* 0
(990 1
)991 2
.992 3
ForEach993 :
(99: ;
pay99; >
=>99? A
payHistories::  
.::  !
Add::! $
(::$ %
_mapper::% ,
.::, -
Map::- 0
<::0 1
AWC::1 4
.::4 5
Shared::5 ;
.::; <
Commands::< D
.::D E
HumanResources::E S
.::S T
PayHistoryCommand::T e
>::e f
(::f g
pay::g j
)::j k
)::k l
);; 
;;; 
var== 
employee== 
=== 
_mapper== &
.==& '
Map==' *
<==* +
AWC==+ .
.==. /
Shared==/ 5
.==5 6
Commands==6 >
.==> ?
HumanResources==? M
.==M N"
EmployeeGenericCommand==N d
>==d e
(==e f
grpcResponse==f r
)==r s
;==s t
employee>> 
.>> 
DepartmentHistories>> ,
!>>, -
.>>- .
AddRange>>. 6
(>>6 7
departments>>7 B
)>>B C
;>>C D
employee?? 
.?? 
PayHistories?? %
!??% &
.??& '
AddRange??' /
(??/ 0
payHistories??0 <
)??< =
;??= >
returnAA 
employeeAA 
;AA  
}BB 
catchCC 
(CC 
	ExceptionCC 
exCC 
)CC  
{DD 
returnEE 
ResultEE 
.EE 
FailureEE %
<EE% &
AWCEE& )
.EE) *
SharedEE* 0
.EE0 1
CommandsEE1 9
.EE9 :
HumanResourcesEE: H
.EEH I"
EmployeeGenericCommandEEI _
>EE_ `
(EE` a
newEEa d
ErrorEEe j
(EEj k
$strFF D
,FFD E
HelpersGG 
.GG 
GetExceptionMessageGG /
(GG/ 0
exGG0 2
)GG2 3
)GG3 4
)HH 
;HH 
}II 
}JJ 	
publicLL 
asyncLL 
TaskLL 
<LL 
ResultLL  
<LL  !
EmployeeDetailsLL! 0
>LL0 1
>LL1 2
GetEmployeeDetailsLL3 E
(LLE F
intLLF I
businessEntityIDLLJ Z
)LLZ [
{MM 	
tryNN 
{OO 
varPP 
clientPP 
=PP 
newPP  
EmployeeContractPP! 1
.PP1 2"
EmployeeContractClientPP2 H
(PPH I
_channelPPI Q
)PPQ R
;PPR S
ItemRequestQQ 
requestQQ #
=QQ$ %
newQQ& )
(QQ) *
)QQ* +
{QQ, -
IdQQ. 0
=QQ1 2
businessEntityIDQQ3 C
}QQD E
;QQE F#
grpc_EmployeeForDisplaySS '
grpcResponseSS( 4
=SS5 6
awaitSS7 <
clientSS= C
.SSC D&
GetEmployeeForDisplayAsyncSSD ^
(SS^ _
requestSS_ f
)SSf g
;SSg h
EmployeeDetailsUU 
employeeUU  (
=UU) *
_mapperUU+ 2
!UU2 3
.UU3 4
MapUU4 7
<UU7 8
EmployeeDetailsUU8 G
>UUG H
(UUH I
grpcResponseUUI U
)UUU V
;UUV W
returnWW 
employeeWW 
;WW  
}XX 
catchYY 
(YY 
	ExceptionYY 
exYY 
)YY  
{ZZ 
return[[ 
Result[[ 
<[[ 
EmployeeDetails[[ -
>[[- .
.[[. /
Failure[[/ 6
<[[6 7
EmployeeDetails[[7 F
>[[F G
([[G H
new[[H K
Error[[L Q
([[Q R
$str\\ B
,\\B C
Helpers]] 
.]] 
GetExceptionMessage]] /
(]]/ 0
ex]]0 2
)]]2 3
)]]3 4
)^^ 
;^^ 
}__ 
}`` 	
publicbb 
asyncbb 
Taskbb 
<bb 
Resultbb  
<bb  !
	PagedListbb! *
<bb* +
EmployeeListItembb+ ;
>bb; <
>bb< =
>bb= > 
GetEmployeeListItemsbb? S
(bbS T 
StringSearchCriteriabbT h
criteriabbi q
)bbq r
{cc 	
trydd 
{ee 
varff 
clientff 
=ff 
newff  
EmployeeContractff! 1
.ff1 2"
EmployeeContractClientff2 H
(ffH I
_channelffI Q
)ffQ R
;ffR S"
grpc_EmployeeListItemsgg &
grpcResponsegg' 3
=gg4 5
awaithh 
clienthh  
.hh  !)
GetEmployeesSearchByNameAsynchh! >
(hh> ?
_mapperhh? F
!hhF G
.hhG H
MaphhH K
<hhK L%
grpc_StringSearchCriteriahhL e
>hhe f
(hhf g
criteriahhg o
)hho p
)hhp q
;hhq r
	PagedListjj 
<jj 
EmployeeListItemjj *
>jj* +
employeeListItemsjj, =
=jj> ?
newjj@ C
(jjC D
)jjD E
{jjF G
ItemsjjH M
=jjN O
newjjP S
(jjS T
)jjT U
}jjV W
;jjW X
grpcResponsell 
.ll 
GrpcEmployeesll *
.ll* +
ToListll+ 1
(ll1 2
)ll2 3
.mm* +
ForEachmm+ 2
(mm2 3
grpcItemmm3 ;
=>mm< >
employeeListItemsmm? P
.mmP Q
ItemsmmQ V
.mmV W
AddmmW Z
(mmZ [
_mappermm[ b
.mmb c
Mapmmc f
<mmf g
EmployeeListItemmmg w
>mmw x
(mmx y
grpcItem	mmy Å
)
mmÅ Ç
)
mmÇ É
)
mmÉ Ñ
;
mmÑ Ö
employeeListItemsoo !
.oo! "
MetaDataoo" *
=oo+ ,
_mapperoo- 4
.oo4 5
Mapoo5 8
<oo8 9
MetaDataoo9 A
>ooA B
(ooB C
grpcResponseooC O
.ooO P
GrpcMetaDataooP \
)oo\ ]
;oo] ^
returnqq 
employeeListItemsqq (
;qq( )
}rr 
catchss 
(ss 
	Exceptionss 
exss 
)ss  
{tt 
returnuu 
Resultuu 
<uu 
	PagedListuu '
<uu' (
EmployeeListItemuu( 8
>uu8 9
>uu9 :
.uu: ;
Failureuu; B
<uuB C
	PagedListuuC L
<uuL M
EmployeeListItemuuM ]
>uu] ^
>uu^ _
(uu_ `
newuu` c
Erroruud i
(uui j
$strvv D
,vvD E
Helpersww 
.ww 
GetExceptionMessageww /
(ww/ 0
exww0 2
)ww2 3
)ww3 4
)xx 
;xx 
}yy 
}zz 	
public|| 
async|| 
Task|| 
<|| 
Result||  
<||  !
List||! %
<||% &
	StateCode||& /
>||/ 0
>||0 1
>||1 2
GetStateCodes||3 @
(||@ A
)||A B
{}} 	
try~~ 
{ 
if
ÄÄ 
(
ÄÄ 
!
ÄÄ #
_stateCodeLookupState
ÄÄ *
!
ÄÄ* +
.
ÄÄ+ ,
Value
ÄÄ, 1
.
ÄÄ1 2

StateCodes
ÄÄ2 <
!
ÄÄ< =
.
ÄÄ= >
Any
ÄÄ> A
(
ÄÄA B
)
ÄÄB C
)
ÄÄC D
{
ÅÅ 
_dispatcher
ÇÇ 
!
ÇÇ  
.
ÇÇ  !
Dispatch
ÇÇ! )
(
ÇÇ) *
new
ÇÇ* -"
LoadStateCodesAction
ÇÇ. B
(
ÇÇB C
)
ÇÇC D
)
ÇÇD E
;
ÇÇE F
while
ÑÑ 
(
ÑÑ #
_stateCodeLookupState
ÑÑ 0
.
ÑÑ0 1
Value
ÑÑ1 6
.
ÑÑ6 7
Loading
ÑÑ7 >
)
ÑÑ> ?
{
ÖÖ 
await
ÜÜ 
Task
ÜÜ "
.
ÜÜ" #
Delay
ÜÜ# (
(
ÜÜ( )
$num
ÜÜ) *
)
ÜÜ* +
;
ÜÜ+ ,
}
áá 
}
àà 
List
ää 
<
ää 
	StateCode
ää 
>
ää 

stateCodes
ää  *
=
ää+ ,#
_stateCodeLookupState
ää- B
.
ääB C
Value
ääC H
.
ääH I

StateCodes
ääI S
!
ääS T
;
ääT U
return
åå 

stateCodes
åå !
;
åå! "
}
çç 
catch
éé 
(
éé 
	Exception
éé 
ex
éé 
)
éé  
{
èè 
return
êê 
Result
êê 
<
êê 
List
êê "
<
êê" #
	StateCode
êê# ,
>
êê, -
>
êê- .
.
êê. /
Failure
êê/ 6
<
êê6 7
List
êê7 ;
<
êê; <
	StateCode
êê< E
>
êêE F
>
êêF G
(
êêG H
new
êêH K
Error
êêL Q
(
êêQ R
$str
ëë =
,
ëë= >
Helpers
íí 
.
íí !
GetExceptionMessage
íí /
(
íí/ 0
ex
íí0 2
)
íí2 3
)
íí3 4
)
ìì 
;
ìì 
}
îî 
}
ïï 	
public
óó 
async
óó 
Task
óó 
<
óó 
Result
óó  
<
óó  !
List
óó! %
<
óó% &
	ManagerId
óó& /
>
óó/ 0
>
óó0 1
>
óó1 2
GetManagerIDs
óó3 @
(
óó@ A
)
óóA B
{
òò 	
try
ôô 
{
öö 
if
õõ 
(
õõ 
!
õõ !
_managerLookupState
õõ (
!
õõ( )
.
õõ) *
Value
õõ* /
.
õõ/ 0

ManagerIds
õõ0 :
!
õõ: ;
.
õõ; <
Any
õõ< ?
(
õõ? @
)
õõ@ A
)
õõA B
{
úú "
TaskCompletionSource
ùù (
<
ùù( )
List
ùù) -
<
ùù- .
	ManagerId
ùù. 7
>
ùù7 8
>
ùù8 9
tcs
ùù: =
=
ùù> ?
new
ùù@ C
(
ùùC D
)
ùùD E
;
ùùE F
_dispatcher
ûû 
!
ûû  
.
ûû  !
Dispatch
ûû! )
(
ûû) *
new
ûû* -&
LoadManagerIdAsyncAction
ûû. F
(
ûûF G
tcs
ûûG J
)
ûûJ K
)
ûûK L
;
ûûL M
await
üü 
tcs
üü 
.
üü 
Task
üü "
;
üü" #
return
†† 
tcs
†† 
.
†† 
Task
†† #
.
††# $
Result
††$ *
;
††* +
}
°° 
else
¢¢ 
{
££ 
return
§§ !
_managerLookupState
§§ .
.
§§. /
Value
§§/ 4
.
§§4 5

ManagerIds
§§5 ?
!
§§? @
;
§§@ A
}
•• 
}
¶¶ 
catch
ßß 
(
ßß 
	Exception
ßß 
ex
ßß 
)
ßß  
{
®® 
return
©© 
Result
©© 
<
©© 
List
©© "
<
©©" #
	ManagerId
©©# ,
>
©©, -
>
©©- .
.
©©. /
Failure
©©/ 6
<
©©6 7
List
©©7 ;
<
©©; <
	ManagerId
©©< E
>
©©E F
>
©©F G
(
©©G H
new
©©H K
Error
©©L Q
(
©©Q R
$str
™™ =
,
™™= >
Helpers
´´ 
.
´´ !
GetExceptionMessage
´´ /
(
´´/ 0
ex
´´0 2
)
´´2 3
)
´´3 4
)
¨¨ 
;
¨¨ 
}
≠≠ 
}
ÆÆ 	
public
∞∞ 
async
∞∞ 
Task
∞∞ 
<
∞∞ 
Result
∞∞  
<
∞∞  !
int
∞∞! $
>
∞∞$ %
>
∞∞% &
CreateEmployee
∞∞' 5
(
∞∞5 6
AWC
∞∞6 9
.
∞∞9 :
Shared
∞∞: @
.
∞∞@ A
Commands
∞∞A I
.
∞∞I J
HumanResources
∞∞J X
.
∞∞X Y$
EmployeeGenericCommand
∞∞Y o
employee
∞∞p x
)
∞∞x y
{
±± 	
try
≤≤ 
{
≥≥ 
var
¥¥ 
client
¥¥ 
=
¥¥ 
new
¥¥  
EmployeeContract
¥¥! 1
.
¥¥1 2$
EmployeeContractClient
¥¥2 H
(
¥¥H I
_channel
¥¥I Q
)
¥¥Q R
;
¥¥R S)
grpc_EmployeeGenericCommand
µµ +
command
µµ, 3
=
µµ4 5
_mapper
µµ6 =
.
µµ= >
Map
µµ> A
<
µµA B)
grpc_EmployeeGenericCommand
µµB ]
>
µµ] ^
(
µµ^ _
employee
µµ_ g
)
µµg h
;
µµh i
List
∑∑ 
<
∑∑ +
grpc_DepartmentHistoryCommand
∑∑ 2
>
∑∑2 3
grpcDeptHist
∑∑4 @
=
∑∑A B
new
∑∑C F
(
∑∑F G
)
∑∑G H
;
∑∑H I
employee
∏∏ 
.
∏∏ !
DepartmentHistories
∏∏ ,
!
∏∏, -
.
∏∏- .
ToList
∏∏. 4
(
∏∏4 5
)
∏∏5 6
.
∏∏6 7
ForEach
∏∏7 >
(
∏∏> ?
d
∏∏? @
=>
∏∏A C
grpcDeptHist
ππ  
.
ππ  !
Add
ππ! $
(
ππ$ %
_mapper
ππ% ,
.
ππ, -
Map
ππ- 0
<
ππ0 1+
grpc_DepartmentHistoryCommand
ππ1 N
>
ππN O
(
ππO P
d
ππP Q
)
ππQ R
)
ππR S
)
∫∫ 
;
∫∫ 
List
ºº 
<
ºº $
grpc_PayHistoryCommand
ºº +
>
ºº+ ,
grpcPayHist
ºº- 8
=
ºº9 :
new
ºº; >
(
ºº> ?
)
ºº? @
;
ºº@ A
employee
ΩΩ 
.
ΩΩ 
PayHistories
ΩΩ %
!
ΩΩ% &
.
ΩΩ& '
ToList
ΩΩ' -
(
ΩΩ- .
)
ΩΩ. /
.
ΩΩ/ 0
ForEach
ΩΩ0 7
(
ΩΩ7 8
p
ΩΩ8 9
=>
ΩΩ: <
grpcPayHist
ææ 
.
ææ  
Add
ææ  #
(
ææ# $
_mapper
ææ$ +
.
ææ+ ,
Map
ææ, /
<
ææ/ 0$
grpc_PayHistoryCommand
ææ0 F
>
ææF G
(
ææG H
p
ææH I
)
ææI J
)
ææJ K
)
øø 
;
øø 
command
¡¡ 
.
¡¡ !
DepartmentHistories
¡¡ +
.
¡¡+ ,
AddRange
¡¡, 4
(
¡¡4 5
grpcDeptHist
¡¡5 A
)
¡¡A B
;
¡¡B C
command
¬¬ 
.
¬¬ 
PayHistories
¬¬ $
.
¬¬$ %
AddRange
¬¬% -
(
¬¬- .
grpcPayHist
¬¬. 9
)
¬¬9 :
;
¬¬: ;
CreateResponse
ƒƒ 
grpcResponse
ƒƒ +
=
ƒƒ, -
await
ƒƒ. 3
client
ƒƒ4 :
.
ƒƒ: ;
CreateAsync
ƒƒ; F
(
ƒƒF G
command
ƒƒG N
)
ƒƒN O
;
ƒƒO P
return
∆∆ 
grpcResponse
∆∆ #
.
∆∆# $
Id
∆∆$ &
;
∆∆& '
}
«« 
catch
»» 
(
»» 
	Exception
»» 
ex
»» 
)
»»  
{
…… 
return
   
Result
   
<
   
int
   !
>
  ! "
.
  " #
Failure
  # *
<
  * +
int
  + .
>
  . /
(
  / 0
new
  0 3
Error
  4 9
(
  9 :
$str
ÀÀ >
,
ÀÀ> ?
Helpers
ÃÃ 
.
ÃÃ !
GetExceptionMessage
ÃÃ /
(
ÃÃ/ 0
ex
ÃÃ0 2
)
ÃÃ2 3
)
ÃÃ3 4
)
ÕÕ 
;
ÕÕ 
}
ŒŒ 
}
œœ 	
public
—— 
async
—— 
Task
—— 
<
—— 
Result
——  
>
——  !
UpdateEmployee
——" 0
(
——0 1
AWC
——1 4
.
——4 5
Shared
——5 ;
.
——; <
Commands
——< D
.
——D E
HumanResources
——E S
.
——S T$
EmployeeGenericCommand
——T j
employee
——k s
)
——s t
{
““ 	
try
”” 
{
‘‘ 
var
’’ 
client
’’ 
=
’’ 
new
’’  
EmployeeContract
’’! 1
.
’’1 2$
EmployeeContractClient
’’2 H
(
’’H I
_channel
’’I Q
)
’’Q R
;
’’R S)
grpc_EmployeeGenericCommand
÷÷ +
command
÷÷, 3
=
÷÷4 5
_mapper
÷÷6 =
.
÷÷= >
Map
÷÷> A
<
÷÷A B)
grpc_EmployeeGenericCommand
÷÷B ]
>
÷÷] ^
(
÷÷^ _
employee
÷÷_ g
)
÷÷g h
;
÷÷h i
await
◊◊ 
client
◊◊ 
.
◊◊ 
UpdateAsync
◊◊ (
(
◊◊( )
command
◊◊) 0
)
◊◊0 1
;
◊◊1 2
return
ŸŸ 
Result
ŸŸ 
.
ŸŸ 
Success
ŸŸ %
(
ŸŸ% &
)
ŸŸ& '
;
ŸŸ' (
}
⁄⁄ 
catch
€€ 
(
€€ 
	Exception
€€ 
ex
€€ 
)
€€  
{
‹‹ 
return
›› 
Result
›› 
.
›› 
Failure
›› %
(
››% &
new
››& )
Error
››* /
(
››/ 0
$str
ﬁﬁ >
,
ﬁﬁ> ?
Helpers
ﬂﬂ 
.
ﬂﬂ !
GetExceptionMessage
ﬂﬂ /
(
ﬂﬂ/ 0
ex
ﬂﬂ0 2
)
ﬂﬂ2 3
)
ﬂﬂ3 4
)
‡‡ 
;
‡‡ 
}
·· 
}
‚‚ 	
public
‰‰ 
async
‰‰ 
Task
‰‰ 
<
‰‰ 
Result
‰‰  
>
‰‰  !
DeleteEmployee
‰‰" 0
(
‰‰0 1
int
‰‰1 4
businessEntityId
‰‰5 E
)
‰‰E F
{
ÂÂ 	
try
ÊÊ 
{
ÁÁ 
var
ËË 
client
ËË 
=
ËË 
new
ËË  
EmployeeContract
ËË! 1
.
ËË1 2$
EmployeeContractClient
ËË2 H
(
ËËH I
_channel
ËËI Q
)
ËËQ R
;
ËËR S
ItemRequest
ÈÈ 
request
ÈÈ #
=
ÈÈ$ %
new
ÈÈ& )
(
ÈÈ) *
)
ÈÈ* +
{
ÈÈ, -
Id
ÈÈ. 0
=
ÈÈ1 2
businessEntityId
ÈÈ3 C
}
ÈÈD E
;
ÈÈE F
await
ÍÍ 
client
ÍÍ 
.
ÍÍ 
DeleteAsync
ÍÍ (
(
ÍÍ( )
request
ÍÍ) 0
)
ÍÍ0 1
;
ÍÍ1 2
return
ÏÏ 
Result
ÏÏ 
.
ÏÏ 
Success
ÏÏ %
(
ÏÏ% &
)
ÏÏ& '
;
ÏÏ' (
}
ÌÌ 
catch
ÓÓ 
(
ÓÓ 
	Exception
ÓÓ 
ex
ÓÓ 
)
ÓÓ  
{
ÔÔ 
return
 
Result
 
.
 
Failure
 %
(
% &
new
& )
Error
* /
(
/ 0
$str
ÒÒ >
,
ÒÒ> ?
Helpers
ÚÚ 
.
ÚÚ !
GetExceptionMessage
ÚÚ /
(
ÚÚ/ 0
ex
ÚÚ0 2
)
ÚÚ2 3
)
ÚÚ3 4
)
ÛÛ 
;
ÛÛ 
}
ÙÙ 
}
ıı 	
}
ˆˆ 
}˜˜ ∏

y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/DepartmentIdLookupFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
class %
DepartmentIdLookupFeature 1
:2 3
Feature4 ;
<; <#
DepartmentIdLookupState< S
>S T
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, E
;E F
	protected		 
override		 #
DepartmentIdLookupState		 2
GetInitialState		3 B
(		B C
)		C D
=>		E G
new

 
(

 
)

 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,
DepartmentIds 
= 
new  #
(# $
)$ %
,% &
} 
; 
} 
} ú	
w/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/DepartmentIdLookupState.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
record #
DepartmentIdLookupState 0
{ 
public 
bool 
Initialized 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
bool 
Loading 
{ 
get !
;! "
init# '
;' (
}) *
public		 
string		 
?		 
ErrorMessage		 #
{		$ %
get		& )
;		) *
init		+ /
;		/ 0
}		1 2
public

 
List

 
<

 
DepartmentId

  
>

  !
?

! "
DepartmentIds

# 0
{

1 2
get

3 6
;

6 7
init

8 <
;

< =
}

> ?
} 
} ≈
á/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Departments/LoadDepartmentIdAsyncAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Departments3 >
{ 
public 

sealed 
record '
LoadDepartmentIdAsyncAction 4
(4 5 
TaskCompletionSource5 I
<I J
ListJ N
<N O
DepartmentIdO [
>[ \
>\ ] 
TaskCompletionSource^ r
)r s
;s t
} ’
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Departments/LoadDepartmentIdAsyncFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Departments3 >
{ 
public 

sealed 
record .
"LoadDepartmentIdAsyncFailureAction ;
(; <
string< B
ErrorMessageC O
)O P
;P Q
} ä
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Departments/LoadDepartmentIdAsyncSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Departments3 >
{ 
public 

sealed 
record .
"LoadDepartmentIdAsyncSuccessAction ;
(; <
List< @
<@ A
DepartmentIdA M
>M N
DepartmentsO Z
)Z [
;[ \
} °
Ñ/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Departments/LoadDepartmentIdReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Departments3 >
{ 
public 

static 
class $
LoadDepartmentIdReducers 0
{ 
[ 	
ReducerMethod	 
( 
typeof 
( '
LoadDepartmentIdAsyncAction 9
)9 :
): ;
]; <
public 
static #
DepartmentIdLookupState -)
OnLoadDepartmentIdAsyncAction. K
(		 	#
DepartmentIdLookupState

 #
state

$ )
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
true 
} 
; 
} 	
[ 	
ReducerMethod	 
] 
public 
static #
DepartmentIdLookupState -,
 OnLoadDepartmentIDsSuccessAction. N
( 	#
DepartmentIdLookupState #
state$ )
,) *.
"LoadDepartmentIdAsyncSuccessAction .
action/ 5
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
false 
,  
DepartmentIds 
= 
action  &
.& '
Departments' 2
} 
; 
} 	
[!! 	
ReducerMethod!!	 
]!! 
public"" 
static"" #
DepartmentIdLookupState"" -,
 OnLoadDepartmentIDsFailureAction"". N
(## 	#
DepartmentIdLookupState$$ #
state$$$ )
,$$) *.
"LoadDepartmentIdAsyncFailureAction%% .
action%%/ 5
)&& 	
{'' 	
return(( 
state(( 
with(( 
{)) 
Initialized** 
=** 
false** #
,**# $
Loading++ 
=++ 
false++ 
,++  
ErrorMessage,, 
=,, 
action,, %
.,,% &
ErrorMessage,,& 2
}-- 
;-- 
}.. 	
}// 
}00 ¡#
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Departments/LoadDepartmentIdsEffects .cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Services

 
.

 
HumanResources

 ,
.

, -
Store

- 2
.

2 3
Departments

3 >
{ 
public 

sealed 
class $
LoadDepartmentIdsEffects 0
:1 2
Effect3 9
<9 :'
LoadDepartmentIdAsyncAction: U
>U V
{ 
private 
readonly 
GrpcChannel $
_channel% -
;- .
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
NotificationService , 
_notificationService- A
;A B
public $
LoadDepartmentIdsEffects '
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
NotificationService 
notificationService  3
) 	
{ 	
_channel 
= 
channel 
; 
_mapper 
= 
mapper 
;  
_notificationService  
=! "
notificationService# 6
;6 7
} 	
public 
override 
async 
Task "
HandleAsync# .
( 	'
LoadDepartmentIdAsyncAction   '
action  ( .
,  . /
IDispatcher!! 

dispatcher!! "
)"" 	
{## 	
try$$ 
{%% 
var&& 
client&& 
=&& 
new&&  
LookupsContract&&! 0
.&&0 1!
LookupsContractClient&&1 F
(&&F G
_channel&&G O
)&&O P
;&&P Q
var'' 
stream'' 
='' 
client'' #
.''# $
GetDepartmentIds''$ 4
(''4 5
new''5 8
Empty''9 >
(''> ?
)''? @
)''@ A
.''A B
ResponseStream''B P
;''P Q
List)) 
<)) 
DepartmentId)) !
>))! "
departments))# .
=))/ 0
new))1 4
())4 5
)))5 6
;))6 7
while++ 
(++ 
await++ 
stream++ #
.++# $
MoveNext++$ ,
(++, -
default++- 4
)++4 5
)++5 6
{,, 
grpc_DepartmentId-- %
dept--& *
=--+ ,
stream--- 3
.--3 4
Current--4 ;
;--; <
departments.. 
...  
Add..  #
(..# $
_mapper..$ +
...+ ,
Map.., /
<../ 0
DepartmentId..0 <
>..< =
(..= >
dept..> B
)..B C
)..C D
;..D E
}// 
action11 
.11  
TaskCompletionSource11 +
.11+ ,
	SetResult11, 5
(115 6
departments116 A
)11A B
;11B C

dispatcher33 
.33 
Dispatch33 #
(33# $
new33$ '.
"LoadDepartmentIdAsyncSuccessAction33( J
(33J K
departments33K V
)33V W
)33W X
;33X Y
}44 
catch55 
(55 
	Exception55 
ex55 
)55  
{66  
_notificationService77 $
!77$ %
.77% &
Notify77& ,
(77, -
new88 
NotificationMessage88 +
{99 
Severity::  
=::! " 
NotificationSeverity::# 7
.::7 8
Error::8 =
,::= >
Style;; 
=;; 
$str;;  [
,;;[ \
Detail<< 
=<<  
Helpers<<! (
.<<( )
GetExceptionMessage<<) <
(<<< =
ex<<= ?
)<<? @
,<<@ A
Duration==  
===! "
$num==# (
}>> 
)?? 
;?? 

dispatcherAA 
.AA 
DispatchAA #
(AA# $
newAA$ '.
"LoadDepartmentIdAsyncFailureActionAA( J
(AAJ K
HelpersAAK R
.AAR S
GetExceptionMessageAAS f
(AAf g
exAAg i
)AAi j
)AAj k
)AAk l
;AAl m
}BB 
}CC 	
}DD 
}EE ©

v/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/ManagerIdLookupFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
class "
ManagerIdLookupFeature .
:/ 0
Feature1 8
<8 9 
ManagerIdLookupState9 M
>M N
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, B
;B C
	protected		 
override		  
ManagerIdLookupState		 /
GetInitialState		0 ?
(		? @
)		@ A
=>		B D
new

 
(

 
)

 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,

ManagerIds 
= 
new  
(  !
)! "
," #
} 
; 
} 
} ê	
t/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/ManagerIdLookupState.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
record  
ManagerIdLookupState -
{ 
public 
bool 
Initialized 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
bool 
Loading 
{ 
get !
;! "
init# '
;' (
}) *
public		 
string		 
?		 
ErrorMessage		 #
{		$ %
get		& )
;		) *
init		+ /
;		/ 0
}		1 2
public

 
List

 
<

 
	ManagerId

 
>

 
?

 

ManagerIds

  *
{

+ ,
get

- 0
;

0 1
init

2 6
;

6 7
}

8 9
} 
} ©
Å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Managers/LoadManagerIdAsyncAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Managers3 ;
;; <
public 
sealed 
record $
LoadManagerIdAsyncAction -
(- . 
TaskCompletionSource. B
<B C
ListC G
<G H
	ManagerIdH Q
>Q R
>R S 
TaskCompletionSourceT h
)h i
;i jº
à/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Managers/LoadManagerIdAsyncFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Managers3 ;
;; <
public 
sealed 
record +
LoadManagerIdAsyncFailureAction 4
(4 5
string5 ;
ErrorMessage< H
)H I
;I J¯
à/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Managers/LoadManagerIdAsyncSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Managers3 ;
{ 
public 

sealed 
record +
LoadManagerIdAsyncSuccessAction 8
(8 9
List9 =
<= >
	ManagerId> G
>G H
ManagersI Q
)Q R
;R S
} ﬂ
~/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Managers/LoadManagerIdReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Managers3 ;
;; <
public 
static 
class !
LoadManagerIdReducers )
{ 
[ 
ReducerMethod 
( 
typeof 
( *
SetManagerIDsLoadingFlagAction 8
)8 9
)9 :
]: ;
public 

static  
ManagerIdLookupState &&
OnLoadingSManagerIdsAction' A
(		  
ManagerIdLookupState

 
state

 "
) 
{ 
return 
state 
with 
{ 	
Loading 
= 
true 
} 	
;	 

} 
[ 
ReducerMethod 
] 
public 

static  
ManagerIdLookupState &)
OnLoadManagerIdsSuccessAction' D
(  
ManagerIdLookupState 
state "
," #+
LoadManagerIdAsyncSuccessAction '
action( .
) 
{ 
return 
state 
with 
{ 	
Loading 
= 
false 
, 

ManagerIds 
= 
action 
.  
Managers  (
} 	
;	 

} 
[!! 
ReducerMethod!! 
]!! 
public"" 

static""  
ManagerIdLookupState"" &)
OnLoadManagerIdsFailureAction""' D
(##  
ManagerIdLookupState$$ 
state$$ "
,$$" #+
LoadManagerIdAsyncFailureAction%% '
action%%( .
)&& 
{'' 
return(( 
state(( 
with(( 
{)) 	
Initialized** 
=** 
false** 
,**  
Loading++ 
=++ 
false++ 
,++ 
ErrorMessage,, 
=,, 
action,, !
.,,! "
ErrorMessage,," .
}-- 	
;--	 

}.. 
}// œ$
~/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Managers/LoadManagerIdsEffects.cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Services

 
.

 
HumanResources

 ,
.

, -
Store

- 2
.

2 3
Managers

3 ;
{ 
public 

sealed 
class !
LoadManagerIdsEffects -
:. /
Effect0 6
<6 7$
LoadManagerIdAsyncAction7 O
>O P
{ 
private 
readonly 
GrpcChannel $
_channel% -
;- .
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
NotificationService , 
_notificationService- A
;A B
public !
LoadManagerIdsEffects $
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
NotificationService 
notificationService  3
) 	
{ 	
_channel 
= 
channel 
; 
_mapper 
= 
mapper 
;  
_notificationService  
=! "
notificationService# 6
;6 7
} 	
public 
override 
async 
Task "
HandleAsync# .
( 	$
LoadManagerIdAsyncAction   $
action  % +
,  + ,
IDispatcher!! 

dispatcher!! "
)"" 	
{## 	
try$$ 
{%% 

dispatcher&& 
.&& 
Dispatch&& #
(&&# $
new&&$ '*
SetManagerIDsLoadingFlagAction&&( F
(&&F G
)&&G H
)&&H I
;&&I J
var(( 
client(( 
=(( 
new((  
LookupsContract((! 0
.((0 1!
LookupsContractClient((1 F
(((F G
_channel((G O
)((O P
;((P Q
var)) 
stream)) 
=)) 
client)) #
.))# $
GetManagerIds))$ 1
())1 2
new))2 5
Empty))6 ;
()); <
)))< =
)))= >
.))> ?
ResponseStream))? M
;))M N
List++ 
<++ 
	ManagerId++ 
>++ 
managers++  (
=++) *
new+++ .
(++. /
)++/ 0
;++0 1
while-- 
(-- 
await-- 
stream-- #
.--# $
MoveNext--$ ,
(--, -
default--- 4
)--4 5
)--5 6
{.. 
grpc_ManagerId// "
mgr//# &
=//' (
stream//) /
./// 0
Current//0 7
;//7 8
managers00 
.00 
Add00  
(00  !
_mapper00! (
.00( )
Map00) ,
<00, -
	ManagerId00- 6
>006 7
(007 8
mgr008 ;
)00; <
)00< =
;00= >
}11 
action33 
.33  
TaskCompletionSource33 +
.33+ ,
	SetResult33, 5
(335 6
managers336 >
)33> ?
;33? @

dispatcher55 
.55 
Dispatch55 #
(55# $
new55$ '+
LoadManagerIdAsyncSuccessAction55( G
(55G H
managers55H P
)55P Q
)55Q R
;55R S
}66 
catch77 
(77 
	Exception77 
ex77 
)77  
{88  
_notificationService99 $
!99$ %
.99% &
Notify99& ,
(99, -
new:: 
NotificationMessage:: +
{;; 
Severity<<  
=<<! " 
NotificationSeverity<<# 7
.<<7 8
Error<<8 =
,<<= >
Style== 
=== 
$str==  [
,==[ \
Detail>> 
=>>  
Helpers>>! (
.>>( )
GetExceptionMessage>>) <
(>>< =
ex>>= ?
)>>? @
,>>@ A
Duration??  
=??! "
$num??# (
}@@ 
)AA 
;AA 

dispatcherCC 
.CC 
DispatchCC #
(CC# $
newCC$ '+
LoadManagerIdAsyncFailureActionCC( G
(CCG H
HelpersCCH O
.CCO P
GetExceptionMessageCCP c
(CCc d
exCCd f
)CCf g
)CCg h
)CCh i
;CCi j
}DD 
}EE 	
}FF 
}GG ‰
á/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Managers/SetManagerIDsLoadingFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Managers3 ;
;; <
public 
sealed 
record *
SetManagerIDsLoadingFlagAction 3
(3 4
int4 7$
SuppressSonarqubeWarning8 P
=Q R
$numS T
)T U
;U Vü

t/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/ShiftIdLookupFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
class  
ShiftIdLookupFeature ,
:- .
Feature/ 6
<6 7
ShiftIdLookupState7 I
>I J
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, @
;@ A
	protected		 
override		 
ShiftIdLookupState		 -
GetInitialState		. =
(		= >
)		> ?
=>		@ B
new

 
(

 
)

 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,
ShiftIds 
= 
new 
( 
)  
,  !
} 
; 
} 
} à	
r/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/ShiftIdLookupState.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
record 
ShiftIdLookupState +
{ 
public 
bool 
Initialized 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
bool 
Loading 
{ 
get !
;! "
init# '
;' (
}) *
public		 
string		 
?		 
ErrorMessage		 #
{		$ %
get		& )
;		) *
init		+ /
;		/ 0
}		1 2
public

 
List

 
<

 
ShiftId

 
>

 
?

 
ShiftIds

 &
{

' (
get

) ,
;

, -
init

. 2
;

2 3
}

4 5
} 
} ´
}/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Shifts/LoadShiftIdAsyncAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Shifts3 9
{ 
public 

sealed 
record "
LoadShiftIdAsyncAction /
(/ 0 
TaskCompletionSource0 D
<D E
ListE I
<I J
ShiftIdJ Q
>Q R
>R S 
TaskCompletionSourceT h
)h i
;i j
} ¡
Ñ/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Shifts/LoadShiftIdAsyncFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Shifts3 9
{ 
public 

sealed 
record )
LoadShiftIdAsyncFailureAction 6
(6 7
string7 =
ErrorMessage> J
)J K
;K L
} Ï
Ñ/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Shifts/LoadShiftIdAsyncSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Shifts3 9
{ 
public 

sealed 
record )
LoadShiftIdAsyncSuccessAction 6
(6 7
List7 ;
<; <
ShiftId< C
>C D
ShiftsE K
)K L
;L M
} Ï"
z/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Shifts/LoadShiftIdsEffects.cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Services

 
.

 
HumanResources

 ,
.

, -
Store

- 2
.

2 3
Shifts

3 9
{ 
public 

sealed 
class 
LoadShiftIdsEffects +
:, -
Effect. 4
<4 5"
LoadShiftIdAsyncAction5 K
>K L
{ 
private 
readonly 
GrpcChannel $
_channel% -
;- .
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
NotificationService , 
_notificationService- A
;A B
public 
LoadShiftIdsEffects "
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
NotificationService 
notificationService  3
) 	
{ 	
_channel 
= 
channel 
; 
_mapper 
= 
mapper 
;  
_notificationService  
=! "
notificationService# 6
;6 7
} 	
public 
override 
async 
Task "
HandleAsync# .
( 	"
LoadShiftIdAsyncAction   "
action  # )
,  ) *
IDispatcher!! 

dispatcher!! "
)"" 	
{## 	
try$$ 
{%% 
var&& 
client&& 
=&& 
new&&  
LookupsContract&&! 0
.&&0 1!
LookupsContractClient&&1 F
(&&F G
_channel&&G O
)&&O P
;&&P Q
var'' 
stream'' 
='' 
client'' #
.''# $
GetShiftIds''$ /
(''/ 0
new''0 3
Empty''4 9
(''9 :
)'': ;
)''; <
.''< =
ResponseStream''= K
;''K L
List)) 
<)) 
ShiftId)) 
>)) 
shifts)) $
=))% &
new))' *
())* +
)))+ ,
;)), -
while++ 
(++ 
await++ 
stream++ #
.++# $
MoveNext++$ ,
(++, -
default++- 4
)++4 5
)++5 6
{,, 
grpc_ShiftId--  
shift--! &
=--' (
stream--) /
.--/ 0
Current--0 7
;--7 8
shifts.. 
... 
Add.. 
(.. 
_mapper.. &
...& '
Map..' *
<..* +
ShiftId..+ 2
>..2 3
(..3 4
shift..4 9
)..9 :
)..: ;
;..; <
}// 
action11 
.11  
TaskCompletionSource11 +
.11+ ,
	SetResult11, 5
(115 6
shifts116 <
)11< =
;11= >

dispatcher33 
.33 
Dispatch33 #
(33# $
new33$ ')
LoadShiftIdAsyncSuccessAction33( E
(33E F
shifts33F L
)33L M
)33M N
;33N O
}44 
catch55 
(55 
	Exception55 
ex55 
)55  
{66  
_notificationService77 $
!77$ %
.77% &
Notify77& ,
(77, -
new88 
NotificationMessage88 +
{99 
Severity::  
=::! " 
NotificationSeverity::# 7
.::7 8
Error::8 =
,::= >
Style;; 
=;; 
$str;;  [
,;;[ \
Detail<< 
=<<  
Helpers<<! (
.<<( )
GetExceptionMessage<<) <
(<<< =
ex<<= ?
)<<? @
,<<@ A
Duration==  
===! "
$num==# (
}>> 
)?? 
;?? 

dispatcherAA 
.AA 
DispatchAA #
(AA# $
newAA$ ')
LoadShiftIdAsyncFailureActionAA( E
(AAE F
HelpersAAF M
.AAM N
GetExceptionMessageAAN a
(AAa b
exAAb d
)AAd e
)AAe f
)AAf g
;AAg h
}BB 
}CC 	
}DD 
}EE Ã
y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/Shifts/LoadShiftsReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3
Shifts3 9
{ 
public 

static 
class 
LoadShiftsReducers *
{ 
[ 	
ReducerMethod	 
( 
typeof 
( "
LoadShiftIdAsyncAction 4
)4 5
)5 6
]6 7
public 
static 
ShiftIdLookupState ($
OnLoadShiftIdAsyncAction) A
(		 	
ShiftIdLookupState

 
state

 $
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
true 
} 
; 
} 	
[ 	
ReducerMethod	 
] 
public 
static 
ShiftIdLookupState (+
OnLoadShiftIdAsyncSuccessAction) H
( 	
ShiftIdLookupState 
state $
,$ %)
LoadShiftIdAsyncSuccessAction )
action* 0
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
false 
,  
ShiftIds 
= 
action !
.! "
Shifts" (
} 
; 
} 	
[!! 	
ReducerMethod!!	 
]!! 
public"" 
static"" 
ShiftIdLookupState"" (+
OnLoadShiftIdAsyncFailureAction"") H
(## 	
ShiftIdLookupState$$ 
state$$ $
,$$$ %)
LoadShiftIdAsyncFailureAction%% )
action%%* 0
)&& 	
{'' 	
return(( 
state(( 
with(( 
{)) 
Initialized** 
=** 
false** #
,**# $
Loading++ 
=++ 
false++ 
,++  
ErrorMessage,, 
=,, 
action,, %
.,,% &
ErrorMessage,,& 2
}-- 
;-- 
}.. 	
}// 
}00 ‡
/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodes/LoadStateCodesAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3

StateCodes3 =
{ 
public 

sealed 
record  
LoadStateCodesAction -
(- .
int. 1$
SuppressSonarqubeWarning2 J
=K L
$numM N
)N O
;O P
} ò#
Ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodes/LoadStateCodesEffects.cs
	namespace

 	
AWC


 
.

 
Client

 
.

 
Services

 
.

 
HumanResources

 ,
.

, -
Store

- 2
.

2 3

StateCodes

3 =
{ 
public 

sealed 
class !
LoadStateCodesEffects -
{ 
private 
readonly 
GrpcChannel $
_channel% -
;- .
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly 
NotificationService , 
_notificationService- A
;A B
public !
LoadStateCodesEffects $
( 	
GrpcChannel 
channel 
,  
IMapper 
mapper 
, 
NotificationService 
notificationService  3
) 	
{ 	
_channel 
= 
channel 
; 
_mapper 
= 
mapper 
;  
_notificationService  
=! "
notificationService# 6
;6 7
} 	
[ 	
EffectMethod	 
( 
typeof 
(  
LoadStateCodesAction 1
)1 2
)2 3
]3 4
public 
async 
Task 
LoadStateCodes (
(( )
IDispatcher) 4

dispatcher5 ?
)? @
{   	
try!! 
{"" 

dispatcher## 
.## 
Dispatch## #
(### $
new##$ '*
SetStateCodesLoadingFlagAction##( F
(##F G
)##G H
)##H I
;##I J
var%% 
client%% 
=%% 
new%%  
LookupsContract%%! 0
.%%0 1!
LookupsContractClient%%1 F
(%%F G
_channel%%G O
)%%O P
;%%P Q
var&& 
stream&& 
=&& 
client&& #
.&&# $
GetStateCodesUsa&&$ 4
(&&4 5
new&&5 8
Empty&&9 >
(&&> ?
)&&? @
)&&@ A
.&&A B
ResponseStream&&B P
;&&P Q
List(( 
<(( 
	StateCode(( 
>(( 

stateCodes((  *
=((+ ,
new((- 0
(((0 1
)((1 2
;((2 3
while** 
(** 
await** 
stream** #
.**# $
MoveNext**$ ,
(**, -
default**- 4
)**4 5
)**5 6
{++ "
grpc_StateProvinceCode,, *
code,,+ /
=,,0 1
stream,,2 8
.,,8 9
Current,,9 @
;,,@ A

stateCodes-- 
.-- 
Add-- "
(--" #
_mapper--# *
.--* +
Map--+ .
<--. /
	StateCode--/ 8
>--8 9
(--9 :
code--: >
)--> ?
)--? @
;--@ A
}.. 

dispatcher00 
.00 
Dispatch00 #
(00# $
new00$ ''
LoadStateCodesSuccessAction00( C
(00C D

stateCodes00D N
)00N O
)00O P
;00P Q
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33  
_notificationService44 $
!44$ %
.44% &
Notify44& ,
(44, -
new55 
NotificationMessage55 +
{66 
Severity77  
=77! " 
NotificationSeverity77# 7
.777 8
Error778 =
,77= >
Style88 
=88 
$str88  [
,88[ \
Detail99 
=99  
Helpers99! (
.99( )
GetExceptionMessage99) <
(99< =
ex99= ?
)99? @
,99@ A
Duration::  
=::! "
$num::# (
};; 
)<< 
;<< 

dispatcher>> 
.>> 
Dispatch>> #
(>># $
new>>$ ''
LoadStateCodesFailureAction>>( C
(>>C D
Helpers>>D K
.>>K L
GetExceptionMessage>>L _
(>>_ `
ex>>` b
)>>b c
)>>c d
)>>d e
;>>e f
}?? 
}@@ 	
}AA 
}BB ≈
Ü/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodes/LoadStateCodesFailureAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3

StateCodes3 =
{ 
public 

sealed 
record '
LoadStateCodesFailureAction 4
(4 5
string5 ;
ErrorMessage< H
)H I
;I J
} ≈
Å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodes/LoadStateCodesReducers.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3

StateCodes3 =
{ 
public 

static 
class "
LoadStateCodesReducers .
{ 
[ 	
ReducerMethod	 
( 
typeof 
( *
SetStateCodesLoadingFlagAction <
)< =
)= >
]> ?
public 
static !
StateCodesLookupState +%
OnLoadingStateCodesAction, E
(		 	!
StateCodesLookupState

 !
state

" '
) 	
{ 	
return 
state 
with 
{ 
Loading 
= 
true 
} 
; 
} 	
[ 	
ReducerMethod	 
] 
public 
static !
StateCodesLookupState +,
 OnLoadingStateCodesSuccessAction, L
( 	!
StateCodesLookupState !
state" '
,' ('
LoadStateCodesSuccessAction '
action( .
) 	
{ 	
return 
state 
with 
{ 
Initialized 
= 
true "
," #
Loading 
= 
false 
,  

StateCodes 
= 
action #
.# $

StateCodes$ .
} 
; 
}   	
["" 	
ReducerMethod""	 
]"" 
public## 
static## !
StateCodesLookupState## +,
 OnLoadingStateCodesFailureAction##, L
($$ 	!
StateCodesLookupState%% !
state%%" '
,%%' ('
LoadStateCodesFailureAction&& '
action&&( .
)'' 	
{(( 	
return)) 
state)) 
with)) 
{** 
Initialized++ 
=++ 
false++ #
,++# $
Loading,, 
=,, 
false,, 
,,,  
ErrorMessage-- 
=-- 
action-- %
.--% &
ErrorMessage--& 2
}.. 
;.. 
}// 	
}00 
}11 Ö
Ü/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodes/LoadStateCodesSuccessAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3

StateCodes3 =
{ 
public 

sealed 
record '
LoadStateCodesSuccessAction 4
(4 5
List5 9
<9 :
	StateCode: C
>C D
?D E

StateCodesF P
)P Q
;Q R
} ı
â/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodes/SetStateCodesLoadingFlagAction.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
.2 3

StateCodes3 =
{ 
public 

sealed 
record *
SetStateCodesLoadingFlagAction 7
(7 8
int8 ;$
SuppressSonarqubeWarning< T
=U V
$numW X
)X Y
;Y Z
} ≠

w/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodesLookupFeature.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
class #
StateCodesLookupFeature /
:0 1
Feature2 9
<9 :!
StateCodesLookupState: O
>O P
{ 
public 
override 
string 
GetName &
(& '
)' (
=>) +
$str, C
;C D
	protected		 
override		 !
StateCodesLookupState		 0
GetInitialState		1 @
(		@ A
)		A B
=>		C E
new

 
(

 
)

 
{ 
Initialized 
= 
false #
,# $
Loading 
= 
false 
,  
ErrorMessage 
= 
string %
.% &
Empty& +
,+ ,

StateCodes 
= 
new  
(  !
)! "
," #
} 
; 
} 
} í	
u/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Services/HumanResources/Store/StateCodesLookupState.cs
	namespace 	
AWC
 
. 
Client 
. 
Services 
. 
HumanResources ,
., -
Store- 2
{ 
public 

sealed 
record !
StateCodesLookupState .
{ 
public 
bool 
Initialized 
{  !
get" %
;% &
init' +
;+ ,
}- .
public 
bool 
Loading 
{ 
get !
;! "
init# '
;' (
}) *
public		 
string		 
?		 
ErrorMessage		 #
{		$ %
get		& )
;		) *
init		+ /
;		/ 0
}		1 2
public

 
List

 
<

 
	StateCode

 
>

 
?

 

StateCodes

  *
{

+ ,
get

- 0
;

0 1
init

2 6
;

6 7
}

8 9
} 
} û	
\/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Shared/CompanyLayout.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Shared 
{ 
public 

partial 
class 
CompanyLayout &
{ 
string 
currentVersion 
= 
string  &
.& '
Empty' ,
;, -
	protected		 
override		 
void		 
OnInitialized		  -
(		- .
)		. /
{

 	
Assembly 
currentAssembly $
=% &
Assembly' /
./ 0 
GetExecutingAssembly0 D
(D E
)E F
;F G
currentVersion 
= 
$" 
$str 5
{5 6
currentAssembly6 E
.E F
GetNameF M
(M N
)N O
.O P
VersionP W
}W X
"X Y
;Y Z
base 
. 
OnInitialized 
( 
)  
;  !
} 	
} 
} ò	
Y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Shared/MainLayout.razor.cs
	namespace 	
AWC
 
. 
Client 
. 
Shared 
{ 
public 

partial 
class 

MainLayout #
{ 
string 
currentVersion 
= 
string  &
.& '
Empty' ,
;, -
	protected		 
override		 
void		 
OnInitialized		  -
(		- .
)		. /
{

 	
Assembly 
currentAssembly $
=% &
Assembly' /
./ 0 
GetExecutingAssembly0 D
(D E
)E F
;F G
currentVersion 
= 
$" 
$str 5
{5 6
currentAssembly6 E
.E F
GetNameF M
(M N
)N O
.O P
VersionP W
}W X
"X Y
;Y Z
base 
. 
OnInitialized 
( 
)  
;  !
} 	
} 
} ›
_/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/DebuggingExtensions.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

static 
class 
DebuggingExtensions +
{ 
private 
static 
readonly !
JsonSerializerOptions  5
_options6 >
=? @
newA D
(D E
)E F
{G H
WriteIndentedI V
=W X
trueY ]
}^ _
;_ `
public		 
static		 
string		 
ToJson		 #
(		# $
this		$ (
object		) /
obj		0 3
)		3 4
=>		5 7
JsonSerializer		8 F
.		F G
	Serialize		G P
(		P Q
obj		Q T
,		T U
_options		V ^
)		^ _
;		_ `
}

 
} §$
Q/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Error.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

class 
Error 
: 

IEquatable #
<# $
Error$ )
>) *
{ 
public 
static 
readonly 
Error $
None% )
=* +
new, /
(/ 0
string0 6
.6 7
Empty7 <
,< =
string> D
.D E
EmptyE J
)J K
;K L
public 
static 
readonly 
Error $
	NullValue% .
=/ 0
new1 4
(4 5
$str5 F
,F G
$strH m
)m n
;n o
public		 
static		 
readonly		 
Error		 $
ConditionNotMet		% 4
=		5 6
new		7 :
(		: ;
$str		; R
,		R S
$str		T z
)		z {
;		{ |
public 
Error 
( 
string 
code  
,  !
string" (
message) 0
)0 1
{ 	
Code 
= 
code 
; 
Message 
= 
message 
; 
} 	
public 
string 
Code 
{ 
get  
;  !
}" #
public 
string 
Message 
{ 
get  #
;# $
}% &
public 
static 
implicit 
operator '
string( .
(. /
Error/ 4
error5 :
): ;
=>< >
error? D
.D E
CodeE I
;I J
public 
static 
bool 
operator #
==$ &
(& '
Error' ,
?, -
a. /
,/ 0
Error1 6
?6 7
b8 9
)9 :
{ 	
if 
( 
a 
is 
null 
&& 
b 
is !
null" &
)& '
{ 
return 
true 
; 
} 
if 
( 
a 
is 
null 
|| 
b 
is !
null" &
)& '
{ 
return   
false   
;   
}!! 
return## 
a## 
.## 
Equals## 
(## 
b## 
)## 
;## 
}$$ 	
public&& 
static&& 
bool&& 
operator&& #
!=&&$ &
(&&& '
Error&&' ,
?&&, -
a&&. /
,&&/ 0
Error&&1 6
?&&6 7
b&&8 9
)&&9 :
=>&&; =
!&&> ?
(&&? @
a&&@ A
==&&B D
b&&E F
)&&F G
;&&G H
public(( 
virtual(( 
bool(( 
Equals(( "
(((" #
Error((# (
?((( )
other((* /
)((/ 0
{)) 	
if** 
(** 
other** 
is** 
null** 
)** 
{++ 
return,, 
false,, 
;,, 
}-- 
return// 
Code// 
==// 
other//  
.//  !
Code//! %
&&//& (
Message//) 0
==//1 3
other//4 9
.//9 :
Message//: A
;//A B
}00 	
public22 
override22 
bool22 
Equals22 #
(22# $
object22$ *
?22* +
obj22, /
)22/ 0
=>221 3
obj224 7
is228 :
Error22; @
error22A F
&&22G I
Equals22J P
(22P Q
error22Q V
)22V W
;22W X
public44 
override44 
int44 
GetHashCode44 '
(44' (
)44( )
=>44* ,
HashCode44- 5
.445 6
Combine446 =
(44= >
Code44> B
,44B C
Message44D K
)44K L
;44L M
public66 
override66 
string66 
ToString66 '
(66' (
)66( )
=>66* ,
Code66- 1
;661 2
}77 
}88 õ
S/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Helpers.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

static 
class 
Helpers 
{ 
public 
static 
string 
GetExceptionMessage 0
(0 1
	Exception1 :
ex; =
)= >
=> 
ex 
. 
InnerException  
==! #
null$ (
?) *
ex+ -
.- .
Message. 5
:6 7
ex8 :
.: ;
InnerException; I
.I J
MessageJ Q
;Q R
} 
} ˙D
h/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Mapping/CompanyMappingConfig.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
. 
Mapping &
{ 
public 

sealed 
class  
CompanyMappingConfig ,
:- .
	IRegister/ 8
{ 
public		 
void		 
Register		 
(		 
TypeAdapterConfig		 .
config		/ 5
)		5 6
{

 	
config 
. 
	NewConfig 
< "
grpc_CompanyForDisplay 3
,3 4
CompanyDetails5 C
>C D
(D E
)E F
. 
Map 
( 
dest 
=> 
dest !
.! "
	LegalName" +
,+ ,
src- 0
=>1 3
string4 :
.: ;
IsNullOrEmpty; H
(H I
srcI L
.L M
	LegalNameM V
)V W
?X Y
nullZ ^
:_ `
srca d
.d e
	LegalNamee n
)n o
. 
Map 
( 
dest 
=> 
dest !
.! "
CompanyWebSite" 0
,0 1
src2 5
=>6 8
string9 ?
.? @
IsNullOrEmpty@ M
(M N
srcN Q
.Q R
CompanyWebSiteR `
)` a
?b c
nulld h
:i j
srck n
.n o
CompanyWebSiteo }
)} ~
. 
Map 
( 
dest 
=> 
dest !
.! "
MailAddressLine2" 2
,2 3
src4 7
=>8 :
string; A
.A B
IsNullOrEmptyB O
(O P
srcP S
.S T
MailAddressLine2T d
)d e
?f g
nullh l
:m n
srco r
.r s
MailAddressLine2	s É
)
É Ñ
. 
Map 
( 
dest 
=> 
dest !
.! " 
DeliveryAddressLine2" 6
,6 7
src8 ;
=>< >
string? E
.E F
IsNullOrEmptyF S
(S T
srcT W
.W X 
DeliveryAddressLine2X l
)l m
?n o
nullp t
:u v
srcw z
.z {!
DeliveryAddressLine2	{ è
)
è ê
;
ê ë
config 
. 
	NewConfig 
< !
CompanyGenericCommand 2
,2 3&
grpc_CompanyGenericCommand4 N
>N O
(O P
)P Q
. 
Map 
( 
dest 
=> 
dest !
.! "
	CompanyId" +
,+ ,
src- 0
=>1 3
src4 7
.7 8
	CompanyID8 A
)A B
. 
Map 
( 
dest 
=> 
dest !
.! "
	LegalName" +
,+ ,
src- 0
=>1 3
string4 :
.: ;
IsNullOrEmpty; H
(H I
srcI L
.L M
	LegalNameM V
)V W
?X Y
stringZ `
.` a
Emptya f
:g h
srci l
.l m
	LegalNamem v
)v w
. 
Map 
( 
dest 
=> 
dest !
.! "
CompanyWebSite" 0
,0 1
src2 5
=>6 8
string9 ?
.? @
IsNullOrEmpty@ M
(M N
srcN Q
.Q R
CompanyWebSiteR `
)` a
?b c
stringd j
.j k
Emptyk p
:q r
srcs v
.v w
CompanyWebSite	w Ö
)
Ö Ü
. 
Map 
( 
dest 
=> 
dest !
.! "
MailAddressLine2" 2
,2 3
src4 7
=>8 :
string; A
.A B
IsNullOrEmptyB O
(O P
srcP S
.S T
MailAddressLine2T d
)d e
?f g
stringh n
.n o
Emptyo t
:u v
srcw z
.z {
MailAddressLine2	{ ã
)
ã å
. 
Map 
( 
dest 
=> 
dest !
.! " 
DeliveryAddressLine2" 6
,6 7
src8 ;
=>< >
string? E
.E F
IsNullOrEmptyF S
(S T
srcT W
.W X 
DeliveryAddressLine2X l
)l m
?n o
stringp v
.v w
Emptyw |
:} ~
src	 Ç
.
Ç É"
DeliveryAddressLine2
É ó
)
ó ò
;
ò ô
config 
. 
	NewConfig 
< &
grpc_CompanyGenericCommand 7
,7 8!
CompanyGenericCommand9 N
>N O
(O P
)P Q
.   
Map   
(   
dest   
=>   
dest   !
.  ! "
	LegalName  " +
,  + ,
src  - 0
=>  1 3
string  4 :
.  : ;
IsNullOrEmpty  ; H
(  H I
src  I L
.  L M
	LegalName  M V
)  V W
?  X Y
string  Z `
.  ` a
Empty  a f
:  g h
src  i l
.  l m
	LegalName  m v
)  v w
.!! 
Map!! 
(!! 
dest!! 
=>!! 
dest!! !
.!!! "
CompanyWebSite!!" 0
,!!0 1
src!!2 5
=>!!6 8
string!!9 ?
.!!? @
IsNullOrEmpty!!@ M
(!!M N
src!!N Q
.!!Q R
CompanyWebSite!!R `
)!!` a
?!!b c
string!!d j
.!!j k
Empty!!k p
:!!q r
src!!s v
.!!v w
CompanyWebSite	!!w Ö
)
!!Ö Ü
."" 
Map"" 
("" 
dest"" 
=>"" 
dest"" !
.""! "
MailAddressLine2""" 2
,""2 3
src""4 7
=>""8 :
string""; A
.""A B
IsNullOrEmpty""B O
(""O P
src""P S
.""S T
MailAddressLine2""T d
)""d e
?""f g
string""h n
.""n o
Empty""o t
:""u v
src""w z
.""z {
MailAddressLine2	""{ ã
)
""ã å
.## 
Map## 
(## 
dest## 
=>## 
dest## !
.##! " 
DeliveryAddressLine2##" 6
,##6 7
src##8 ;
=>##< >
string##? E
.##E F
IsNullOrEmpty##F S
(##S T
src##T W
.##W X 
DeliveryAddressLine2##X l
)##l m
?##n o
string##p v
.##v w
Empty##w |
:##} ~
src	## Ç
.
##Ç É"
DeliveryAddressLine2
##É ó
)
##ó ò
;
##ò ô
config&& 
.&& 
	NewConfig&& 
<&& 
grpc_Department&& ,
,&&, -
DepartmentDetails&&. ?
>&&? @
(&&@ A
)&&A B
.'' 
Map'' 
('' 
dest'' 
=>'' 
dest'' !
.''! "
DepartmentID''" .
,''. /
src''0 3
=>''4 6
src''7 :
.'': ;
DepartmentId''; G
)''G H
.(( 
Map(( 
((( 
dest(( 
=>(( 
dest(( !
.((! "
Name((" &
,((& '
src((( +
=>((, .
src((/ 2
.((2 3
Name((3 7
)((7 8
.)) 
Map)) 
()) 
dest)) 
=>)) 
dest)) !
.))! "
	GroupName))" +
,))+ ,
src))- 0
=>))1 3
src))4 7
.))7 8
	GroupName))8 A
)))A B
.** 
Map** 
(** 
dest** 
=>** 
dest** !
.**! "
ModifiedDate**" .
,**. /
src**0 3
=>**4 6
src**7 :
.**: ;
ModifiedDate**; G
.**G H

ToDateTime**H R
(**R S
)**S T
.**T U
ToLocalTime**U `
(**` a
)**a b
)**b c
;**c d
},, 	
}-- 
}.. Õ≥
i/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Mapping/EmployeeMappingConfig.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
. 
Mapping &
{ 
public 

sealed 
class *
EmployeeAggregateMappingConfig 6
:7 8
	IRegister9 B
{		 
void

 
	IRegister

 
.

 
Register

 
(

  
TypeAdapterConfig

  1
config

2 8
)

8 9
{ 	
config 
. 
	NewConfig 
< #
grpc_EmployeeForDisplay 4
,4 5
EmployeeDetails6 E
>E F
(F G
)G H
. 
Map 
( 
dest 
=> 
dest !
.! "
Title" '
,' (
src) ,
=>- /
string0 6
.6 7
IsNullOrEmpty7 D
(D E
srcE H
.H I
TitleI N
)N O
?P Q
nullR V
:W X
srcY \
.\ ]
Title] b
)b c
. 
Map 
( 
dest 
=> 
dest !
.! "

MiddleName" ,
,, -
src. 1
=>2 4
string5 ;
.; <
IsNullOrEmpty< I
(I J
srcJ M
.M N

MiddleNameN X
)X Y
?Z [
null\ `
:a b
srcc f
.f g

MiddleNameg q
)q r
. 
Map 
( 
dest 
=> 
dest !
.! "
Suffix" (
,( )
src* -
=>. 0
string1 7
.7 8
IsNullOrEmpty8 E
(E F
srcF I
.I J
SuffixJ P
)P Q
?R S
nullT X
:Y Z
src[ ^
.^ _
Suffix_ e
)e f
. 
Map 
( 
dest 
=> 
dest !
.! "
AddressLine2" .
,. /
src0 3
=>4 6
string7 =
.= >
IsNullOrEmpty> K
(K L
srcL O
.O P
AddressLine2P \
)\ ]
?^ _
null` d
:e f
srcg j
.j k
AddressLine2k w
)w x
. 
Map 
( 
dest 
=> 
dest !
.! "
	BirthDate" +
,+ ,
src- 0
=>1 3
src4 7
.7 8
	BirthDate8 A
.A B

ToDateTimeB L
(L M
)M N
.N O
ToLocalTimeO Z
(Z [
)[ \
)\ ]
. 
Map 
( 
dest 
=> 
dest !
.! "
HireDate" *
,* +
src, /
=>0 2
src3 6
.6 7
HireDate7 ?
.? @

ToDateTime@ J
(J K
)K L
.L M
ToLocalTimeM X
(X Y
)Y Z
)Z [
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentHistories" 5
,5 6
src7 :
=>; =
src> A
.A B
DepartmentHistoriesB U
)U V
. 
Map 
( 
dest 
=> 
dest !
.! "
PayHistories" .
,. /
src0 3
=>4 6
src7 :
.: ;
PayHistories; G
)G H
;H I
config 
. 
	NewConfig 
< 
AWC  
.  !
Shared! '
.' (
Commands( 0
.0 1
HumanResources1 ?
.? @"
EmployeeGenericCommand@ V
,V W'
grpc_EmployeeGenericCommandX s
>s t
(t u
)u v
. 
Map 
( 
dest 
=> 
dest !
.! "
Title" '
,' (
src) ,
=>- /
string0 6
.6 7
IsNullOrEmpty7 D
(D E
srcE H
.H I
TitleI N
)N O
?P Q
stringR X
.X Y
EmptyY ^
:_ `
srca d
.d e
Titlee j
)j k
. 
Map 
( 
dest 
=> 
dest !
.! "

MiddleName" ,
,, -
src. 1
=>2 4
string5 ;
.; <
IsNullOrEmpty< I
(I J
srcJ M
.M N

MiddleNameN X
)X Y
?Z [
string\ b
.b c
Emptyc h
:i j
srck n
.n o

MiddleNameo y
)y z
. 
Map 
( 
dest 
=> 
dest !
.! "
Suffix" (
,( )
src* -
=>. 0
string1 7
.7 8
IsNullOrEmpty8 E
(E F
srcF I
.I J
SuffixJ P
)P Q
?R S
stringT Z
.Z [
Empty[ `
:a b
srcc f
.f g
Suffixg m
)m n
. 
Map 
( 
dest 
=> 
dest !
.! "
PhoneNumberTypeId" 3
,3 4
src5 8
=>9 ;
src< ?
.? @
PhoneNumberTypeID@ Q
)Q R
. 
Map 
( 
dest 
=> 
dest !
.! "
AddressLine2" .
,. /
src0 3
=>4 6
string7 =
.= >
IsNullOrEmpty> K
(K L
srcL O
.O P
AddressLine2P \
)\ ]
?^ _
string` f
.f g
Emptyg l
:m n
srco r
.r s
AddressLine2s 
)	 Ä
.   
Map   
(   
dest   
=>   
dest   !
.  ! "
	BirthDate  " +
,  + ,
src  - 0
=>  1 3
GoogleDateTime  4 B
.  B C
FromDateTimeOffset  C U
(  U V
src  V Y
.  Y Z
	BirthDate  Z c
)  c d
)  d e
.!! 
Map!! 
(!! 
dest!! 
=>!! 
dest!! !
.!!! "
HireDate!!" *
,!!* +
src!!, /
=>!!0 2
GoogleDateTime!!3 A
.!!A B
FromDateTimeOffset!!B T
(!!T U
src!!U X
.!!X Y
HireDate!!Y a
)!!a b
)!!b c
;!!c d
config## 
.## 
	NewConfig## 
<## '
grpc_EmployeeGenericCommand## 8
,##8 9
AWC##: =
.##= >
Shared##> D
.##D E
Commands##E M
.##M N
HumanResources##N \
.##\ ]"
EmployeeGenericCommand##] s
>##s t
(##t u
)##u v
.$$ 
Map$$ 
($$ 
dest$$ 
=>$$ 
dest$$ !
.$$! "
Title$$" '
,$$' (
src$$) ,
=>$$- /
string$$0 6
.$$6 7
IsNullOrEmpty$$7 D
($$D E
src$$E H
.$$H I
Title$$I N
)$$N O
?$$P Q
null$$R V
:$$W X
src$$Y \
.$$\ ]
Title$$] b
)$$b c
.%% 
Map%% 
(%% 
dest%% 
=>%% 
dest%% !
.%%! "

MiddleName%%" ,
,%%, -
src%%. 1
=>%%2 4
string%%5 ;
.%%; <
IsNullOrEmpty%%< I
(%%I J
src%%J M
.%%M N

MiddleName%%N X
)%%X Y
?%%Z [
null%%\ `
:%%a b
src%%c f
.%%f g

MiddleName%%g q
)%%q r
.&& 
Map&& 
(&& 
dest&& 
=>&& 
dest&& !
.&&! "
Suffix&&" (
,&&( )
src&&* -
=>&&. 0
string&&1 7
.&&7 8
IsNullOrEmpty&&8 E
(&&E F
src&&F I
.&&I J
Suffix&&J P
)&&P Q
?&&R S
null&&T X
:&&Y Z
src&&[ ^
.&&^ _
Suffix&&_ e
)&&e f
.'' 
Map'' 
('' 
dest'' 
=>'' 
dest'' !
.''! "
AddressLine2''" .
,''. /
src''0 3
=>''4 6
string''7 =
.''= >
IsNullOrEmpty''> K
(''K L
src''L O
.''O P
AddressLine2''P \
)''\ ]
?''^ _
null''` d
:''e f
src''g j
.''j k
AddressLine2''k w
)''w x
.(( 
Map(( 
((( 
dest(( 
=>(( 
dest(( !
.((! "
PhoneNumberTypeID((" 3
,((3 4
src((5 8
=>((9 ;
src((< ?
.((? @
PhoneNumberTypeId((@ Q
)((Q R
.)) 
Map)) 
()) 
dest)) 
=>)) 
dest)) !
.))! "
	BirthDate))" +
,))+ ,
src))- 0
=>))1 3
src))4 7
.))7 8
	BirthDate))8 A
.))A B

ToDateTime))B L
())L M
)))M N
.))N O
ToLocalTime))O Z
())Z [
)))[ \
)))\ ]
.** 
Map** 
(** 
dest** 
=>** 
dest** !
.**! "
HireDate**" *
,*** +
src**, /
=>**0 2
src**3 6
.**6 7
HireDate**7 ?
.**? @

ToDateTime**@ J
(**J K
)**K L
.**L M
ToLocalTime**M X
(**X Y
)**Y Z
)**Z [
;**[ \
config,, 
.,, 
	NewConfig,, 
<,, !
grpc_EmployeeListItem,, 2
,,,2 3
EmployeeListItem,,4 D
>,,D E
(,,E F
),,F G
.-- 
Map-- 
(-- 
dest-- 
=>-- 
dest-- !
.--! "

MiddleName--" ,
,--, -
src--. 1
=>--2 4
string--5 ;
.--; <
IsNullOrEmpty--< I
(--I J
src--J M
.--M N

MiddleName--N X
)--X Y
?--Z [
null--\ `
:--a b
src--c f
.--f g

MiddleName--g q
)--q r
... 
Map.. 
(.. 
dest.. 
=>.. 
dest.. !
...! "
ManagerName.." -
,..- .
src../ 2
=>..3 5
string..6 <
...< =
IsNullOrEmpty..= J
(..J K
src..K N
...N O
ManagerName..O Z
)..Z [
?..\ ]
null..^ b
:..c d
src..e h
...h i
ManagerName..i t
)..t u
;..u v
config11 
.11 
	NewConfig11 
<11 )
grpc_DepartmentHistoryCommand11 :
,11: ;
AWC11< ?
.11? @
Shared11@ F
.11F G
Commands11G O
.11O P
HumanResources11P ^
.11^ _$
DepartmentHistoryCommand11_ w
>11w x
(11x y
)11y z
.22 
Map22 
(22 
dest22 
=>22 
dest22 !
.22! "
BusinessEntityID22" 2
,222 3
src224 7
=>228 :
src22; >
.22> ?
BusinessEntityId22? O
)22O P
.33 
Map33 
(33 
dest33 
=>33 
dest33 !
.33! "
DepartmentID33" .
,33. /
src330 3
=>334 6
src337 :
.33: ;
DepartmentId33; G
)33G H
.44 
Map44 
(44 
dest44 
=>44 
dest44 !
.44! "
ShiftID44" )
,44) *
src44+ .
=>44/ 1
src442 5
.445 6
ShiftId446 =
)44= >
.55 
Map55 
(55 
dest55 
=>55 
dest55 !
.55! "
	StartDate55" +
,55+ ,
src55- 0
=>551 3
src554 7
.557 8
	StartDate558 A
.55A B

ToDateTime55B L
(55L M
)55M N
.55N O
ToLocalTime55O Z
(55Z [
)55[ \
)55\ ]
.66 
Map66 
(66 
dest66 
=>66 
dest66 !
.66! "
EndDate66" )
,66) *
src66+ .
=>66/ 1
src662 5
.665 6
EndDate666 =
.66= >

ToDateTime66> H
(66H I
)66I J
.66J K
ToLocalTime66K V
(66V W
)66W X
,66X Y
srcCond66Z a
=>66b d
srcCond66e l
.66l m
EndDate66m t
.66t u
Seconds66u |
<=66} 
$num
66Ä Å
)
66Å Ç
.77 
Map77 
(77 
dest77 
=>77 
dest77 !
.77! "
EndDate77" )
,77) *
src77+ .
=>77/ 1
src772 5
.775 6
EndDate776 =
.77= >

ToDateTime77> H
(77H I
)77I J
.77J K
ToLocalTime77K V
(77V W
)77W X
)77X Y
;77Y Z
config99 
.99 
	NewConfig99 
<99 
AWC99  
.99  !
Shared99! '
.99' (
Commands99( 0
.990 1
HumanResources991 ?
.99? @$
DepartmentHistoryCommand99@ X
,99X Y)
grpc_DepartmentHistoryCommand99Z w
>99w x
(99x y
)99y z
.:: 
Map:: 
(:: 
dest:: 
=>:: 
dest:: !
.::! "
BusinessEntityId::" 2
,::2 3
src::4 7
=>::8 :
src::; >
.::> ?
BusinessEntityID::? O
)::O P
.;; 
Map;; 
(;; 
dest;; 
=>;; 
dest;; !
.;;! "
DepartmentId;;" .
,;;. /
src;;0 3
=>;;4 6
src;;7 :
.;;: ;
DepartmentID;;; G
);;G H
.<< 
Map<< 
(<< 
dest<< 
=><< 
dest<< !
.<<! "
ShiftId<<" )
,<<) *
src<<+ .
=><</ 1
src<<2 5
.<<5 6
ShiftID<<6 =
)<<= >
.== 
Map== 
(== 
dest== 
=>== 
dest== !
.==! "
	StartDate==" +
,==+ ,
src==- 0
=>==1 3
GoogleDateTime==4 B
.==B C
FromDateTimeOffset==C U
(==U V
src==V Y
.==Y Z
	StartDate==Z c
)==c d
)==d e
.>> 
Map>> 
(>> 
dest>> 
=>>> 
dest>> !
.>>! "
EndDate>>" )
,>>) *
src>>+ .
=>>>/ 1
src>>2 5
.>>5 6
EndDate>>6 =
!=>>> @
null>>A E
?>>F G
GoogleDateTime>>H V
.>>V W
FromDateTimeOffset>>W i
(>>i j
src>>j m
.>>m n
EndDate>>n u
.>>u v
Value>>v {
)>>{ |
:>>} ~
GoogleDateTime	>> ç
.
>>ç é 
FromDateTimeOffset
>>é †
(
>>† °
new
>>° §
DateTimeOffset
>>• ≥
(
>>≥ ¥
)
>>¥ µ
)
>>µ ∂
)
>>∂ ∑
;
>>∑ ∏
configAA 
.AA 
	NewConfigAA 
<AA "
grpc_PayHistoryCommandAA 3
,AA3 4
AWCAA5 8
.AA8 9
SharedAA9 ?
.AA? @
CommandsAA@ H
.AAH I
HumanResourcesAAI W
.AAW X
PayHistoryCommandAAX i
>AAi j
(AAj k
)AAk l
.BB 
MapBB 
(BB 
destBB 
=>BB 
destBB !
.BB! "
BusinessEntityIDBB" 2
,BB2 3
srcBB4 7
=>BB8 :
srcBB; >
.BB> ?
BusinessEntityIdBB? O
)BBO P
.CC 
MapCC 
(CC 
destCC 
=>CC 
destCC !
.CC! "
RateChangeDateCC" 0
,CC0 1
srcCC2 5
=>CC6 8
srcCC9 <
.CC< =
RateChangeDateCC= K
.CCK L

ToDateTimeCCL V
(CCV W
)CCW X
.CCX Y
ToLocalTimeCCY d
(CCd e
)CCe f
)CCf g
.DD 
MapDD 
(DD 
destDD 
=>DD 
destDD !
.DD! "
RateDD" &
,DD& '
srcDD( +
=>DD, .
(DD/ 0
decimalDD0 7
)DD7 8
srcDD8 ;
.DD; <
RateDD< @
)DD@ A
.EE 
MapEE 
(EE 
destEE 
=>EE 
destEE !
.EE! "
PayFrequencyEE" .
,EE. /
srcEE0 3
=>EE4 6
srcEE7 :
.EE: ;
PayFrequencyEE; G
)EEG H
;EEH I
configGG 
.GG 
	NewConfigGG 
<GG 
AWCGG  
.GG  !
SharedGG! '
.GG' (
CommandsGG( 0
.GG0 1
HumanResourcesGG1 ?
.GG? @
PayHistoryCommandGG@ Q
,GGQ R"
grpc_PayHistoryCommandGGS i
>GGi j
(GGj k
)GGk l
.HH 
MapHH 
(HH 
destHH 
=>HH 
destHH !
.HH! "
BusinessEntityIdHH" 2
,HH2 3
srcHH4 7
=>HH8 :
srcHH; >
.HH> ?
BusinessEntityIDHH? O
)HHO P
.II 
MapII 
(II 
destII 
=>II 
destII !
.II! "
RateChangeDateII" 0
,II0 1
srcII2 5
=>II6 8
GoogleDateTimeII9 G
.IIG H
FromDateTimeOffsetIIH Z
(IIZ [
srcII[ ^
.II^ _
RateChangeDateII_ m
)IIm n
)IIn o
.JJ 
MapJJ 
(JJ 
destJJ 
=>JJ 
destJJ !
.JJ! "
RateJJ" &
,JJ& '
srcJJ( +
=>JJ, .
(JJ/ 0
doubleJJ0 6
)JJ6 7
srcJJ7 :
.JJ: ;
RateJJ; ?
)JJ? @
.KK 
MapKK 
(KK 
destKK 
=>KK 
destKK !
.KK! "
PayFrequencyKK" .
,KK. /
srcKK0 3
=>KK4 6
srcKK7 :
.KK: ;
PayFrequencyKK; G
)KKG H
;KKH I
configNN 
.NN 
	NewConfigNN 
<NN "
grpc_DepartmentHistoryNN 3
,NN3 4
AWCNN5 8
.NN8 9
SharedNN9 ?
.NN? @
QueriesNN@ G
.NNG H
HumanResourcesNNH V
.NNV W
DepartmentHistoryNNW h
>NNh i
(NNi j
)NNj k
.OO 
MapOO 
(OO 
destOO 
=>OO 
destOO !
.OO! "
BusinessEntityIDOO" 2
,OO2 3
srcOO4 7
=>OO8 :
srcOO; >
.OO> ?
BusinessEntityIdOO? O
)OOO P
.PP 
MapPP 
(PP 
destPP 
=>PP 
destPP !
.PP! "

DepartmentPP" ,
,PP, -
srcPP. 1
=>PP2 4
srcPP5 8
.PP8 9

DepartmentPP9 C
)PPC D
.QQ 
MapQQ 
(QQ 
destQQ 
=>QQ 
destQQ !
.QQ! "
ShiftQQ" '
,QQ' (
srcQQ) ,
=>QQ- /
srcQQ0 3
.QQ3 4
ShiftQQ4 9
)QQ9 :
.RR 
MapRR 
(RR 
destRR 
=>RR 
destRR !
.RR! "
	StartDateRR" +
,RR+ ,
srcRR- 0
=>RR1 3
srcRR4 7
.RR7 8
	StartDateRR8 A
.RRA B

ToDateTimeRRB L
(RRL M
)RRM N
.RRN O
ToLocalTimeRRO Z
(RRZ [
)RR[ \
)RR\ ]
.SS 
MapSS 
(SS 
destSS 
=>SS 
destSS !
.SS! "
EndDateSS" )
,SS) *
srcSS+ .
=>SS/ 1
srcSS2 5
.SS5 6
EndDateSS6 =
.SS= >

ToDateTimeSS> H
(SSH I
)SSI J
.SSJ K
ToLocalTimeSSK V
(SSV W
)SSW X
)SSX Y
;SSY Z
configVV 
.VV 
	NewConfigVV 
<VV 
grpc_PayHistoryVV ,
,VV, -
AWCVV. 1
.VV1 2
SharedVV2 8
.VV8 9
QueriesVV9 @
.VV@ A
HumanResourcesVVA O
.VVO P

PayHistoryVVP Z
>VVZ [
(VV[ \
)VV\ ]
.WW 
MapWW 
(WW 
destWW 
=>WW 
destWW !
.WW! "
BusinessEntityIDWW" 2
,WW2 3
srcWW4 7
=>WW8 :
srcWW; >
.WW> ?
BusinessEntityIdWW? O
)WWO P
.XX 
MapXX 
(XX 
destXX 
=>XX 
destXX !
.XX! "
RateChangeDateXX" 0
,XX0 1
srcXX2 5
=>XX6 8
srcXX9 <
.XX< =
RateChangeDateXX= K
.XXK L

ToDateTimeXXL V
(XXV W
)XXW X
.XXX Y
ToLocalTimeXXY d
(XXd e
)XXe f
)XXf g
.YY 
MapYY 
(YY 
destYY 
=>YY 
destYY !
.YY! "
RateYY" &
,YY& '
srcYY( +
=>YY, .
(YY/ 0
decimalYY0 7
)YY7 8
srcYY8 ;
.YY; <
RateYY< @
)YY@ A
.ZZ 
MapZZ 
(ZZ 
destZZ 
=>ZZ 
destZZ !
.ZZ! "
PayFrequencyZZ" .
,ZZ. /
srcZZ0 3
=>ZZ4 6
srcZZ7 :
.ZZ: ;
PayFrequencyZZ; G
)ZZG H
;ZZH I
}[[ 	
}\\ 
}]] π#
h/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Mapping/LookupsMappingConfig.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
. 
Mapping &
{ 
public 

sealed 
class  
LookupsMappingConfig ,
:- .
	IRegister/ 8
{		 
public

 
void

 
Register

 
(

 
TypeAdapterConfig

 .
config

/ 5
)

5 6
{ 	
config 
. 
	NewConfig 
< "
grpc_StateProvinceCode 3
,3 4
	StateCode5 >
>> ?
(? @
)@ A
. 
Map 
( 
dest 
=> 
dest !
.! "
StateProvinceID" 1
,1 2
src3 6
=>7 9
src: =
.= >
Id> @
)@ A
. 
Map 
( 
dest 
=> 
dest !
.! "
StateProvinceCode" 3
,3 4
src5 8
=>9 ;
src< ?
.? @
	StateCode@ I
)I J
. 
Map 
( 
dest 
=> 
dest !
.! "
StateProvinceName" 3
,3 4
src5 8
=>9 ;
src< ?
.? @
StateProvinceName@ Q
)Q R
;R S
config 
. 
	NewConfig 
< 
grpc_ManagerId +
,+ ,
	ManagerId- 6
>6 7
(7 8
)8 9
. 
Map 
( 
dest 
=> 
dest !
.! "
BusinessEntityID" 2
,2 3
src4 7
=>8 :
src; >
.> ?
BusinessEntityId? O
)O P
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentID" .
,. /
src0 3
=>4 6
src7 :
.: ;
DepartmentId; G
)G H
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentName" 0
,0 1
src2 5
=>6 8
src9 <
.< =
DepartmentName= K
)K L
. 
Map 
( 
dest 
=> 
dest !
.! "
JobTitle" *
,* +
src, /
=>0 2
src3 6
.6 7
JobTitle7 ?
)? @
. 
Map 
( 
dest 
=> 
dest !
.! "
ManagerFullName" 1
,1 2
src3 6
=>7 9
src: =
.= >
ManagerFullName> M
)M N
;N O
config 
. 
	NewConfig 
< 
grpc_DepartmentId .
,. /
DepartmentId0 <
>< =
(= >
)> ?
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentID" .
,. /
src0 3
=>4 6
src7 :
.: ;
DepartmentId; G
)G H
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentName" 0
,0 1
src2 5
=>6 8
src9 <
.< =
Name= A
)A B
;B C
config 
. 
	NewConfig 
< 
grpc_ShiftId )
,) *
ShiftId+ 2
>2 3
(3 4
)4 5
.   
Map   
(   
dest   
=>   
dest   !
.  ! "
ShiftID  " )
,  ) *
src  + .
=>  / 1
src  2 5
.  5 6
ShiftId  6 =
)  = >
.!! 
Map!! 
(!! 
dest!! 
=>!! 
dest!! !
.!!! "
	ShiftName!!" +
,!!+ ,
src!!- 0
=>!!1 3
src!!4 7
.!!7 8
Name!!8 <
)!!< =
;!!= >
}"" 	
}## 
}$$ ∞
g/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Mapping/SharedMappingConfig.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
. 
Mapping &
{ 
public 

sealed 
class 
SharedMappingConfig +
:, -
	IRegister. 7
{ 
public		 
void		 
Register		 
(		 
TypeAdapterConfig		 .
config		/ 5
)		5 6
{

 	
config 
. 
	NewConfig 
<  
StringSearchCriteria 1
,1 2%
grpc_StringSearchCriteria3 L
>L M
(M N
)N O
. 
Map 
( 
dest 
=> 
dest !
.! "
SearchField" -
,- .
src/ 2
=>3 5
src6 9
.9 :
SearchField: E
)E F
. 
Map 
( 
dest 
=> 
dest !
.! "
SearchCriteria" 0
,0 1
src2 5
=>6 8
src9 <
.< =
SearchCriteria= K
)K L
. 
Map 
( 
dest 
=> 
dest !
.! "
OrderBy" )
,) *
src+ .
=>/ 1
src2 5
.5 6
OrderBy6 =
)= >
. 
Map 
( 
dest 
=> 
dest !
.! "
SearchField" -
,- .
src/ 2
=>3 5
src6 9
.9 :
SearchField: E
)E F
. 
Map 
( 
dest 
=> 
dest !
.! "

PageNumber" ,
,, -
src. 1
=>2 4
src5 8
.8 9

PageNumber9 C
)C D
. 
Map 
( 
dest 
=> 
dest !
.! "
PageSize" *
,* +
src, /
=>0 2
src3 6
.6 7
PageSize7 ?
)? @
. 
Map 
( 
dest 
=> 
dest !
.! "
Skip" &
,& '
src( +
=>, .
src/ 2
.2 3
Skip3 7
)7 8
. 
Map 
( 
dest 
=> 
dest !
.! "
Take" &
,& '
src( +
=>, .
src/ 2
.2 3
Take3 7
)7 8
;8 9
} 	
} 
} €	
T/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/MetaData.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

class 
MetaData 
{ 
public 
int 
CurrentPage 
{  
get! $
;$ %
init& *
;* +
}, -
public 
int 

TotalPages 
{ 
get  #
;# $
init% )
;) *
}+ ,
public 
int 
PageSize 
{ 
get !
;! "
init# '
;' (
}) *
public 
int 

TotalCount 
{ 
get  #
;# $
init% )
;) *
}+ ,
public		 
bool		 
HasPrevious		 
=>		  "
CurrentPage		# .
>		/ 0
$num		1 2
;		2 3
public

 
bool

 
HasNext

 
=>

 
CurrentPage

 *
<

+ ,

TotalPages

- 7
;

7 8
} 
} ≠
U/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/PagedList.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

class 
	PagedList 
< 
T 
> 
where #
T$ %
:& '
class( -
{ 
public 
List 
< 
T 
> 
? 
Items 
{ 
get  #
;# $
set% (
;( )
}* +
public 
MetaData 
? 
MetaData !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ˜(
R/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/Result.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

class 
Result 
{ 
	protected 
internal 
Result !
(! "
bool" &
	isSuccess' 0
,0 1
Error2 7
error8 =
)= >
{ 	
if 
( 
	isSuccess 
&& 
error "
!=# %
Error& +
.+ ,
None, 0
)0 1
{ 
throw		 
new		 %
InvalidOperationException		 3
(		3 4
)		4 5
;		5 6
}

 
if 
( 
! 
	isSuccess 
&& 
error #
==$ &
Error' ,
., -
None- 1
)1 2
{ 
throw 
new %
InvalidOperationException 3
(3 4
)4 5
;5 6
} 
	IsSuccess 
= 
	isSuccess !
;! "
Error 
= 
error 
; 
} 	
public 
bool 
	IsSuccess 
{ 
get  #
;# $
}% &
public 
bool 
	IsFailure 
=>  
!! "
	IsSuccess" +
;+ ,
public 
Error 
Error 
{ 
get  
;  !
}" #
public 
static 
Result 
Success $
($ %
)% &
=>' )
new* -
(- .
true. 2
,2 3
Error4 9
.9 :
None: >
)> ?
;? @
public 
static 
Result 
< 
TValue #
># $
Success% ,
<, -
TValue- 3
>3 4
(4 5
TValue5 ;
value< A
)A B
=>C E
newF I
(I J
valueJ O
,O P
trueQ U
,U V
ErrorW \
.\ ]
None] a
)a b
;b c
public 
static 
Result 
Failure $
($ %
Error% *
error+ 0
)0 1
=>2 4
new5 8
(8 9
false9 >
,> ?
error@ E
)E F
;F G
public!! 
static!! 
Result!! 
<!! 
TValue!! #
>!!# $
Failure!!% ,
<!!, -
TValue!!- 3
>!!3 4
(!!4 5
Error!!5 :
error!!; @
)!!@ A
=>!!B D
new!!E H
(!!H I
default!!I P
,!!P Q
false!!R W
,!!W X
error!!Y ^
)!!^ _
;!!_ `
public## 
static## 
Result## 
Create## #
(### $
bool##$ (
	condition##) 2
)##2 3
=>##4 6
	condition##7 @
?##A B
Success##C J
(##J K
)##K L
:##M N
Failure##O V
(##V W
Error##W \
.##\ ]
ConditionNotMet##] l
)##l m
;##m n
public%% 
static%% 
Result%% 
<%% 
TValue%% #
>%%# $
Create%%% +
<%%+ ,
TValue%%, 2
>%%2 3
(%%3 4
TValue%%4 :
?%%: ;
value%%< A
)%%A B
=>%%C E
value%%F K
is%%L N
not%%O R
null%%S W
?%%X Y
Success%%Z a
(%%a b
value%%b g
)%%g h
:%%i j
Failure%%k r
<%%r s
TValue%%s y
>%%y z
(%%z {
Error	%%{ Ä
.
%%Ä Å
	NullValue
%%Å ä
)
%%ä ã
;
%%ã å
public'' 
static'' 
async'' 
Task''  
<''  !
Result''! '
>''' (!
FirstFailureOrSuccess'') >
(''> ?
params''? E
Func''F J
<''J K
Task''K O
<''O P
Result''P V
>''V W
>''W X
[''X Y
]''Y Z
results''[ b
)''b c
{(( 	
foreach)) 
()) 
Func)) 
<)) 
Task)) 
<)) 
Result)) %
>))% &
>))& '

resultTask))( 2
in))3 5
results))6 =
)))= >
{** 
Result++ 
result++ 
=++ 
await++  %

resultTask++& 0
(++0 1
)++1 2
;++2 3
if-- 
(-- 
result-- 
.-- 
	IsFailure-- $
)--$ %
{.. 
return// 
result// !
;//! "
}00 
}11 
return33 
Success33 
(33 
)33 
;33 
}44 	
}55 
}66 À
S/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/ResultT.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

class 
Result 
< 
TValue 
> 
:  !
Result" (
{ 
private 
readonly 
TValue 
?  
_value! '
;' (
	protected 
internal 
Result !
(! "
TValue" (
?( )
value* /
,/ 0
bool1 5
	isSuccess6 ?
,? @
ErrorA F
errorG L
)L M
: 
base 
( 
	isSuccess 
, 
error #
)# $
=>% '
_value		 
=		 
value		 
;		 
public 
TValue 
Value 
=> 
	IsSuccess (
? 
_value 
! 
: 
throw 
new %
InvalidOperationException 1
(1 2
$str2 f
)f g
;g h
public 
static 
implicit 
operator '
Result( .
<. /
TValue/ 5
>5 6
(6 7
TValue7 =
?= >
value? D
)D E
=>F H
CreateI O
(O P
valueP U
)U V
;V W
} 
} £	
a/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Client/Utilities/ShowErrorNotification.cs
	namespace 	
AWC
 
. 
Client 
. 
	Utilities 
{ 
public 

static 
class !
ShowErrorNotification -
{ 
public 
static 
void 
	ShowError $
( 	
NotificationService		 
notificationService		  3
,		3 4
string

 
errorMessage

 
)

  
{ 	
notificationService 
!  
.  !
Notify! '
(' (
new 
NotificationMessage '
{ 
Severity 
=  
NotificationSeverity 3
.3 4
Error4 9
,9 :
Summary 
= 
$"  
$str  %
"% &
,& '
Detail 
= 
errorMessage )
,) *
Duration 
= 
$num $
} 
) 
; 
} 	
} 
} 