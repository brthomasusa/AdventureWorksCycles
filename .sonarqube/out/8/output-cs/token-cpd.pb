ﬁZ
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Contracts/CompanyContractService.cs
	namespace 	
AWC
 
. 
Server 
. 
	Contracts 
{ 
public 

sealed 
class "
CompanyContractService .
:/ 0
CompanyContract1 @
.@ A
CompanyContractBaseA T
{ 
private 
readonly 
ISender  
_sender! (
;( )
private 
readonly 
IMapper  
_mapper! (
;( )
public "
CompanyContractService %
(% &
ISender& -
sender. 4
,4 5
IMapper6 =
mapper> D
)D E
=> 
( 
_sender 
, 
_mapper  
)  !
=" #
($ %
sender% +
,+ ,
mapper- 3
)3 4
;4 5
public 
override 
async 
Task "
<" #"
grpc_CompanyForDisplay# 9
>9 : 
GetCompanyForDisplay; O
(O P
ItemRequestP [
request\ c
,c d
ServerCallContexte v
contextw ~
)~ 
{ 	
Result 
< 
CompanyDetails !
>! "
result# )
=* +
await, 1
_sender2 9
.9 :
Send: >
(> ?
new? B$
GetCompanyDetailsRequestC [
([ \
	CompanyID\ e
:e f
requestg n
.n o
Ido q
)q r
)r s
;s t
if 
( 
result 
. 
	IsFailure  
)  !
throw 
new 
RpcException &
(& '
new' *
(* +

StatusCode+ 5
.5 6
Internal6 >
,> ?
result@ F
.F G
ErrorG L
.L M
MessageM T
)T U
)U V
;V W
return 
_mapper 
. 
Map 
< "
grpc_CompanyForDisplay 5
>5 6
(6 7
result7 =
.= >
Value> C
)C D
;D E
}   	
public"" 
override"" 
async"" 
Task"" "
<""" #&
grpc_CompanyGenericCommand""# =
>""= >
GetCompanyForEdit""? P
(""P Q
ItemRequest""Q \
request""] d
,""d e
ServerCallContext""f w
context""x 
)	"" Ä
{## 	
Result$$ 
<$$ !
CompanyGenericCommand$$ (
>$$( )
result$$* 0
=$$1 2
await$$3 8
_sender$$9 @
.$$@ A
Send$$A E
($$E F
new$$F I$
GetCompanyCommandRequest$$J b
($$b c
	CompanyID$$c l
:$$l m
request$$n u
.$$u v
Id$$v x
)$$x y
)$$y z
;$$z {
if&& 
(&& 
result&& 
.&& 
	IsFailure&&  
)&&  !
throw'' 
new'' 
RpcException'' &
(''& '
new''' *
(''* +

StatusCode''+ 5
.''5 6
Internal''6 >
,''> ?
result''@ F
.''F G
Error''G L
.''L M
Message''M T
)''T U
)''U V
;''V W
return)) 
_mapper)) 
.)) 
Map)) 
<)) &
grpc_CompanyGenericCommand)) 9
>))9 :
()): ;
result)); A
.))A B
Value))B G
)))G H
;))H I
}** 	
public,, 
override,, 
async,, 
Task,, "
<,," #&
grpc_GetCompanyDepartments,,# =
>,,= >&
GetDepartmentsSearchByName,,? Y
(,,Y Z%
grpc_StringSearchCriteria,,Z s
request,,t {
,,,{ |
ServerCallContext	,,} é
context
,,è ñ
)
,,ñ ó
{-- 	 
StringSearchCriteria..  
criteria..! )
=..* +
new.., /
(// 
request00 
.00 
SearchField00 #
,00# $
request11 
.11 
SearchCriteria11 &
,11& '
request22 
.22 
OrderBy22 
,22  
request33 
.33 

PageNumber33 "
,33" #
request44 
.44 
PageSize44  
,44  !
request55 
.55 
Skip55 
,55 
request66 
.66 
Take66 
)77 
;77 0
$GetCompanyDepartmentsFilteredRequest99 0
requestParameter991 A
=99B C
new99D G
(99G H
criteria99H P
)99P Q
;99Q R
Result;; 
<;; 
	PagedList;; 
<;; 
DepartmentDetails;; .
>;;. /
>;;/ 0
result;;1 7
=;;8 9
await;;: ?
_sender;;@ G
.;;G H
Send;;H L
(;;L M
requestParameter;;M ]
);;] ^
;;;^ _
if== 
(== 
result== 
.== 
	IsFailure==  
)==  !
throw>> 
new>> 
RpcException>> &
(>>& '
new>>' *
(>>* +

StatusCode>>+ 5
.>>5 6
Internal>>6 >
,>>> ?
result>>@ F
.>>F G
Error>>G L
.>>L M
Message>>M T
)>>T U
)>>U V
;>>V W&
grpc_GetCompanyDepartments@@ &#
grpcDepartmentContainer@@' >
=@@? @
new@@A D
(@@D E
)@@E F
;@@F G
ListAA 
<AA 
grpc_DepartmentAA  
>AA  !#
grpcDepartmentListItemsAA" 9
=AA: ;
newAA< ?
(AA? @
)AA@ A
;AAA B
resultCC 
.CC 
ValueCC 
.CC 
ToListCC 
(CC  
)CC  !
.CC! "
ForEachCC" )
(CC) *
deptCC* .
=>CC/ 1#
grpcDepartmentListItemsDD '
.DD' (
AddDD( +
(DD+ ,
_mapperDD, 3
.DD3 4
MapDD4 7
<DD7 8
grpc_DepartmentDD8 G
>DDG H
(DDH I
deptDDI M
)DDM N
)DDN O
)EE 
;EE #
grpcDepartmentContainerGG #
.GG# $
GrpcDepartmentsGG$ 3
.GG3 4
AddRangeGG4 <
(GG< =#
grpcDepartmentListItemsGG= T
)GGT U
;GGU V#
grpcDepartmentContainerHH #
.HH# $
GrpcMetaDataHH$ 0
.HH0 1
AddHH1 4
(HH4 5
HelpersHH5 <
.HH< =
LoadMetaDataHH= I
(HHI J
resultHHJ P
.HHP Q
ValueHHQ V
.HHV W
MetaDataHHW _
)HH_ `
)HH` a
;HHa b
returnJJ #
grpcDepartmentContainerJJ *
;JJ* +
}KK 	
publicMM 
overrideMM 
asyncMM 
TaskMM "
<MM" #!
grpc_GetCompanyShiftsMM# 8
>MM8 9
	GetShiftsMM: C
(MMC D!
grpc_PagingParametersMMD Y
requestMMZ a
,MMa b
ServerCallContextMMc t
contextMMu |
)MM| }
{NN 	
PagingParametersOO 
pagingParametersOO -
=OO. /
newOO0 3
(OO3 4
requestOO4 ;
.OO; <

PageNumberOO< F
,OOF G
requestOOH O
.OOO P
PageSizeOOP X
)OOX Y
;OOY Z#
GetCompanyShiftsRequestPP #
shiftsRequestPP$ 1
=PP2 3
newPP4 7
(PP7 8
PagingParametersPP8 H
:PPH I
pagingParametersPPJ Z
)PPZ [
;PP[ \
ResultQQ 
<QQ 
	PagedListQQ 
<QQ 
ShiftDetailsQQ )
>QQ) *
>QQ* +
getShiftsResultQQ, ;
=QQ< =
awaitQQ> C
_senderQQD K
.QQK L
SendQQL P
(QQP Q
shiftsRequestQQQ ^
)QQ^ _
;QQ_ `
ifSS 
(SS 
getShiftsResultSS 
.SS  
	IsFailureSS  )
)SS) *
throwTT 
newTT 
RpcExceptionTT &
(TT& '
newTT' *
(TT* +

StatusCodeTT+ 5
.TT5 6
InternalTT6 >
,TT> ?
getShiftsResultTT@ O
.TTO P
ErrorTTP U
.TTU V
MessageTTV ]
)TT] ^
)TT^ _
;TT_ `!
grpc_GetCompanyShiftsVV !
grpcResponseVV" .
=VV/ 0
newVV1 4
(VV4 5
)VV5 6
;VV6 7
ListWW 
<WW 

grpc_ShiftWW 
>WW 
grpcShiftListWW *
=WW+ ,
newWW- 0
(WW0 1
)WW1 2
;WW2 3
getShiftsResultYY 
.YY 
ValueYY !
.YY! "
ForEachYY" )
(YY) *
shiftYY* /
=>YY0 2
grpcShiftListYY3 @
.YY@ A
AddYYA D
(YYD E
_mapperYYE L
.YYL M
MapYYM P
<YYP Q

grpc_ShiftYYQ [
>YY[ \
(YY\ ]
shiftYY] b
)YYb c
)YYc d
)YYd e
;YYe f
grpcResponse[[ 
.[[ 

GrpcShifts[[ #
.[[# $
AddRange[[$ ,
([[, -
grpcShiftList[[- :
)[[: ;
;[[; <
grpcResponse\\ 
.\\ 
GrpcMetaData\\ %
.\\% &
Add\\& )
(\\) *
Helpers\\* 1
.\\1 2
LoadMetaData\\2 >
(\\> ?
getShiftsResult\\? N
.\\N O
Value\\O T
.\\T U
MetaData\\U ]
)\\] ^
)\\^ _
;\\_ `
return^^ 
grpcResponse^^ 
;^^  
}__ 	
publicaa 
overrideaa 
asyncaa 
Taskaa "
<aa" #
GenericResponseaa# 2
>aa2 3
Updateaa4 :
(aa: ;&
grpc_CompanyGenericCommandaa; U
requestaaV ]
,aa] ^
ServerCallContextaa_ p
contextaaq x
)aax y
{bb 	 
UpdateCompanyCommandcc  
cmdcc! $
=cc% &
_mappercc' .
.cc. /
Mapcc/ 2
<cc2 3 
UpdateCompanyCommandcc3 G
>ccG H
(ccH I
requestccI P
)ccP Q
;ccQ R
Resultee 
<ee 
intee 
>ee 
resultee 
=ee  
awaitee! &
_senderee' .
.ee. /
Sendee/ 3
(ee3 4
cmdee4 7
)ee7 8
;ee8 9
ifgg 
(gg 
resultgg 
.gg 
	IsFailuregg  
)gg  !
throwhh 
newhh 
RpcExceptionhh &
(hh& '
newhh' *
(hh* +

StatusCodehh+ 5
.hh5 6
Internalhh6 >
,hh> ?
resulthh@ F
.hhF G
ErrorhhG L
.hhL M
MessagehhM T
)hhT U
)hhU V
;hhV W
returnjj 
newjj 
GenericResponsejj &
{jj' (
Successjj) 0
=jj1 2
truejj3 7
}jj8 9
;jj9 :
}kk 	
}ll 
}mm …ä
c/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Contracts/EmployeeContractService.cs
	namespace 	
AWC
 
. 
Server 
. 
	Contracts 
{ 
public 

sealed 
class #
EmployeeContractService /
:0 1
EmployeeContract2 B
.B C 
EmployeeContractBaseC W
{ 
private 
readonly 
ISender  
_sender! (
;( )
private 
readonly 
IMapper  
_mapper! (
;( )
public #
EmployeeContractService &
(& '
ISender' .
sender/ 5
,5 6
IMapper7 >
mapper? E
)E F
=> 
( 
_sender 
, 
_mapper  
)  !
=" #
($ %
sender% +
,+ ,
mapper- 3
)3 4
;4 5
public 
async 
override 
Task "
<" #
CreateResponse# 1
>1 2
Create3 9
(9 :'
grpc_EmployeeGenericCommand: U
requestV ]
,] ^
ServerCallContext_ p
contextq x
)x y
{ 	
List 
< 
AWC 
. 
Shared 
. 
Commands $
.$ %
HumanResources% 3
.3 4$
DepartmentHistoryCommand4 L
>L M
departmentHistoryN _
=` a
newb e
(e f
)f g
;g h
request 
. 
DepartmentHistories '
.' (
ToList( .
(. /
)/ 0
.0 1
ForEach1 8
(8 9
grpcDept9 A
=>B D
departmentHistory !
.! "
Add" %
(% &
_mapper& -
.- .
Map. 1
<1 2
AWC2 5
.5 6
Shared6 <
.< =
Commands= E
.E F
HumanResourcesF T
.T U$
DepartmentHistoryCommandU m
>m n
(n o
grpcDepto w
)w x
)x y
) 
; 
List   
<   
AWC   
.   
Shared   
.   
Commands   $
.  $ %
HumanResources  % 3
.  3 4
PayHistoryCommand  4 E
>  E F

payHistory  G Q
=  R S
new  T W
(  W X
)  X Y
;  Y Z
request!! 
.!! 
PayHistories!!  
.!!  !
ToList!!! '
(!!' (
)!!( )
.!!) *
ForEach!!* 1
(!!1 2
grpcPay!!2 9
=>!!: <

payHistory"" 
."" 
Add"" 
("" 
_mapper"" &
.""& '
Map""' *
<""* +
AWC""+ .
."". /
Shared""/ 5
.""5 6
Commands""6 >
.""> ?
HumanResources""? M
.""M N
PayHistoryCommand""N _
>""_ `
(""` a
grpcPay""a h
)""h i
)""i j
)## 
;## !
CreateEmployeeCommand%% !!
createEmployeeCommand%%" 7
=%%8 9
_mapper%%: A
.%%A B
Map%%B E
<%%E F!
CreateEmployeeCommand%%F [
>%%[ \
(%%\ ]
request%%] d
)%%d e
;%%e f!
createEmployeeCommand&& !
=&&" #!
createEmployeeCommand&&$ 9
with&&: >
{'' 
DepartmentHistories(( #
=(($ %
departmentHistory((& 7
,((7 8
PayHistories)) 
=)) 

payHistory)) )
}** 
;** 
Result,, 
<,, 
int,, 
>,, 
result,, 
=,,  
await,,! &
_sender,,' .
.,,. /
Send,,/ 3
(,,3 4!
createEmployeeCommand,,4 I
),,I J
;,,J K
if.. 
(.. 
result.. 
... 
	IsFailure..  
)..  !
throw// 
new// 
RpcException// &
(//& '
new//' *
(//* +

StatusCode//+ 5
.//5 6
Internal//6 >
,//> ?
result//@ F
.//F G
Error//G L
.//L M
Message//M T
)//T U
)//U V
;//V W
return11 
new11 
CreateResponse11 %
{11& '
Id11( *
=11+ ,
result11- 3
.113 4
Value114 9
}11: ;
;11; <
}22 	
public44 
async44 
override44 
Task44 "
<44" #
GenericResponse44# 2
>442 3
Delete444 :
(44: ;
ItemRequest44; F
request44G N
,44N O
ServerCallContext44P a
context44b i
)44i j
{55 	!
DeleteEmployeeCommand66 !!
deleteEmployeeCommand66" 7
=668 9
new66: =
(66= >
request66> E
.66E F
Id66F H
)66H I
;66I J
Result77 
<77 
int77 
>77 
result77 
=77  
await77! &
_sender77' .
.77. /
Send77/ 3
(773 4!
deleteEmployeeCommand774 I
)77I J
;77J K
if99 
(99 
result99 
.99 
	IsFailure99  
)99  !
throw:: 
new:: 
RpcException:: &
(::& '
new::' *
(::* +

StatusCode::+ 5
.::5 6
Internal::6 >
,::> ?
result::@ F
.::F G
Error::G L
.::L M
Message::M T
)::T U
)::U V
;::V W
return<< 
new<< 
GenericResponse<< &
{<<' (
Success<<) 0
=<<1 2
true<<3 7
}<<8 9
;<<9 :
}== 	
public?? 
async?? 
override?? 
Task?? "
<??" #
GenericResponse??# 2
>??2 3
Update??4 :
(??: ;'
grpc_EmployeeGenericCommand??; V
request??W ^
,??^ _
ServerCallContext??` q
context??r y
)??y z
{@@ 	!
UpdateEmployeeCommandAA !!
updateEmployeeCommandAA" 7
=AA8 9
_mapperAA: A
.AAA B
MapAAB E
<AAE F!
UpdateEmployeeCommandAAF [
>AA[ \
(AA\ ]
requestAA] d
)AAd e
;AAe f
ResultCC 
<CC 
intCC 
>CC 
resultCC 
=CC  
awaitCC! &
_senderCC' .
.CC. /
SendCC/ 3
(CC3 4!
updateEmployeeCommandCC4 I
)CCI J
;CCJ K
ifEE 
(EE 
resultEE 
.EE 
	IsFailureEE  
)EE  !
throwFF 
newFF 
RpcExceptionFF &
(FF& '
newFF' *
(FF* +

StatusCodeFF+ 5
.FF5 6
InternalFF6 >
,FF> ?
resultFF@ F
.FFF G
ErrorFFG L
.FFL M
MessageFFM T
)FFT U
)FFU V
;FFV W
returnHH 
newHH 
GenericResponseHH &
{HH' (
SuccessHH) 0
=HH1 2
trueHH3 7
}HH8 9
;HH9 :
}II 	
publicKK 
asyncKK 
overrideKK 
TaskKK "
<KK" ##
grpc_EmployeeForDisplayKK# :
>KK: ;!
GetEmployeeForDisplayKK< Q
(KKQ R
ItemRequestKKR ]
requestKK^ e
,KKe f
ServerCallContextKKg x
context	KKy Ä
)
KKÄ Å
{LL 	
ResultMM 
<MM 
EmployeeDetailsMM "
>MM" #
resultMM$ *
=MM+ ,
awaitNN 
_senderNN 
.NN 
SendNN "
(NN" #
newNN# &%
GetEmployeeDetailsRequestNN' @
(NN@ A

EmployeeIDNNA K
:NNK L
requestNNM T
.NNT U
IdNNU W
)NNW X
)NNX Y
;NNY Z
ifPP 
(PP 
resultPP 
.PP 
	IsFailurePP  
)PP  !
throwQQ 
newQQ 
RpcExceptionQQ &
(QQ& '
newQQ' *
(QQ* +

StatusCodeQQ+ 5
.QQ5 6
InternalQQ6 >
,QQ> ?
resultQQ@ F
.QQF G
ErrorQQG L
.QQL M
MessageQQM T
)QQT U
)QQU V
;QQV W#
grpc_EmployeeForDisplaySS #
grpcResponseSS$ 0
=SS1 2
_mapperSS3 :
.SS: ;
MapSS; >
<SS> ?#
grpc_EmployeeForDisplaySS? V
>SSV W
(SSW X
resultSSX ^
.SS^ _
ValueSS_ d
)SSd e
;SSe f
ListUU 
<UU "
grpc_DepartmentHistoryUU '
>UU' (
grpcDeptHistUU) 5
=UU6 7
newUU8 ;
(UU; <
)UU< =
;UU= >
ListVV 
<VV 
grpc_PayHistoryVV  
>VV  !
grpcPayHistVV" -
=VV. /
newVV0 3
(VV3 4
)VV4 5
;VV5 6
resultXX 
.XX 
ValueXX 
.XX 
DepartmentHistoriesXX ,
!XX, -
.XX- .
ToListXX. 4
(XX4 5
)XX5 6
.XX6 7
ForEachXX7 >
(XX> ?
dXX? @
=>XXA C
grpcDeptHistYY 
.YY 
AddYY  
(YY  !
_mapperYY! (
.YY( )
MapYY) ,
<YY, -"
grpc_DepartmentHistoryYY- C
>YYC D
(YYD E
dYYE F
)YYF G
)YYG H
)ZZ 
;ZZ 
result\\ 
.\\ 
Value\\ 
.\\ 
PayHistories\\ %
!\\% &
.\\& '
ToList\\' -
(\\- .
)\\. /
.\\/ 0
ForEach\\0 7
(\\7 8
p\\8 9
=>\\: <
grpcPayHist]] 
.]] 
Add]] 
(]]  
_mapper]]  '
.]]' (
Map]]( +
<]]+ ,
grpc_PayHistory]], ;
>]]; <
(]]< =
p]]= >
)]]> ?
)]]? @
)^^ 
;^^ 
grpcResponse`` 
.`` 
DepartmentHistories`` ,
.``, -
AddRange``- 5
(``5 6
grpcDeptHist``6 B
)``B C
;``C D
grpcResponseaa 
.aa 
PayHistoriesaa %
.aa% &
AddRangeaa& .
(aa. /
grpcPayHistaa/ :
)aa: ;
;aa; <
returncc 
grpcResponsecc 
;cc  
}dd 	
publicff 
asyncff 
overrideff 
Taskff "
<ff" #'
grpc_EmployeeGenericCommandff# >
>ff> ?
GetEmployeeForEditff@ R
(ffR S
ItemRequestffS ^
requestff_ f
,fff g
ServerCallContextffh y
context	ffz Å
)
ffÅ Ç
{gg 	
Resulthh 
<hh "
EmployeeGenericCommandhh )
>hh) *
resulthh+ 1
=hh2 3
awaitii 
_senderii 
.ii 
Sendii "
(ii" #
newii# &%
GetEmployeeCommandRequestii' @
(ii@ A

EmployeeIDiiA K
:iiK L
requestiiM T
.iiT U
IdiiU W
)iiW X
)iiX Y
;iiY Z
ifkk 
(kk 
resultkk 
.kk 
	IsFailurekk  
)kk  !
throwll 
newll 
RpcExceptionll &
(ll& '
newll' *
(ll* +

StatusCodell+ 5
.ll5 6
Internalll6 >
,ll> ?
resultll@ F
.llF G
ErrorllG L
.llL M
MessagellM T
)llT U
)llU V
;llV W'
grpc_EmployeeGenericCommandnn '
grpcResponsenn( 4
=nn5 6
_mappernn7 >
.nn> ?
Mapnn? B
<nnB C'
grpc_EmployeeGenericCommandnnC ^
>nn^ _
(nn_ `
resultnn` f
.nnf g
Valuenng l
)nnl m
;nnm n
Listpp 
<pp )
grpc_DepartmentHistoryCommandpp .
>pp. /
grpcDeptHistpp0 <
=pp= >
newpp? B
(ppB C
)ppC D
;ppD E
Listqq 
<qq "
grpc_PayHistoryCommandqq '
>qq' (
grpcPayHistqq) 4
=qq5 6
newqq7 :
(qq: ;
)qq; <
;qq< =
resultss 
.ss 
Valuess 
.ss 
DepartmentHistoriesss ,
!ss, -
.ss- .
ToListss. 4
(ss4 5
)ss5 6
.ss6 7
ForEachss7 >
(ss> ?
dss? @
=>ssA C
grpcDeptHisttt 
.tt 
Addtt  
(tt  !
_mappertt! (
.tt( )
Maptt) ,
<tt, -)
grpc_DepartmentHistoryCommandtt- J
>ttJ K
(ttK L
dttL M
)ttM N
)ttN O
)uu 
;uu 
resultww 
.ww 
Valueww 
.ww 
PayHistoriesww %
!ww% &
.ww& '
ToListww' -
(ww- .
)ww. /
.ww/ 0
ForEachww0 7
(ww7 8
pww8 9
=>ww: <
grpcPayHistxx 
.xx 
Addxx 
(xx  
_mapperxx  '
.xx' (
Mapxx( +
<xx+ ,"
grpc_PayHistoryCommandxx, B
>xxB C
(xxC D
pxxD E
)xxE F
)xxF G
)yy 
;yy 
grpcResponse{{ 
.{{ 
DepartmentHistories{{ ,
.{{, -
AddRange{{- 5
({{5 6
grpcDeptHist{{6 B
){{B C
;{{C D
grpcResponse|| 
.|| 
PayHistories|| %
.||% &
AddRange||& .
(||. /
grpcPayHist||/ :
)||: ;
;||; <
return~~ 
grpcResponse~~ 
;~~  
} 	
public
ÅÅ 
async
ÅÅ 
override
ÅÅ 
Task
ÅÅ "
<
ÅÅ" #$
grpc_EmployeeListItems
ÅÅ# 9
>
ÅÅ9 :&
GetEmployeesSearchByName
ÅÅ; S
(
ÅÅS T'
grpc_StringSearchCriteria
ÅÅT m
request
ÅÅn u
,
ÅÅu v 
ServerCallContextÅÅw à
contextÅÅâ ê
)ÅÅê ë
{
ÇÇ 	"
StringSearchCriteria
ÉÉ  
criteria
ÉÉ! )
=
ÉÉ* +
_mapper
ÉÉ, 3
.
ÉÉ3 4
Map
ÉÉ4 7
<
ÉÉ7 8"
StringSearchCriteria
ÉÉ8 L
>
ÉÉL M
(
ÉÉM N
request
ÉÉN U
)
ÉÉU V
;
ÉÉV W)
GetEmployeeListItemsRequest
ÑÑ '
query
ÑÑ( -
=
ÑÑ. /
new
ÑÑ0 3
(
ÑÑ3 4
SearchCriteria
ÑÑ4 B
:
ÑÑB C
criteria
ÑÑD L
)
ÑÑL M
;
ÑÑM N
Result
ÜÜ 
<
ÜÜ 
	PagedList
ÜÜ 
<
ÜÜ 
EmployeeListItem
ÜÜ -
>
ÜÜ- .
>
ÜÜ. /
result
ÜÜ0 6
=
ÜÜ7 8
await
ÜÜ9 >
_sender
ÜÜ? F
.
ÜÜF G
Send
ÜÜG K
(
ÜÜK L
query
ÜÜL Q
)
ÜÜQ R
;
ÜÜR S
if
àà 
(
àà 
result
àà 
.
àà 
	IsFailure
àà  
)
àà  !
throw
ââ 
new
ââ 
RpcException
ââ &
(
ââ& '
new
ââ' *
(
ââ* +

StatusCode
ââ+ 5
.
ââ5 6
Internal
ââ6 >
,
ââ> ?
result
ââ@ F
.
ââF G
Error
ââG L
.
ââL M
Message
ââM T
)
ââT U
)
ââU V
;
ââV W$
grpc_EmployeeListItems
ãã "#
grpcEmployeeContainer
ãã# 8
=
ãã9 :
new
ãã; >
(
ãã> ?
)
ãã? @
;
ãã@ A
List
åå 
<
åå #
grpc_EmployeeListItem
åå &
>
åå& '#
grpcEmployeeListItems
åå( =
=
åå> ?
new
åå@ C
(
ååC D
)
ååD E
;
ååE F
result
éé 
.
éé 
Value
éé 
.
éé 
ToList
éé 
(
éé  
)
éé  !
.
éé! "
ForEach
éé" )
(
éé) *
emplListItem
éé* 6
=>
éé7 9#
grpcEmployeeListItems
èè %
.
èè% &
Add
èè& )
(
èè) *
_mapper
èè* 1
.
èè1 2
Map
èè2 5
<
èè5 6#
grpc_EmployeeListItem
èè6 K
>
èèK L
(
èèL M
emplListItem
èèM Y
)
èèY Z
)
èèZ [
)
êê 
;
êê #
grpcEmployeeContainer
íí !
.
íí! "
GrpcEmployees
íí" /
.
íí/ 0
AddRange
íí0 8
(
íí8 9#
grpcEmployeeListItems
íí9 N
)
ííN O
;
ííO P#
grpcEmployeeContainer
ìì !
.
ìì! "
GrpcMetaData
ìì" .
.
ìì. /
Add
ìì/ 2
(
ìì2 3
Helpers
ìì3 :
.
ìì: ;
LoadMetaData
ìì; G
(
ììG H
result
ììH N
.
ììN O
Value
ììO T
.
ììT U
MetaData
ììU ]
)
ìì] ^
)
ìì^ _
;
ìì_ `
return
ïï #
grpcEmployeeContainer
ïï (
;
ïï( )
}
ññ 	
}
óó 
}òò ›M
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Contracts/LookupsContractService.cs
	namespace 	
AWC
 
. 
Server 
. 
	Contracts 
{ 
public 

sealed 
class "
LookupsContractService .
:/ 0
LookupsContract1 @
.@ A
LookupsContractBaseA T
{ 
private 
readonly 
ISender  
_sender! (
;( )
private 
readonly 
IMapper  
_mapper! (
;( )
public "
LookupsContractService %
(% &
ISender& -
sender. 4
,4 5
IMapper6 =
mapper> D
)D E
=> 
( 
_sender 
, 
_mapper  
)  !
=" #
($ %
sender% +
,+ ,
mapper- 3
)3 4
;4 5
public 
async 
override 
Task "
GetStateCodesAll# 3
( 	
Empty 
request 
, 
IServerStreamWriter 
<  "
grpc_StateProvinceCode  6
>6 7
responseStream8 F
,F G
ServerCallContext 
context %
) 	
{ 	
Result   
<   
List   
<   
	StateCode   !
>  ! "
>  " #

stateCodes  $ .
=  / 0
await  1 6
_sender  7 >
.  > ?
Send  ? C
(  C D
new  D G'
GetStateCodeIdForAllRequest  H c
(  c d
)  d e
)  e f
;  f g
if"" 
("" 

stateCodes"" 
."" 
	IsSuccess"" $
)""$ %
{## 

stateCodes$$ 
.$$ 
Value$$  
.$$  !
ToList$$! '
($$' (
)$$( )
.$$) *
ForEach$$* 1
($$1 2
	stateCode$$2 ;
=>$$< >
responseStream$$? M
.$$M N

WriteAsync$$N X
($$X Y
_mapper%% 
.%% 
Map%% 
<%%  "
grpc_StateProvinceCode%%  6
>%%6 7
(%%7 8
	stateCode%%8 A
)%%A B
)&& 
)&& 
;&& 
}'' 
else(( 
{)) 
throw** 
new** 
RpcException** &
(**& '
new**' *
(*** +

StatusCode**+ 5
.**5 6
Internal**6 >
,**> ?

stateCodes**@ J
.**J K
Error**K P
.**P Q
Message**Q X
)**X Y
)**Y Z
;**Z [
}++ 
},, 	
public.. 
async.. 
override.. 
Task.. "
GetStateCodesUsa..# 3
(// 	
Empty00 
request00 
,00 
IServerStreamWriter11 
<11  "
grpc_StateProvinceCode11  6
>116 7
responseStream118 F
,11F G
ServerCallContext22 
context22 %
)33 	
{44 	
Result55 
<55 
List55 
<55 
	StateCode55 !
>55! "
>55" #

stateCodes55$ .
=55/ 0
await551 6
_sender557 >
.55> ?
Send55? C
(55C D
new55D G'
GetStateCodeIdForUsaRequest55H c
(55c d
)55d e
)55e f
;55f g
if77 
(77 

stateCodes77 
.77 
	IsSuccess77 $
)77$ %
{88 

stateCodes99 
.99 
Value99  
.99  !
ToList99! '
(99' (
)99( )
.99) *
ForEach99* 1
(991 2
	stateCode992 ;
=>99< >
responseStream99? M
.99M N

WriteAsync99N X
(99X Y
_mapper:: 
.:: 
Map:: 
<::  "
grpc_StateProvinceCode::  6
>::6 7
(::7 8
	stateCode::8 A
)::A B
);; 
);; 
;;; 
}<< 
else== 
{>> 
throw?? 
new?? 
RpcException?? &
(??& '
new??' *
(??* +

StatusCode??+ 5
.??5 6
Internal??6 >
,??> ?

stateCodes??@ J
.??J K
Error??K P
.??P Q
Message??Q X
)??X Y
)??Y Z
;??Z [
}@@ 
}AA 	
publicCC 
asyncCC 
overrideCC 
TaskCC "
GetDepartmentIdsCC# 3
(CC3 4
EmptyCC4 9
requestCC: A
,CCA B
IServerStreamWriterCCC V
<CCV W
grpc_DepartmentIdCCW h
>CCh i
responseStreamCCj x
,CCx y
ServerCallContext	CCz ã
context
CCå ì
)
CCì î
{DD 	
ResultEE 
<EE 
ListEE 
<EE 
DepartmentIdEE $
>EE$ %
>EE% &
resultEE' -
=EE. /
awaitEE0 5
_senderEE6 =
.EE= >
SendEE> B
(EEB C
newEEC F#
GetDepartmentIdsRequestEEG ^
(EE^ _
)EE_ `
)EE` a
;EEa b
ifGG 
(GG 
resultGG 
.GG 
	IsSuccessGG  
)GG  !
{HH 
resultII 
.II 
ValueII 
.II 
ToListII #
(II# $
)II$ %
.II% &
ForEachII& -
(II- .
deptII. 2
=>II3 5
responseStreamII6 D
.IID E

WriteAsyncIIE O
(IIO P
_mapperJJ 
.JJ 
MapJJ 
<JJ  
grpc_DepartmentIdJJ  1
>JJ1 2
(JJ2 3
deptJJ3 7
)JJ7 8
)KK 
)KK 
;KK 
}LL 
elseMM 
{NN 
throwOO 
newOO 
RpcExceptionOO &
(OO& '
newOO' *
(OO* +

StatusCodeOO+ 5
.OO5 6
InternalOO6 >
,OO> ?
resultOO@ F
.OOF G
ErrorOOG L
.OOL M
MessageOOM T
)OOT U
)OOU V
;OOV W
}PP 
}QQ 	
publicSS 
asyncSS 
overrideSS 
TaskSS "
GetManagerIdsSS# 0
(SS0 1
EmptySS1 6
requestSS7 >
,SS> ?
IServerStreamWriterSS@ S
<SSS T
grpc_ManagerIdSST b
>SSb c
responseStreamSSd r
,SSr s
ServerCallContext	SSt Ö
context
SSÜ ç
)
SSç é
{TT 	
ResultUU 
<UU 
ListUU 
<UU 
	ManagerIdUU !
>UU! "
>UU" #
resultUU$ *
=UU+ ,
awaitUU- 2
_senderUU3 :
.UU: ;
SendUU; ?
(UU? @
newUU@ C 
GetManagerIdsRequestUUD X
(UUX Y
)UUY Z
)UUZ [
;UU[ \
ifWW 
(WW 
resultWW 
.WW 
	IsSuccessWW  
)WW  !
{XX 
resultYY 
.YY 
ValueYY 
.YY 
ToListYY #
(YY# $
)YY$ %
.YY% &
ForEachYY& -
(YY- .
mgrYY. 1
=>YY2 4
responseStreamYY5 C
.YYC D

WriteAsyncYYD N
(YYN O
_mapperZZ 
.ZZ 
MapZZ 
<ZZ  
grpc_ManagerIdZZ  .
>ZZ. /
(ZZ/ 0
mgrZZ0 3
)ZZ3 4
)[[ 
)[[ 
;[[ 
}\\ 
else]] 
{^^ 
throw__ 
new__ 
RpcException__ &
(__& '
new__' *
(__* +

StatusCode__+ 5
.__5 6
Internal__6 >
,__> ?
result__@ F
.__F G
Error__G L
.__L M
Message__M T
)__T U
)__U V
;__V W
}`` 
}aa 	
publiccc 
asynccc 
overridecc 
Taskcc "
GetShiftIdscc# .
(cc. /
Emptycc/ 4
requestcc5 <
,cc< =
IServerStreamWritercc> Q
<ccQ R
grpc_ShiftIdccR ^
>cc^ _
responseStreamcc` n
,ccn o
ServerCallContext	ccp Å
context
ccÇ â
)
ccâ ä
{dd 	
Resultee 
<ee 
Listee 
<ee 
ShiftIdee 
>ee  
>ee  !
resultee" (
=ee) *
awaitee+ 0
_senderee1 8
.ee8 9
Sendee9 =
(ee= >
newee> A
GetShiftIdsRequesteeB T
(eeT U
)eeU V
)eeV W
;eeW X
ifgg 
(gg 
resultgg 
.gg 
	IsSuccessgg  
)gg  !
{hh 
resultii 
.ii 
Valueii 
.ii 
ToListii #
(ii# $
)ii$ %
.ii% &
ForEachii& -
(ii- .
shiftii. 3
=>ii4 6
responseStreamii7 E
.iiE F

WriteAsynciiF P
(iiP Q
_mapperjj 
.jj 
Mapjj 
<jj  
grpc_ShiftIdjj  ,
>jj, -
(jj- .
shiftjj. 3
)jj3 4
)kk 
)kk 
;kk 
}ll 
elsemm 
{nn 
throwoo 
newoo 
RpcExceptionoo &
(oo& '
newoo' *
(oo* +

StatusCodeoo+ 5
.oo5 6
Internaloo6 >
,oo> ?
resultoo@ F
.ooF G
ErrorooG L
.ooL M
MessageooM T
)ooT U
)ooU V
;ooV W
}pp 
}qq 	
}rr 
}ss ◊
g/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Controllers/WeatherForecastController.cs
	namespace 	
src
 
. 
Server 
. 
Controllers  
;  !
[ 
ApiController 
] 
[ 
Route 
( 
$str 
) 
] 
public 
class %
WeatherForecastController &
:' (
ControllerBase) 7
{		 
private

 
static

 
readonly

 
string

 "
[

" #
]

# $
	Summaries

% .
=

/ 0
new

1 4
[

4 5
]

5 6
{ 
$str 
, 
$str 
, 
$str '
,' (
$str) /
,/ 0
$str1 7
,7 8
$str9 ?
,? @
$strA H
,H I
$strJ O
,O P
$strQ ]
,] ^
$str_ j
} 
; 
[ 
HttpGet 
] 
public 

IEnumerable 
< 
WeatherForecast &
>& '
Get( +
(+ ,
), -
{ 
return 

Enumerable 
. 
Range 
(  
$num  !
,! "
$num# $
)$ %
.% &
Select& ,
(, -
index- 2
=>3 5
new6 9
WeatherForecast: I
{ 	
Date 
= 
DateOnly 
. 
FromDateTime (
(( )
DateTime) 1
.1 2
Now2 5
.5 6
AddDays6 =
(= >
index> C
)C D
)D E
,E F
TemperatureC 
= 
Random !
.! "
Shared" (
.( )
Next) -
(- .
-. /
$num/ 1
,1 2
$num3 5
)5 6
,6 7
Summary 
= 
	Summaries 
[  
Random  &
.& '
Shared' -
.- .
Next. 2
(2 3
	Summaries3 <
.< =
Length= C
)C D
]D E
} 	
)	 

. 	
ToArray	 
( 
) 
; 
} 
} º
g/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Extensions/PipelineBehaviorExtentions.cs
	namespace 	
AWC
 
. 
Server 
. 

Extensions 
{ 
public		 

static		 
class		 &
PipelineBehaviorExtentions		 2
{

 
public 
static 
IServiceCollection ('
AddPipelineBehaviorServices) D
(D E
thisE I
IServiceCollectionJ \
services] e
)e f
{ 	
return 
services 
. 
	AddScoped 
( 
typeof !
(! "
CommandValidator" 2
<2 3!
CreateEmployeeCommand3 H
>H I
)I J
,J K
typeofL R
(R S/
#CreateEmployeeBusinessRuleValidatorS v
)v w
)w x
. 
	AddScoped 
( 
typeof !
(! "
CommandValidator" 2
<2 3!
DeleteEmployeeCommand3 H
>H I
)I J
,J K
typeofL R
(R S/
#DeleteEmployeeBusinessRuleValidatorS v
)v w
)w x
. 
	AddScoped 
( 
typeof !
(! "
CommandValidator" 2
<2 3!
UpdateEmployeeCommand3 H
>H I
)I J
,J K
typeofL R
(R S/
#UpdateEmployeeBusinessRuleValidatorS v
)v w
)w x
. 
	AddScoped 
( 
typeof !
(! "
CommandValidator" 2
<2 3 
UpdateCompanyCommand3 G
>G H
)H I
,I J
typeofK Q
(Q R.
"UpdateCompanyBusinessRuleValidatorR t
)t u
)u v
;v w
} 	
} 
} ≈0
^/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Extensions/ServiceExtensions.cs
	namespace 	
AWC
 
. 
Server 
. 

Extensions 
{ 
public 

static 
class 
ServiceExtensions )
{ 
public 
static 
void 
ConfigureCors (
(( )
this) -
IServiceCollection. @
servicesA I
)I J
=>K M
services 
. 
AddCors 
( 
options $
=>% '
{ 
options 
. 
	AddPolicy !
(! "
$str" .
,. /
builder0 7
=>8 :
builder 
. 
AllowAnyOrigin &
(& '
)' (
. 
AllowAnyMethod 
(  
)  !
. 
AllowAnyHeader 
(  
)  !
. 
WithExposedHeaders #
(# $
$str$ 1
,1 2
$str3 A
,A B
$strC R
,R S
$strT j
,j k
$str	l Ñ
)
Ñ Ö
)
Ö Ü
;
Ü á
} 
) 
; 
public 
static 
void $
ConfigureEfCoreDbContext 3
(3 4
this4 8
IServiceCollection9 K
servicesL T
)T U
{ 	
string 
? 
_connectionString %
=& '
Environment( 3
.3 4"
GetEnvironmentVariable4 J
(J K
$strK n
)n o
;o p
services 
. 
AddDbContext !
<! "

AwcContext" ,
>, -
(- .
options. 5
=>6 8
options   
.   
UseSqlServer   $
(  $ %
_connectionString!! %
,!!% &
msSqlOptions""  
=>""! #
msSqlOptions""$ 0
.""0 1
MigrationsAssembly""1 C
(""C D
typeof""D J
(""J K

AwcContext""K U
)""U V
.""V W
Assembly""W _
.""_ `
FullName""` h
)""h i
)## 
.$$ &
EnableSensitiveDataLogging$$ +
($$+ ,
)$$, -
.%%  
EnableDetailedErrors%% %
(%%% &
)%%& '
)&& 
;&& 
}'' 	
public)) 
static)) 
void)) 
ConfigureDapper)) *
())* +
this))+ /
IServiceCollection))0 B
services))C K
)))K L
{** 	
string++ 
?++ 
_connectionString++ %
=++& '
Environment++( 3
.++3 4"
GetEnvironmentVariable++4 J
(++J K
$str++K n
)++n o
;++o p
_,, 
=,, 
services,, 
.,, 
AddSingleton,, %
<,,% &
DapperContext,,& 3
>,,3 4
(,,4 5
_,,5 6
=>,,7 9
new,,: =
DapperContext,,> K
(,,K L
_connectionString,,L ]
),,] ^
),,^ _
;,,_ `
}-- 	
public// 
static// 
IServiceCollection// (%
AddInfrastructureServices//) B
(//B C
this//C G
IServiceCollection//H Z
services//[ c
)//c d
{00 	
return11 
services11 
.22 
	AddScoped22 
<22 
IUnitOfWork22 &
,22& '

UnitOfWork22( 2
>222 3
(223 4
)224 5
;225 6
}33 	
public55 
static55 
IServiceCollection55 (!
AddRepositoryServices55) >
(55> ?
this55? C
IServiceCollection55D V
services55W _
)55_ `
{66 	
return77 
services77 
.88 
	AddScoped88 
<88 #
IWriteRepositoryManager88 2
,882 3"
WriteRepositoryManager884 J
>88J K
(88K L
)88L M
.99 
	AddScoped99 
<99 "
IReadRepositoryManager99 1
,991 2!
ReadRepositoryManager993 H
>99H I
(99I J
)99J K
.:: 
	AddScoped:: 
<:: (
IValidationRepositoryManager:: 7
,::7 8'
ValidationRepositoryManager::9 T
>::T U
(::U V
)::V W
.;; 
	AddScoped;; 
<;; %
ILookupsRepositoryManager;; 4
,;;4 5$
LookupsRepositoryManager;;6 N
>;;N O
(;;O P
);;P Q
;;;Q R
}<< 	
public>> 
static>> 
IServiceCollection>> (
AddMappings>>) 4
(>>4 5
this>>5 9
IServiceCollection>>: L
services>>M U
)>>U V
{?? 	
var@@ 
config@@ 
=@@ 
TypeAdapterConfig@@ *
.@@* +
GlobalSettings@@+ 9
;@@9 :
configAA 
.AA 
ScanAA 
(AA 
ServerAssemblyBB 
.BB 
InstanceBB '
,BB' ("
InfrastructureAssemblyCC &
.CC& '
InstanceCC' /
,CC/ 0
ApplicationAssemblyDD #
.DD# $
InstanceDD$ ,
)EE 
;EE 
configFF 
.FF 
DefaultFF 
.FF  
NameMatchingStrategyFF /
(FF/ 0 
NameMatchingStrategyFF0 D
.FFD E

IgnoreCaseFFE O
)FFO P
;FFP Q
servicesHH 
.HH 
AddSingletonHH !
(HH! "
configHH" (
)HH( )
;HH) *
servicesII 
.II 
	AddScopedII 
<II 
IMapperII &
,II& '
ServiceMapperII( 5
>II5 6
(II6 7
)II7 8
;II8 9
returnKK 
servicesKK 
;KK 
}LL 	
}MM 
}NN ä?
g/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Interceptors/ServerTracingInterceptor.cs
	namespace 	
AWC
 
. 
Server 
. 
Interceptors !
{ 
public		 

sealed		 
class		 $
ServerTracingInterceptor		 0
:		1 2
Interceptor		3 >
{

 
private 
readonly 
ILogger  
<  !$
ServerTracingInterceptor! 9
>9 :
_logger; B
;B C
public $
ServerTracingInterceptor '
(' (
ILogger( /
</ 0$
ServerTracingInterceptor0 H
>H I
loggerJ P
)P Q
=> 
_logger 
= 
logger 
;  
public 
override 
async 
Task "
<" #
	TResponse# ,
>, -
UnaryServerHandler. @
<@ A
TRequestA I
,I J
	TResponseK T
>T U
(U V
TRequestV ^
request_ f
,f g
ServerCallContexth y
context	z Å
,
Å Ç
UnaryServerMethod
É î
<
î ï
TRequest
ï ù
,
ù û
	TResponse
ü ®
>
® ©
continuation
™ ∂
)
∂ ∑
{ 	
LogCall 
( 
context 
) 
; 
try 
{ 
return 
await 
continuation )
() *
request* 1
,1 2
context3 :
): ;
;; <
} 
catch 
( 
	Exception 
ex 
)  
{ 
LogException 
( 
ex 
)  
;  !
throw 
new -
!ServerTracingInterceptorException ;
(; <
Helpers< C
.C D
GetExceptionMessageD W
(W X
exX Z
)Z [
)[ \
;\ ]
} 
} 	
public 
override 
async 
Task "
<" #
	TResponse# ,
>, -(
ClientStreamingServerHandler. J
<J K
TRequestK S
,S T
	TResponseU ^
>^ _
(_ `
IAsyncStreamReader` r
<r s
TRequests {
>{ |
requestStream	} ä
,
ä ã
ServerCallContext
å ù
context
û •
,
• ¶)
ClientStreamingServerMethod
ß ¬
<
¬ √
TRequest
√ À
,
À Ã
	TResponse
Õ ÷
>
÷ ◊
continuation
ÿ ‰
)
‰ Â
{   	
LogCall!! 
(!! 
context!! 
)!! 
;!! 
try## 
{$$ 
return%% 
await%% 
continuation%% )
(%%) *
requestStream%%* 7
,%%7 8
context%%9 @
)%%@ A
;%%A B
}&& 
catch'' 
('' 
	Exception'' 
ex'' 
)''  
{(( 
LogException)) 
()) 
ex)) 
)))  
;))  !
throw** 
new** -
!ServerTracingInterceptorException** ;
(**; <
Helpers**< C
.**C D
GetExceptionMessage**D W
(**W X
ex**X Z
)**Z [
)**[ \
;**\ ]
}++ 
},, 	
public.. 
override.. 
async.. 
Task.. "(
ServerStreamingServerHandler..# ?
<..? @
TRequest..@ H
,..H I
	TResponse..J S
>..S T
(..T U
TRequest..U ]
request..^ e
,..e f
IServerStreamWriter..g z
<..z {
	TResponse	..{ Ñ
>
..Ñ Ö
responseStream
..Ü î
,
..î ï
ServerCallContext
..ñ ß
context
..® Ø
,
..Ø ∞)
ServerStreamingServerMethod
..± Ã
<
..Ã Õ
TRequest
..Õ ’
,
..’ ÷
	TResponse
..◊ ‡
>
..‡ ·
continuation
..‚ Ó
)
..Ó Ô
{// 	
LogCall00 
(00 
context00 
)00 
;00 
try22 
{33 
await44 
continuation44 "
(44" #
request44# *
,44* +
responseStream44, :
,44: ;
context44< C
)44C D
;44D E
}55 
catch66 
(66 
	Exception66 
ex66 
)66  
{77 
LogException88 
(88 
ex88 
)88  
;88  !
throw99 
new99 -
!ServerTracingInterceptorException99 ;
(99; <
Helpers99< C
.99C D
GetExceptionMessage99D W
(99W X
ex99X Z
)99Z [
)99[ \
;99\ ]
}:: 
};; 	
public== 
override== 
async== 
Task== "(
DuplexStreamingServerHandler==# ?
<==? @
TRequest==@ H
,==H I
	TResponse==J S
>==S T
(==T U
IAsyncStreamReader==U g
<==g h
TRequest==h p
>==p q
requestStream==r 
,	== Ä!
IServerStreamWriter
==Å î
<
==î ï
	TResponse
==ï û
>
==û ü
responseStream
==† Æ
,
==Æ Ø
ServerCallContext
==∞ ¡
context
==¬ …
,
==…  )
DuplexStreamingServerMethod
==À Ê
<
==Ê Á
TRequest
==Á Ô
,
==Ô 
	TResponse
==Ò ˙
>
==˙ ˚
continuation
==¸ à
)
==à â
{>> 	
LogCall?? 
(?? 
context?? 
)?? 
;?? 
tryAA 
{BB 
awaitCC 
continuationCC "
(CC" #
requestStreamCC# 0
,CC0 1
responseStreamCC2 @
,CC@ A
contextCCB I
)CCI J
;CCJ K
}DD 
catchEE 
(EE 
	ExceptionEE 
exEE 
)EE  
{FF 
LogExceptionGG 
(GG 
exGG 
)GG  
;GG  !
throwHH 
newHH -
!ServerTracingInterceptorExceptionHH ;
(HH; <
HelpersHH< C
.HHC D
GetExceptionMessageHHD W
(HHW X
exHHX Z
)HHZ [
)HH[ \
;HH\ ]
}II 
}JJ 	
privateLL 
voidLL 
LogCallLL 
(LL 
ServerCallContextLL .
contextLL/ 6
)LL6 7
{MM 	
_loggerNN 
.NN 
LogDebugNN 
(NN 
$"NN 
$strNN 2
{NN2 3
contextNN3 :
.NN: ;
GetHttpContextNN; I
(NNI J
)NNJ K
.NNK L
RequestNNL S
.NNS T
PathNNT X
}NNX Y
"NNY Z
)NNZ [
;NN[ \
}OO 	
privateQQ 
voidQQ 
LogExceptionQQ !
(QQ! "
	ExceptionQQ" +
exQQ, .
)QQ. /
{RR 	
_loggerSS 
.SS 
LogErrorSS 
(SS 
exSS 
,SS  
HelpersSS! (
.SS( )
GetExceptionMessageSS) <
(SS< =
exSS= ?
)SS? @
)SS@ A
;SSA B
}TT 	
}UU 
publicWW 

sealedWW 
classWW -
!ServerTracingInterceptorExceptionWW 9
:WW: ;
	ExceptionWW< E
{XX 
publicYY -
!ServerTracingInterceptorExceptionYY 0
(YY0 1
stringYY1 7
messageYY8 ?
)YY? @
:YYA B
baseYYC G
(YYG H
messageYYH O
)YYO P
{YYQ R
}YYS T
}ZZ 
}[[ ê≈
w/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Mapping/HumanResources/EmployeeAggregateMappingConfig.cs
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
Server

 
.

 
Mapping

 
.

 
HumanResources

 +
{ 
public 

sealed 
class *
EmployeeAggregateMappingConfig 6
:7 8
	IRegister9 B
{ 
public 
void 
Register 
( 
TypeAdapterConfig .
config/ 5
)5 6
{ 	
config 
. 
	NewConfig 
< 
EmployeeDetails ,
,, -#
grpc_EmployeeForDisplay. E
>E F
(F G
)G H
. 
Map 
( 
dest 
=> 
dest !
.! "
Title" '
,' (
src) ,
=>- /
string0 6
.6 7
IsNullOrEmpty7 D
(D E
srcE H
.H I
TitleI N
)N O
?P Q
stringR X
.X Y
EmptyY ^
:_ `
srca d
.d e
Titlee j
)j k
. 
Map 
( 
dest 
=> 
dest !
.! "

MiddleName" ,
,, -
src. 1
=>2 4
string5 ;
.; <
IsNullOrEmpty< I
(I J
srcJ M
.M N

MiddleNameN X
)X Y
?Z [
string\ b
.b c
Emptyc h
:i j
srck n
.n o

MiddleNameo y
)y z
. 
Map 
( 
dest 
=> 
dest !
.! "
Suffix" (
,( )
src* -
=>. 0
string1 7
.7 8
IsNullOrEmpty8 E
(E F
srcF I
.I J
SuffixJ P
)P Q
?R S
stringT Z
.Z [
Empty[ `
:a b
srcc f
.f g
Suffixg m
)m n
. 
Map 
( 
dest 
=> 
dest !
.! "
AddressLine2" .
,. /
src0 3
=>4 6
string7 =
.= >
IsNullOrEmpty> K
(K L
srcL O
.O P
AddressLine2P \
)\ ]
?^ _
string` f
.f g
Emptyg l
:m n
srco r
.r s
AddressLine2s 
)	 Ä
. 
Map 
( 
dest 
=> 
dest !
.! "
	BirthDate" +
,+ ,
src- 0
=>1 3
GoogleDateTime4 B
.B C
FromDateTimeOffsetC U
(U V
srcV Y
.Y Z
	BirthDateZ c
)c d
)d e
. 
Map 
( 
dest 
=> 
dest !
.! "
HireDate" *
,* +
src, /
=>0 2
GoogleDateTime3 A
.A B
FromDateTimeOffsetB T
(T U
srcU X
.X Y
HireDateY a
)a b
)b c
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentHistories" 5
,5 6
src7 :
=>; =
src> A
.A B
DepartmentHistoriesB U
!U V
.V W
AdaptW \
<\ ]
List] a
<a b"
grpc_DepartmentHistoryb x
>x y
>y z
(z {
){ |
)| }
;} ~
config 
. 
	NewConfig 
< "
EmployeeGenericCommand 3
,3 4'
grpc_EmployeeGenericCommand5 P
>P Q
(Q R
)R S
.   
Map   
(   
dest   
=>   
dest   !
.  ! "
Title  " '
,  ' (
src  ) ,
=>  - /
string  0 6
.  6 7
IsNullOrEmpty  7 D
(  D E
src  E H
.  H I
Title  I N
)  N O
?  P Q
string  R X
.  X Y
Empty  Y ^
:  _ `
src  a d
.  d e
Title  e j
)  j k
.!! 
Map!! 
(!! 
dest!! 
=>!! 
dest!! !
.!!! "

MiddleName!!" ,
,!!, -
src!!. 1
=>!!2 4
string!!5 ;
.!!; <
IsNullOrEmpty!!< I
(!!I J
src!!J M
.!!M N

MiddleName!!N X
)!!X Y
?!!Z [
string!!\ b
.!!b c
Empty!!c h
:!!i j
src!!k n
.!!n o

MiddleName!!o y
)!!y z
."" 
Map"" 
("" 
dest"" 
=>"" 
dest"" !
.""! "
Suffix""" (
,""( )
src""* -
=>"". 0
string""1 7
.""7 8
IsNullOrEmpty""8 E
(""E F
src""F I
.""I J
Suffix""J P
)""P Q
?""R S
string""T Z
.""Z [
Empty""[ `
:""a b
src""c f
.""f g
Suffix""g m
)""m n
.## 
Map## 
(## 
dest## 
=>## 
dest## !
.##! "
AddressLine2##" .
,##. /
src##0 3
=>##4 6
string##7 =
.##= >
IsNullOrEmpty##> K
(##K L
src##L O
.##O P
AddressLine2##P \
)##\ ]
?##^ _
string##` f
.##f g
Empty##g l
:##m n
src##o r
.##r s
AddressLine2##s 
)	## Ä
.$$ 
Map$$ 
($$ 
dest$$ 
=>$$ 
dest$$ !
.$$! "
	BirthDate$$" +
,$$+ ,
src$$- 0
=>$$1 3
GoogleDateTime$$4 B
.$$B C
FromDateTimeOffset$$C U
($$U V
src$$V Y
.$$Y Z
	BirthDate$$Z c
)$$c d
)$$d e
.%% 
Map%% 
(%% 
dest%% 
=>%% 
dest%% !
.%%! "
HireDate%%" *
,%%* +
src%%, /
=>%%0 2
GoogleDateTime%%3 A
.%%A B
FromDateTimeOffset%%B T
(%%T U
src%%U X
.%%X Y
HireDate%%Y a
)%%a b
)%%b c
;%%c d
config(( 
.(( 
	NewConfig(( 
<(( 
EmployeeListItem(( -
,((- .!
grpc_EmployeeListItem((/ D
>((D E
(((E F
)((F G
.)) 
Map)) 
()) 
dest)) 
=>)) 
dest)) !
.))! "

MiddleName))" ,
,)), -
src)). 1
=>))2 4
string))5 ;
.)); <
IsNullOrEmpty))< I
())I J
src))J M
.))M N

MiddleName))N X
)))X Y
?))Z [
string))\ b
.))b c
Empty))c h
:))i j
src))k n
.))n o

MiddleName))o y
)))y z
.** 
Map** 
(** 
dest** 
=>** 
dest** !
.**! "
ManagerName**" -
,**- .
src**/ 2
=>**3 5
string**6 <
.**< =
IsNullOrEmpty**= J
(**J K
src**K N
.**N O
ManagerName**O Z
)**Z [
?**\ ]
string**^ d
.**d e
Empty**e j
:**k l
src**m p
.**p q
ManagerName**q |
)**| }
;**} ~
config,, 
.,, 
	NewConfig,, 
<,, '
grpc_EmployeeGenericCommand,, 8
,,,8 9!
UpdateEmployeeCommand,,: O
>,,O P
(,,P Q
),,Q R
.-- 
Map-- 
(-- 
dest-- 
=>-- 
dest-- !
.--! "
Title--" '
,--' (
src--) ,
=>--- /
string--0 6
.--6 7
IsNullOrEmpty--7 D
(--D E
src--E H
.--H I
Title--I N
)--N O
?--P Q
null--R V
:--W X
src--Y \
.--\ ]
Title--] b
)--b c
... 
Map.. 
(.. 
dest.. 
=>.. 
dest.. !
...! "

MiddleName.." ,
,.., -
src... 1
=>..2 4
string..5 ;
...; <
IsNullOrEmpty..< I
(..I J
src..J M
...M N

MiddleName..N X
)..X Y
?..Z [
null..\ `
:..a b
src..c f
...f g

MiddleName..g q
)..q r
.// 
Map// 
(// 
dest// 
=>// 
dest// !
.//! "
Suffix//" (
,//( )
src//* -
=>//. 0
string//1 7
.//7 8
IsNullOrEmpty//8 E
(//E F
src//F I
.//I J
Suffix//J P
)//P Q
?//R S
null//T X
://Y Z
src//[ ^
.//^ _
Suffix//_ e
)//e f
.00 
Map00 
(00 
dest00 
=>00 
dest00 !
.00! "
AddressLine200" .
,00. /
src000 3
=>004 6
string007 =
.00= >
IsNullOrEmpty00> K
(00K L
src00L O
.00O P
AddressLine200P \
)00\ ]
?00^ _
null00` d
:00e f
src00g j
.00j k
AddressLine200k w
)00w x
.11 
Map11 
(11 
dest11 
=>11 
dest11 !
.11! "
	BirthDate11" +
,11+ ,
src11- 0
=>111 3
src114 7
.117 8
	BirthDate118 A
.11A B

ToDateTime11B L
(11L M
)11M N
.11N O
ToLocalTime11O Z
(11Z [
)11[ \
)11\ ]
.22 
Map22 
(22 
dest22 
=>22 
dest22 !
.22! "
HireDate22" *
,22* +
src22, /
=>220 2
src223 6
.226 7
HireDate227 ?
.22? @

ToDateTime22@ J
(22J K
)22K L
.22L M
ToLocalTime22M X
(22X Y
)22Y Z
)22Z [
;22[ \
config55 
.55 
	NewConfig55 
<55 '
grpc_EmployeeGenericCommand55 8
,558 9!
CreateEmployeeCommand55: O
>55O P
(55P Q
)55Q R
.66 
Map66 
(66 
dest66 
=>66 
dest66 !
.66! "
Title66" '
,66' (
src66) ,
=>66- /
string660 6
.666 7
IsNullOrEmpty667 D
(66D E
src66E H
.66H I
Title66I N
)66N O
?66P Q
null66R V
:66W X
src66Y \
.66\ ]
Title66] b
)66b c
.77 
Map77 
(77 
dest77 
=>77 
dest77 !
.77! "

MiddleName77" ,
,77, -
src77. 1
=>772 4
string775 ;
.77; <
IsNullOrEmpty77< I
(77I J
src77J M
.77M N

MiddleName77N X
)77X Y
?77Z [
null77\ `
:77a b
src77c f
.77f g

MiddleName77g q
)77q r
.88 
Map88 
(88 
dest88 
=>88 
dest88 !
.88! "
Suffix88" (
,88( )
src88* -
=>88. 0
string881 7
.887 8
IsNullOrEmpty888 E
(88E F
src88F I
.88I J
Suffix88J P
)88P Q
?88R S
null88T X
:88Y Z
src88[ ^
.88^ _
Suffix88_ e
)88e f
.99 
Map99 
(99 
dest99 
=>99 
dest99 !
.99! "
AddressLine299" .
,99. /
src990 3
=>994 6
string997 =
.99= >
IsNullOrEmpty99> K
(99K L
src99L O
.99O P
AddressLine299P \
)99\ ]
?99^ _
null99` d
:99e f
src99g j
.99j k
AddressLine299k w
)99w x
.:: 
Map:: 
(:: 
dest:: 
=>:: 
dest:: !
.::! "
	BirthDate::" +
,::+ ,
src::- 0
=>::1 3
src::4 7
.::7 8
	BirthDate::8 A
.::A B

ToDateTime::B L
(::L M
)::M N
.::N O
ToLocalTime::O Z
(::Z [
)::[ \
)::\ ]
.;; 
Map;; 
(;; 
dest;; 
=>;; 
dest;; !
.;;! "
HireDate;;" *
,;;* +
src;;, /
=>;;0 2
src;;3 6
.;;6 7
HireDate;;7 ?
.;;? @

ToDateTime;;@ J
(;;J K
);;K L
.;;L M
ToLocalTime;;M X
(;;X Y
);;Y Z
);;Z [
;;;[ \
config>> 
.>> 
	NewConfig>> 
<>> )
grpc_DepartmentHistoryCommand>> :
,>>: ;
AWC>>< ?
.>>? @
Shared>>@ F
.>>F G
Commands>>G O
.>>O P
HumanResources>>P ^
.>>^ _$
DepartmentHistoryCommand>>_ w
>>>w x
(>>x y
)>>y z
.?? 
Map?? 
(?? 
dest?? 
=>?? 
dest?? !
.??! "
BusinessEntityID??" 2
,??2 3
src??4 7
=>??8 :
src??; >
.??> ?
BusinessEntityId??? O
)??O P
.@@ 
Map@@ 
(@@ 
dest@@ 
=>@@ 
dest@@ !
.@@! "
DepartmentID@@" .
,@@. /
src@@0 3
=>@@4 6
src@@7 :
.@@: ;
DepartmentId@@; G
)@@G H
.AA 
MapAA 
(AA 
destAA 
=>AA 
destAA !
.AA! "
ShiftIDAA" )
,AA) *
srcAA+ .
=>AA/ 1
srcAA2 5
.AA5 6
ShiftIdAA6 =
)AA= >
.BB 
MapBB 
(BB 
destBB 
=>BB 
destBB !
.BB! "
	StartDateBB" +
,BB+ ,
srcBB- 0
=>BB1 3
srcBB4 7
.BB7 8
	StartDateBB8 A
.BBA B

ToDateTimeBBB L
(BBL M
)BBM N
.BBN O
ToLocalTimeBBO Z
(BBZ [
)BB[ \
)BB\ ]
.CC 
MapCC 
(CC 
destCC 
=>CC 
destCC !
.CC! "
EndDateCC" )
,CC) *
srcCC+ .
=>CC/ 1
srcCC2 5
.CC5 6
EndDateCC6 =
.CC= >

ToDateTimeCC> H
(CCH I
)CCI J
.CCJ K
ToLocalTimeCCK V
(CCV W
)CCW X
,CCX Y
srcCondCCZ a
=>CCb d
srcCondCCe l
.CCl m
EndDateCCm t
.CCt u
SecondsCCu |
<=CC} 
$num
CCÄ Å
)
CCÅ Ç
.DD 
MapDD 
(DD 
destDD 
=>DD 
destDD !
.DD! "
EndDateDD" )
,DD) *
srcDD+ .
=>DD/ 1
srcDD2 5
.DD5 6
EndDateDD6 =
.DD= >

ToDateTimeDD> H
(DDH I
)DDI J
.DDJ K
ToLocalTimeDDK V
(DDV W
)DDW X
)DDX Y
;DDY Z
configGG 
.GG 
	NewConfigGG 
<GG "
grpc_PayHistoryCommandGG 3
,GG3 4
AWCGG5 8
.GG8 9
SharedGG9 ?
.GG? @
CommandsGG@ H
.GGH I
HumanResourcesGGI W
.GGW X
PayHistoryCommandGGX i
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
BusinessEntityIDHH" 2
,HH2 3
srcHH4 7
=>HH8 :
srcHH; >
.HH> ?
BusinessEntityIdHH? O
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
=>II6 8
srcII9 <
.II< =
RateChangeDateII= K
.IIK L

ToDateTimeIIL V
(IIV W
)IIW X
.IIX Y
ToLocalTimeIIY d
(IId e
)IIe f
)IIf g
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
(JJ/ 0
decimalJJ0 7
)JJ7 8
srcJJ8 ;
.JJ; <
RateJJ< @
)JJ@ A
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
<NN 
AWCNN  
.NN  !
SharedNN! '
.NN' (
QueriesNN( /
.NN/ 0
HumanResourcesNN0 >
.NN> ?
DepartmentHistoryNN? P
,NNP Q"
grpc_DepartmentHistoryNNR h
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
BusinessEntityIdOO" 2
,OO2 3
srcOO4 7
=>OO8 :
srcOO; >
.OO> ?
BusinessEntityIDOO? O
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
=>RR1 3
GoogleDateTimeRR4 B
.RRB C
FromDateTimeOffsetRRC U
(RRU V
srcRRV Y
.RRY Z
	StartDateRRZ c
)RRc d
)RRd e
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
EndDateSS6 =
!=SS> @
nullSSA E
?SSF G
GoogleDateTimeSSH V
.SSV W
FromDateTimeOffsetSSW i
(SSi j
srcSSj m
.SSm n
EndDateSSn u
.SSu v
ValueSSv {
)SS{ |
:SS} ~
GoogleDateTime	SS ç
.
SSç é 
FromDateTimeOffset
SSé †
(
SS† °
new
SS° §
DateTimeOffset
SS• ≥
(
SS≥ ¥
)
SS¥ µ
)
SSµ ∂
)
SS∂ ∑
;
SS∑ ∏
configVV 
.VV 
	NewConfigVV 
<VV 
AWCVV  
.VV  !
SharedVV! '
.VV' (
QueriesVV( /
.VV/ 0
HumanResourcesVV0 >
.VV> ?

PayHistoryVV? I
,VVI J
grpc_PayHistoryVVK Z
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
BusinessEntityIdWW" 2
,WW2 3
srcWW4 7
=>WW8 :
srcWW; >
.WW> ?
BusinessEntityIDWW? O
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
=>XX6 8
GoogleDateTimeXX9 G
.XXG H
FromDateTimeOffsetXXH Z
(XXZ [
srcXX[ ^
.XX^ _
RateChangeDateXX_ m
)XXm n
)XXn o
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
=>YY, .
srcYY/ 2
.YY2 3
RateYY3 7
)YY7 8
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
;ZZH I
config]] 
.]] 
	NewConfig]] 
<]] 
AWC]]  
.]]  !
Shared]]! '
.]]' (
Queries]]( /
.]]/ 0
HumanResources]]0 >
.]]> ?$
DepartmentHistoryCommand]]? W
,]]W X)
grpc_DepartmentHistoryCommand]]Y v
>]]v w
(]]w x
)]]x y
.^^ 
Map^^ 
(^^ 
dest^^ 
=>^^ 
dest^^ !
.^^! "
BusinessEntityId^^" 2
,^^2 3
src^^4 7
=>^^8 :
src^^; >
.^^> ?
BusinessEntityID^^? O
)^^O P
.__ 
Map__ 
(__ 
dest__ 
=>__ 
dest__ !
.__! "
DepartmentId__" .
,__. /
src__0 3
=>__4 6
src__7 :
.__: ;
DepartmentID__; G
)__G H
.`` 
Map`` 
(`` 
dest`` 
=>`` 
dest`` !
.``! "
ShiftId``" )
,``) *
src``+ .
=>``/ 1
src``2 5
.``5 6
ShiftID``6 =
)``= >
.aa 
Mapaa 
(aa 
destaa 
=>aa 
destaa !
.aa! "
	StartDateaa" +
,aa+ ,
srcaa- 0
=>aa1 3
GoogleDateTimeaa4 B
.aaB C
FromDateTimeOffsetaaC U
(aaU V
srcaaV Y
.aaY Z
	StartDateaaZ c
)aac d
)aad e
.bb 
Mapbb 
(bb 
destbb 
=>bb 
destbb !
.bb! "
EndDatebb" )
,bb) *
srcbb+ .
=>bb/ 1
srcbb2 5
.bb5 6
EndDatebb6 =
!=bb> @
nullbbA E
?bbF G
GoogleDateTimebbH V
.bbV W
FromDateTimeOffsetbbW i
(bbi j
srcbbj m
.bbm n
EndDatebbn u
.bbu v
Valuebbv {
)bb{ |
:bb} ~
GoogleDateTime	bb ç
.
bbç é 
FromDateTimeOffset
bbé †
(
bb† °
new
bb° §
DateTimeOffset
bb• ≥
(
bb≥ ¥
)
bb¥ µ
)
bbµ ∂
)
bb∂ ∑
;
bb∑ ∏
configee 
.ee 
	NewConfigee 
<ee 
AWCee  
.ee  !
Sharedee! '
.ee' (
Queriesee( /
.ee/ 0
HumanResourcesee0 >
.ee> ?
PayHistoryCommandee? P
,eeP Q"
grpc_PayHistoryCommandeeR h
>eeh i
(eei j
)eej k
.ff 
Mapff 
(ff 
destff 
=>ff 
destff !
.ff! "
BusinessEntityIdff" 2
,ff2 3
srcff4 7
=>ff8 :
srcff; >
.ff> ?
BusinessEntityIDff? O
)ffO P
.gg 
Mapgg 
(gg 
destgg 
=>gg 
destgg !
.gg! "
RateChangeDategg" 0
,gg0 1
srcgg2 5
=>gg6 8
GoogleDateTimegg9 G
.ggG H
FromDateTimeOffsetggH Z
(ggZ [
srcgg[ ^
.gg^ _
RateChangeDategg_ m
)ggm n
)ggn o
.hh 
Maphh 
(hh 
desthh 
=>hh 
desthh !
.hh! "
Ratehh" &
,hh& '
srchh( +
=>hh, .
(hh/ 0
doublehh0 6
)hh6 7
srchh7 :
.hh: ;
Ratehh; ?
)hh? @
.ii 
Mapii 
(ii 
destii 
=>ii 
destii !
.ii! "
PayFrequencyii" .
,ii. /
srcii0 3
=>ii4 6
srcii7 :
.ii: ;
PayFrequencyii; G
)iiG H
;iiH I
}jj 	
}kk 
}ll µ#
f/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Mapping/Lookups/LookupsMappingConfig.cs
	namespace 	
AWC
 
. 
Server 
. 
Mapping 
. 
Lookups $
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
config 
. 
	NewConfig 
< 
	StateCode &
,& '"
grpc_StateProvinceCode( >
>> ?
(? @
)@ A
. 
Map 
( 
dest 
=> 
dest !
.! "
Id" $
,$ %
src& )
=>* ,
src- 0
.0 1
StateProvinceID1 @
)@ A
. 
Map 
( 
dest 
=> 
dest !
.! "
	StateCode" +
,+ ,
src- 0
=>1 3
src4 7
.7 8
StateProvinceCode8 I
)I J
. 
Map 
( 
dest 
=> 
dest !
.! "
StateProvinceName" 3
,3 4
src5 8
=>9 ;
src< ?
.? @
StateProvinceName@ Q
)Q R
;R S
config 
. 
	NewConfig 
< 
	ManagerId &
,& '
grpc_ManagerId( 6
>6 7
(7 8
)8 9
. 
Map 
( 
dest 
=> 
dest !
.! "
BusinessEntityId" 2
,2 3
src4 7
=>8 :
src; >
.> ?
BusinessEntityID? O
)O P
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentId" .
,. /
src0 3
=>4 6
src7 :
.: ;
DepartmentID; G
)G H
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentName" 0
,0 1
src2 5
=>6 8
src9 <
.< =
DepartmentName= K
)K L
. 
Map 
( 
dest 
=> 
dest !
.! "
JobTitle" *
,* +
src, /
=>0 2
src3 6
.6 7
JobTitle7 ?
)? @
. 
Map 
( 
dest 
=> 
dest !
.! "
ManagerFullName" 1
,1 2
src3 6
=>7 9
src: =
.= >
ManagerFullName> M
)M N
;N O
config 
. 
	NewConfig 
< 
DepartmentId )
,) *
grpc_DepartmentId+ <
>< =
(= >
)> ?
. 
Map 
( 
dest 
=> 
dest !
.! "
DepartmentId" .
,. /
src0 3
=>4 6
src7 :
.: ;
DepartmentID; G
)G H
. 
Map 
( 
dest 
=> 
dest !
.! "
Name" &
,& '
src( +
=>, .
src/ 2
.2 3
DepartmentName3 A
)A B
;B C
config 
. 
	NewConfig 
< 
ShiftId $
,$ %
grpc_ShiftId& 2
>2 3
(3 4
)4 5
. 
Map 
( 
dest 
=> 
dest !
.! "
ShiftId" )
,) *
src+ .
=>/ 1
src2 5
.5 6
ShiftID6 =
)= >
.   
Map   
(   
dest   
=>   
dest   !
.  ! "
Name  " &
,  & '
src  ( +
=>  , .
src  / 2
.  2 3
	ShiftName  3 <
)  < =
;  = >
}!! 	
}"" 
}## ™
d/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Mapping/Shared/SharedMappingConfig.cs
	namespace 	
AWC
 
. 
Server 
. 
Mapping 
. 
Shared #
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
< %
grpc_StringSearchCriteria 6
,6 7 
StringSearchCriteria8 L
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
} Ö%
h/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/ExceptionHandlingMiddleware.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
{ 
internal 
sealed 
class '
ExceptionHandlingMiddleware 5
:6 7
IMiddleware8 C
{ 
private		 
readonly		 
ILogger		  
<		  !'
ExceptionHandlingMiddleware		! <
>		< =
_logger		> E
;		E F
public '
ExceptionHandlingMiddleware *
(* +
ILogger+ 2
<2 3'
ExceptionHandlingMiddleware3 N
>N O
loggerP V
)V W
=>X Z
_logger[ b
=c d
loggere k
;k l
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
,9 :
RequestDelegate; J
nextK O
)O P
{ 	
try 
{ 
await 
next 
( 
context "
)" #
;# $
} 
catch 
( 
	Exception 
e 
) 
{ 
_logger 
. 
LogError  
(  !
e! "
," #
e$ %
.% &
Message& -
)- .
;. /
await  
HandleExceptionAsync *
(* +
context+ 2
,2 3
e4 5
)5 6
;6 7
} 
} 	
private 
static 
async 
Task ! 
HandleExceptionAsync" 6
(6 7
HttpContext7 B
httpContextC N
,N O
	ExceptionP Y
	exceptionZ c
)c d
{ 	
var 

statusCode 
= 
GetStatusCode *
(* +
	exception+ 4
)4 5
;5 6
var 
response 
= 
new 
{ 
title   
=   
GetTitle    
(    !
	exception  ! *
)  * +
,  + ,
status!! 
=!! 

statusCode!! #
,!!# $
detail"" 
="" 
	exception"" "
.""" #
Message""# *
,""* +
errors## 
=## 
(## 
	exception## #
is##$ &
ValidationException##' :
validationException##; N
)##N O
?##P Q
validationException##R e
.##e f
ErrorsDictionary##f v
:##w x
null##y }
}$$ 
;$$ 
httpContext&& 
.&& 
Response&&  
.&&  !
ContentType&&! ,
=&&- .
$str&&/ A
;&&A B
httpContext(( 
.(( 
Response((  
.((  !

StatusCode((! +
=((, -

statusCode((. 8
;((8 9
await** 
httpContext** 
.** 
Response** &
.**& '

WriteAsync**' 1
(**1 2
JsonSerializer**2 @
.**@ A
	Serialize**A J
(**J K
response**K S
)**S T
)**T U
;**U V
}++ 	
private-- 
static-- 
int-- 
GetStatusCode-- (
(--( )
	Exception--) 2
	exception--3 <
)--< =
=>--> @
	exception.. 
switch.. 
{// 
BadRequestException00 #
=>00$ &
StatusCodes00' 2
.002 3
Status400BadRequest003 F
,00F G
NotFoundException11 !
=>11" $
StatusCodes11% 0
.110 1
Status404NotFound111 B
,11B C
ValidationException22 #
=>22$ &
StatusCodes22' 2
.222 3(
Status422UnprocessableEntity223 O
,22O P
_33 
=>33 
StatusCodes33  
.33  !(
Status500InternalServerError33! =
}44 
;44 
private66 
static66 
string66 
GetTitle66 &
(66& '
	Exception66' 0
	exception661 :
)66: ;
=>66< >
	exception77 
switch77 
{88  
ApplicationException99 $ 
applicationException99% 9
=>99: < 
applicationException99= Q
.99Q R
Title99R W
,99W X
_:: 
=>:: 
$str:: #
};; 
;;; 
}<< 
}== ô
l/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/Exceptions/ApplicationException.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
.  

Exceptions  *
{ 
public 

abstract 
class  
ApplicationException .
:/ 0
	Exception1 :
{ 
	protected  
ApplicationException &
(& '
string' -
title. 3
,3 4
string5 ;
message< C
)C D
: 
base 
( 
message 
) 
=> 
Title		 
=		 
title		 
;		 
public 
string 
Title 
{ 
get !
;! "
}# $
} 
} ›
k/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/Exceptions/BadRequestException.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
.  

Exceptions  *
{ 
public 

abstract 
class 
BadRequestException -
:. / 
ApplicationException0 D
{ 
	protected 
BadRequestException %
(% &
string& ,
message- 4
)4 5
: 
base 
( 
$str  
,  !
message" )
)) *
{		 	
}

 	
} 
} ◊
i/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/Exceptions/NotFoundException.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
.  

Exceptions  *
{ 
public 

abstract 
class 
NotFoundException +
:, - 
ApplicationException. B
{ 
	protected 
NotFoundException #
(# $
string$ *
message+ 2
)2 3
: 
base 
( 
$str 
, 
message  '
)' (
{		 	
}

 	
} 
} ñ
m/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/Exceptions/UserNotFoundException.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
.  

Exceptions  *
{ 
public 

sealed 
class !
UserNotFoundException -
:. /
NotFoundException0 A
{ 
public !
UserNotFoundException $
($ %
int% (
userId) /
)/ 0
: 
base 
( 
$" 
$str 2
{2 3
userId3 9
}9 :
$str: I
"I J
)J K
{		 	
}

 	
} 
} Æ	
k/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/Exceptions/ValidationException.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
.  

Exceptions  *
{ 
public 

sealed 
class 
ValidationException +
:, - 
ApplicationException. B
{ 
public 
ValidationException "
(" #
IReadOnlyDictionary# 6
<6 7
string7 =
,= >
string? E
[E F
]F G
>G H
errorsDictionaryI Y
)Y Z
: 
base 
( 
$str '
,' (
$str) Q
)Q R
=>		 
ErrorsDictionary		 
=		  !
errorsDictionary		" 2
;		2 3
public 
IReadOnlyDictionary "
<" #
string# )
,) *
string+ 1
[1 2
]2 3
>3 4
ErrorsDictionary5 E
{F G
getH K
;K L
}M N
} 
} ∞
n/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Middleware/GlobalExceptionHandlingMiddleware.cs
	namespace 	
AWC
 
. 
Server 
. 

Middleware 
{ 
public		 

class		 -
!GlobalExceptionHandlingMiddleware		 2
:		3 4
IMiddleware		5 @
{

 
private 
readonly 
ILogger  
<  !-
!GlobalExceptionHandlingMiddleware! B
>B C
_loggerD K
;K L
public -
!GlobalExceptionHandlingMiddleware 0
(0 1
ILogger1 8
<8 9-
!GlobalExceptionHandlingMiddleware9 Z
>Z [
logger\ b
)b c
=> 
_logger 
= 
logger 
;  
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
,9 :
RequestDelegate; J
nextK O
)O P
{ 	
try 
{ 
await 
next 
( 
context "
)" #
;# $
} 
catch 
( 
	Exception 
ex 
)  
{ 
_logger 
. 
LogError  
(  !
ex! #
,# $
ex% '
.' (
Message( /
)/ 0
;0 1
context 
. 
Response  
.  !

StatusCode! +
=, -
( 
int 
) 
HttpStatusCode '
.' (
InternalServerError( ;
;; <
ProblemDetails 
problem &
=' (
new) ,
(, -
)- .
{ 
Status 
= 
( 
int !
)! "
HttpStatusCode" 0
.0 1
InternalServerError1 D
,D E
Type   
=   
$str   )
,  ) *
Title!! 
=!! 
$str!! *
,!!* +
Detail"" 
="" 
$str"" >
}## 
;## 
string%% 
json%% 
=%% 
JsonSerializer%% ,
.%%, -
	Serialize%%- 6
(%%6 7
problem%%7 >
)%%> ?
;%%? @
context'' 
.'' 
Response''  
.''  !
ContentType''! ,
=''- .
$str''/ A
;''A B
await)) 
context)) 
.)) 
Response)) &
.))& '

WriteAsync))' 1
())1 2
json))2 6
)))6 7
;))7 8
}** 
}++ 	
},, 
}-- À
T/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Pages/Error.cshtml.cs
	namespace 	
src
 
. 
Server 
. 
Pages 
; 
[ 
ResponseCache 
( 
Duration 
= 
$num 
, 
Location %
=& '!
ResponseCacheLocation( =
.= >
None> B
,B C
NoStoreD K
=L M
trueN R
)R S
]S T
[ "
IgnoreAntiforgeryToken 
] 
public		 
class		 

ErrorModel		 
:		 
	PageModel		 #
{

 
public 

string 
? 
	RequestId 
{ 
get "
;" #
set$ '
;' (
}) *
public 

bool 
ShowRequestId 
=>  
!! "
string" (
.( )
IsNullOrEmpty) 6
(6 7
	RequestId7 @
)@ A
;A B
public 

void 
OnGet 
( 
) 
{ 
	RequestId 
= 
Activity 
. 
Current $
?$ %
.% &
Id& (
??) +
HttpContext, 7
.7 8
TraceIdentifier8 G
;G H
} 
} óJ
I/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/Program.cs
var 
logger 

= 
NLog 
. 

LogManager 
. 
Setup "
(" #
)# $
.$ %,
 LoadConfigurationFromAppSettings% E
(E F
)F G
.G H!
GetCurrentClassLoggerH ]
(] ^
)^ _
;_ `"
GlobalDiagnosticsContext 
. 
Set 
( 
$str +
,+ ,
	Directory- 6
.6 7
GetCurrentDirectory7 J
(J K
)K L
)L M
;M N
logger 
. 
Debug 
( 
$str 
) 
; 
try 
{ 
var 
builder 
= 
WebApplication  
.  !
CreateBuilder! .
(. /
args/ 3
)3 4
;4 5
builder 
. 
Logging 
. 
ClearProviders "
(" #
)# $
;$ %
builder 
. 
Logging 
. 

AddConsole 
( 
)  
;  !
builder 
. 
Host 
. 
UseNLog 
( 
) 
; 
builder 
. 
Services 
. #
AddControllersWithViews ,
(, -
)- .
;. /
builder 
. 
Services 
. 
AddRazorPages "
(" #
)# $
;$ %
builder 
. 
Services 
. 
	AddCarter 
( 
)  
;  !
builder 
. 
Services 
. 

AddMediatR 
(  
ApplicationAssembly  3
.3 4
Instance4 <
)< =
;= >
builder 
. 
Services 
. /
#AddValidatorsFromAssemblyContaining 8
<8 9'
CreateEmployeeDataValidator9 T
>T U
(U V
)V W
;W X
builder   
.   
Services   
.   
	AddScoped   
(   
typeof   %
(  % &
IPipelineBehavior  & 7
<  7 8
,  8 9
>  9 :
)  : ;
,  ; <
typeof  = C
(  C D
LoggingBehavior  D S
<  S T
,  T U
>  U V
)  V W
)  W X
;  X Y
builder!! 
.!! 
Services!! 
.!! 
	AddScoped!! 
(!! 
typeof!! %
(!!% &
IPipelineBehavior!!& 7
<!!7 8
,!!8 9
>!!9 :
)!!: ;
,!!; <
typeof!!= C
(!!C D$
FluentValidationBehavior!!D \
<!!\ ]
,!!] ^
>!!^ _
)!!_ `
)!!` a
;!!a b
builder"" 
."" 
Services"" 
."" 
	AddScoped"" 
("" 
typeof"" %
(""% &
IPipelineBehavior""& 7
<""7 8
,""8 9
>""9 :
)"": ;
,""; <
typeof""= C
(""C D+
BusinessRulesValidationBehavior""D c
<""c d
,""d e
>""e f
)""f g
)""g h
;""h i
builder## 
.## 
Services## 
.## '
AddPipelineBehaviorServices## 0
(##0 1
)##1 2
;##2 3
builder&& 
.&& 
Services&& 
.&& 
ConfigureCors&& "
(&&" #
)&&# $
;&&$ %
builder'' 
.'' 
Services'' 
.'' %
AddInfrastructureServices'' .
(''. /
)''/ 0
;''0 1
builder(( 
.(( 
Services(( 
.(( $
ConfigureEfCoreDbContext(( -
(((- .
)((. /
;((/ 0
builder)) 
.)) 
Services)) 
.)) 
ConfigureDapper)) $
())$ %
)))% &
;))& '
builder** 
.** 
Services** 
.** 
AddMappings**  
(**  !
)**! "
;**" #
builder++ 
.++ 
Services++ 
.++ !
AddRepositoryServices++ *
(++* +
)+++ ,
;++, -
builder,, 
.,, 
Services,, 
.,, 
AddTransient,, !
<,,! "'
ExceptionHandlingMiddleware,," =
>,,= >
(,,> ?
),,? @
;,,@ A
builder.. 
... 
Services.. 
... 
AddGrpc.. 
(.. 
options.. $
=>..% '
{// 
options00 
.00  
EnableDetailedErrors00 $
=00% &
Environment00' 2
.002 3"
GetEnvironmentVariable003 I
(00I J
$str00J b
)00b c
==00d f
$str00g t
;00t u
options11 
.11 
Interceptors11 
.11 
Add11  
<11  !$
ServerTracingInterceptor11! 9
>119 :
(11: ;
)11; <
;11< =
}22 
)22 
;22 
builder44 
.44 
Services44 
.44 
AddGrpcReflection44 &
(44& '
)44' (
;44( )
var66 
app66 
=66 
builder66 
.66 
Build66 
(66 
)66 
;66 
if99 
(99 
app99 
.99 
Environment99 
.99 
IsDevelopment99 %
(99% &
)99& '
)99' (
{:: 
app;; 
.;; #
UseWebAssemblyDebugging;; #
(;;# $
);;$ %
;;;% &
}<< 
else== 
{>> 
app?? 
.?? 
UseExceptionHandler?? 
(??  
$str??  (
)??( )
;??) *
appAA 
.AA 
UseHstsAA 
(AA 
)AA 
;AA 
}BB 
appDD 
.DD 
UseHttpsRedirectionDD 
(DD 
)DD 
;DD 
appEE 
.EE 
UseMiddlewareEE 
<EE '
ExceptionHandlingMiddlewareEE 1
>EE1 2
(EE2 3
)EE3 4
;EE4 5
appFF 
.FF #
UseBlazorFrameworkFilesFF 
(FF  
)FF  !
;FF! "
appGG 
.GG 
UseStaticFilesGG 
(GG 
)GG 
;GG 
appII 
.II 

UseRoutingII 
(II 
)II 
;II 
appJJ 
.JJ 
UseCorsJJ 
(JJ 
$strJJ 
)JJ 
;JJ 
appKK 
.KK 

UseGrpcWebKK 
(KK 
newKK 
GrpcWebOptionsKK %
{KK& '
DefaultEnabledKK( 6
=KK7 8
trueKK9 =
}KK> ?
)KK? @
;KK@ A
appLL 
.LL $
MapGrpcReflectionServiceLL  
(LL  !
)LL! "
;LL" #
appMM 
.MM 
MapGrpcServiceMM 
<MM "
CompanyContractServiceMM -
>MM- .
(MM. /
)MM/ 0
.MM0 1
RequireCorsMM1 <
(MM< =
$strMM= G
)MMG H
;MMH I
appNN 
.NN 
MapGrpcServiceNN 
<NN "
LookupsContractServiceNN -
>NN- .
(NN. /
)NN/ 0
.NN0 1
RequireCorsNN1 <
(NN< =
$strNN= G
)NNG H
;NNH I
appOO 
.OO 
MapGrpcServiceOO 
<OO #
EmployeeContractServiceOO .
>OO. /
(OO/ 0
)OO0 1
.OO1 2
RequireCorsOO2 =
(OO= >
$strOO> H
)OOH I
;OOI J
appRR 
.RR 
MapRazorPagesRR 
(RR 
)RR 
;RR 
appSS 
.SS 
MapControllersSS 
(SS 
)SS 
;SS 
appTT 
.TT 
MapFallbackToFileTT 
(TT 
$strTT &
)TT& '
;TT' (
appUU 
.UU 
	MapCarterUU 
(UU 
)UU 
;UU 
appWW 
.WW 
RunWW 
(WW 
)WW 
;WW 
}XX 
catchYY 
(YY 
	ExceptionYY 
	exceptionYY 
)YY 
{ZZ 
logger[[ 

.[[
 
Error[[ 
([[ 
	exception[[ 
,[[ 
$str[[ B
)[[B C
;[[C D
throw\\ 	
;\\	 

}]] 
finally^^ 
{__ 
NLogaa 
.aa 	

LogManageraa	 
.aa 
Shutdownaa 
(aa 
)aa 
;aa 
}bb 
	namespacedd 	
AWCdd
 
.dd 
Serverdd 
{ee 
publicff 

partialff 
classff 
Programff  
{gg 
}ii 
}jj •
P/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Server/ServerAssembly.cs
	namespace 	
AWC
 
. 
Server 
{ 
public 

static 
class 
ServerAssembly &
{ 
public 
static 
readonly 
Assembly '
Instance( 0
=1 2
typeof3 9
(9 :
ServerAssembly: H
)H I
.I J
AssemblyJ R
;R S
} 
}		 