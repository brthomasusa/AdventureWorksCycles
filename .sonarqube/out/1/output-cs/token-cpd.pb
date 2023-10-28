õ
Z/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/AggregateRoot.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
AggregateRoot '
<' (
T( )
>) *
:+ ,
Entity- 3
<3 4
T4 5
>5 6
,6 7
IAggregateRoot8 F
{ 
private 
List 
< 
DomainEvent  
>  !
?! "
_domainEvents# 0
;0 1
public 
IReadOnlyCollection "
<" #
DomainEvent# .
>. /
?/ 0
DomainEvents1 =
=>> @
_domainEventsA N
!N O
.O P

AsReadOnlyP Z
(Z [
)[ \
;\ ]
	protected

 
void

 
AddDomainEvent

 %
(

% &
DomainEvent

& 1
	eventItem

2 ;
)

; <
{ 	
_domainEvents 
??= 
new !
List" &
<& '
DomainEvent' 2
>2 3
(3 4
)4 5
;5 6
_domainEvents 
. 
Add 
( 
	eventItem '
)' (
;( )
} 	
public 
void 
ClearDomainEvents %
(% &
)& '
{ 	
_domainEvents 
? 
. 
Clear  
(  !
)! "
;" #
} 	
} 
} À
Y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/BusinessRule.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
BusinessRule &
<& '
T' (
>( )
:* +
IBusinessRule, 9
<9 :
T: ;
>; <
{ 
	protected 
IBusinessRule 
<  
T  !
>! "
?" #
Next$ (
{) *
get+ .
;. /
private0 7
set8 ;
;; <
}= >
public		 
void		 
SetNext		 
(		 
IBusinessRule		 )
<		) *
T		* +
>		+ ,
next		- 1
)		1 2
{

 	
Next 
= 
next 
; 
} 	
public 
virtual 
async 
Task !
<! "
ValidationResult" 2
>2 3
Validate4 <
(< =
T= >
request? F
)F G
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
if 
( 
Next 
is 
not 
null  
)  !
{ 
await 
Next 
. 
Validate #
(# $
request$ +
)+ ,
;, -
} 
return 
validationResult #
;# $
} 	
} 
} Ù
X/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/DomainEvent.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
record 
DomainEvent &
:' (
INotification) 6
;6 7
} Ò
S/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/Entity.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
Entity  
<  !
T! "
>" #
{ 
public 
T 
Id 
{ 
get 
; 
	protected $
set% (
;( )
}* +
public		 
DateTime		 
?		 
ModifiedDate		 %
{		& '
get		( +
;		+ ,
private		- 4
set		5 8
;		8 9
}		: ;
public 
void 
UpdateModifiedDate &
(& '
)' (
{ 	
ModifiedDate 
= 
DateTime #
.# $
UtcNow$ *
;* +
} 	
	protected 
virtual 
void 
CheckValidity ,
(, -
)- .
{ 	
} 	
} 
} Ê
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/IgnoreMemberAttribute.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
[ 
AttributeUsage 
( 
AttributeTargets $
.$ %
Property% -
|. /
AttributeTargets0 @
.@ A
FieldA F
)F G
]G H
public 

class !
IgnoreMemberAttribute &
:' (
	Attribute) 2
{3 4
}5 6
} ‘	
]/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/IntegrationEvent.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
IntegrationEvent *
{ 
	protected 
IntegrationEvent "
(" #
)# $
:% &
this' +
(+ ,
Guid, 0
.0 1
NewGuid1 8
(8 9
)9 :
): ;
{ 	
CreatedDate 
= 
DateTime "
." #
Now# &
;& '
}		 	
	protected 
IntegrationEvent "
(" #
Guid# '
id( *
)* +
{ 	
Id 
= 
id 
; 
CreatedDate 
= 
DateTime "
." #
Now# &
;& '
} 	
public 
readonly 
Guid 
Id 
;  
public 
readonly 
DateTime  
CreatedDate! ,
;, -
} 
} ˛
]/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/ValidationResult.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

class 
ValidationResult !
{ 
public 
bool 
IsValid 
{ 
get !
;! "
set# &
;& '
}( )
public 
List 
< 
string 
> 
Messages $
{% &
get' *
;* +
set, /
;/ 0
}1 2
=3 4
new5 8
(8 9
)9 :
;: ;
} 
} ª@
X/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/ValueObject.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
ValueObject %
:& '

IEquatable( 2
<2 3
ValueObject3 >
>> ?
{ 
private		 
List		 
<		 
PropertyInfo		 !
>		! "

properties		# -
;		- .
private

 
List

 
<

 
	FieldInfo

 
>

 
fields

  &
;

& '
public 
static 
bool 
operator #
==$ &
(& '
ValueObject' 2
obj13 7
,7 8
ValueObject9 D
obj2E I
)I J
{ 	
if 
( 
object 
. 
Equals 
( 
obj1 "
," #
null$ (
)( )
)) *
{ 
return 
object 
. 
Equals $
($ %
obj2% )
,) *
null+ /
)/ 0
;0 1
} 
return 
obj1 
. 
Equals 
( 
obj2 #
)# $
;$ %
} 	
public 
static 
bool 
operator #
!=$ &
(& '
ValueObject' 2
obj13 7
,7 8
ValueObject9 D
obj2E I
)I J
{ 	
return 
! 
( 
obj1 
== 
obj2 !
)! "
;" #
} 	
public 
bool 
Equals 
( 
ValueObject &
obj' *
)* +
{ 	
return 
Equals 
( 
obj 
as  
object! '
)' (
;( )
} 	
public 
override 
bool 
Equals #
(# $
object$ *
obj+ .
). /
{   	
if!! 
(!! 
obj!! 
==!! 
null!! 
||!! 
GetType!! &
(!!& '
)!!' (
!=!!) +
obj!!, /
.!!/ 0
GetType!!0 7
(!!7 8
)!!8 9
)!!9 :
return!!; A
false!!B G
;!!G H
return## 
GetProperties##  
(##  !
)##! "
.##" #
All### &
(##& '
p##' (
=>##) +
PropertiesAreEqual##, >
(##> ?
obj##? B
,##B C
p##D E
)##E F
)##F G
&&$$ 
	GetFields$$ 
($$ 
)$$ 
.$$ 
All$$ "
($$" #
f$$# $
=>$$% '
FieldsAreEqual$$( 6
($$6 7
obj$$7 :
,$$: ;
f$$< =
)$$= >
)$$> ?
;$$? @
}%% 	
private'' 
bool'' 
PropertiesAreEqual'' '
(''' (
object''( .
obj''/ 2
,''2 3
PropertyInfo''4 @
p''A B
)''B C
{(( 	
return)) 
object)) 
.)) 
Equals))  
())  !
p))! "
.))" #
GetValue))# +
())+ ,
this)), 0
,))0 1
null))2 6
)))6 7
,))7 8
p))9 :
.)): ;
GetValue)); C
())C D
obj))D G
,))G H
null))I M
)))M N
)))N O
;))O P
}** 	
private,, 
bool,, 
FieldsAreEqual,, #
(,,# $
object,,$ *
obj,,+ .
,,,. /
	FieldInfo,,0 9
f,,: ;
),,; <
{-- 	
return.. 
object.. 
... 
Equals..  
(..  !
f..! "
..." #
GetValue..# +
(..+ ,
this.., 0
)..0 1
,..1 2
f..3 4
...4 5
GetValue..5 =
(..= >
obj..> A
)..A B
)..B C
;..C D
}// 	
private11 
IEnumerable11 
<11 
PropertyInfo11 (
>11( )
GetProperties11* 7
(117 8
)118 9
{22 	
return33 
this33 
.33 

properties33 "
??=33# &
GetType33' .
(33. /
)33/ 0
.44 
GetProperties44 "
(44" #
BindingFlags44# /
.44/ 0
Instance440 8
|449 :
BindingFlags44; G
.44G H
Public44H N
)44N O
.55 
Where55 
(55 
p55 
=>55 
p55  !
.55! "
GetCustomAttribute55" 4
(554 5
typeof555 ;
(55; <!
IgnoreMemberAttribute55< Q
)55Q R
)55R S
==55T V
null55W [
)55[ \
.66 
ToList66 
(66 
)66 
;66 
}77 	
private99 
IEnumerable99 
<99 
	FieldInfo99 %
>99% &
	GetFields99' 0
(990 1
)991 2
{:: 	
return;; 
this;; 
.;; 
fields;; 
??=;; "
GetType;;# *
(;;* +
);;+ ,
.;;, -
	GetFields;;- 6
(;;6 7
BindingFlags;;7 C
.;;C D
Instance;;D L
|;;M N
BindingFlags;;O [
.;;[ \
Public;;\ b
);;b c
.<< 
Where<< 
(<< 
p<< 
=><< 
p<<  !
.<<! "
GetCustomAttribute<<" 4
(<<4 5
typeof<<5 ;
(<<; <!
IgnoreMemberAttribute<<< Q
)<<Q R
)<<R S
==<<T V
null<<W [
)<<[ \
.== 
ToList== 
(== 
)== 
;== 
}>> 	
public@@ 
override@@ 
int@@ 
GetHashCode@@ '
(@@' (
)@@( )
{AA 	
	uncheckedBB 
{CC 
intDD 
hashDD 
=DD 
$numDD 
;DD 
foreachEE 
(EE 
varEE 
propEE !
inEE" $
GetPropertiesEE% 2
(EE2 3
)EE3 4
)EE4 5
{FF 
varGG 
valueGG 
=GG 
propGG  $
.GG$ %
GetValueGG% -
(GG- .
thisGG. 2
,GG2 3
nullGG4 8
)GG8 9
;GG9 :
hashHH 
=HH 
	HashValueHH $
(HH$ %
hashHH% )
,HH) *
valueHH+ 0
)HH0 1
;HH1 2
}II 
foreachKK 
(KK 
varKK 
fieldKK "
inKK# %
	GetFieldsKK& /
(KK/ 0
)KK0 1
)KK1 2
{LL 
varMM 
valueMM 
=MM 
fieldMM  %
.MM% &
GetValueMM& .
(MM. /
thisMM/ 3
)MM3 4
;MM4 5
hashNN 
=NN 
	HashValueNN $
(NN$ %
hashNN% )
,NN) *
valueNN+ 0
)NN0 1
;NN1 2
}OO 
returnQQ 
hashQQ 
;QQ 
}RR 
}SS 	
privateUU 
staticUU 
intUU 
	HashValueUU $
(UU$ %
intUU% (
seedUU) -
,UU- .
objectUU/ 5
valueUU6 ;
)UU; <
{VV 	
varWW 
currentHashWW 
=WW 
(WW 
valueWW $
?WW$ %
.WW% &
GetHashCodeWW& 1
(WW1 2
)WW2 3
)WW3 4
??WW5 7
$numWW8 9
;WW9 :
returnYY 
(YY 
seedYY 
*YY 
$numYY 
)YY 
+YY  
currentHashYY! ,
;YY, -
}ZZ 	
}[[ 
}\\ °	
r/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Exceptions/BusinessRuleValidationException.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Exceptions %
{ 
public 

class +
BusinessRuleValidationException 0
:1 2
	Exception3 <
{ 
public +
BusinessRuleValidationException .
(. /
string/ 5
message6 =
,= >
	Exception? H
exI K
)K L
:M N
baseO S
(S T
messageT [
,[ \
ex] _
)_ `
{ 	
} 	
public		 +
BusinessRuleValidationException		 .
(		. /
string		/ 5
message		6 =
)		= >
:		? @
base		A E
(		E F
message		F M
)		M N
{

 	
} 	
public +
BusinessRuleValidationException .
(. /
)/ 0
:1 2
base3 7
(7 8
)8 9
{ 	
} 	
} 
} —
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Exceptions/DomainException.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Exceptions %
{ 
public 

class 
DomainException  
:! "
	Exception# ,
{ 
public 
DomainException 
( 
string %
message& -
,- .
	Exception/ 8
ex9 ;
); <
:= >
base? C
(C D
messageD K
,K L
exM O
)O P
{ 	
} 	
public

 
DomainException

 
(

 
string

 %
message

& -
)

- .
:

/ 0
base

1 5
(

5 6
message

6 =
)

= >
{ 	
} 	
public 
DomainException 
( 
)  
:! "
base# '
(' (
)( )
{ 	
} 	
} 
} £	
d/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Exceptions/NotFoundException.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Exceptions %
{ 
public 

class 
NotFoundException "
:# $
	Exception% .
{ 
public 
NotFoundException  
(  !
)! "
:# $
base% )
() *
$str* 5
)5 6
{ 	
} 	
public

 
NotFoundException

  
(

  !
string

! '
message

( /
)

/ 0
:

1 2
base

3 7
(

7 8
message

8 ?
)

? @
{ 	
} 	
public 
NotFoundException  
(  !
string! '
?' (
message) 0
,0 1
	Exception2 ;
?; <
innerException= K
)K L
:M N
baseO S
(S T
messageT [
,[ \
innerException] k
)k l
{ 	
} 	
} 
} ≥
T/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/Guard.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

	interface 
IGuardClause !
{ 
} 
public 

sealed 
class 
Guard 
: 
IGuardClause  ,
{		 
public

 
static

 
IGuardClause

 "
Against

# *
{

+ ,
get

- 0
;

0 1
}

2 3
=

4 5
new

6 9
Guard

: ?
(

? @
)

@ A
;

A B
private 
Guard 
( 
) 
{ 
} 
} 
} â
p/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardAgainstDefaultDateExtensions.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

static 
partial 
class !
GuardClauseExtensions  5
{ 
public 
static 
DateTime 
DefaultDateTime .
( 	
this		 
IGuardClause		 
guardClause		 )
,		) *
DateTime

 
input

 
,

 
string 
? 
message 
= 
null "
," #
[ $
CallerArgumentExpression %
(% &
$str& -
)- .
]. /
string0 6
?6 7
parameterName8 E
=F G
nullH L
) 	
{ 	
if 
( 
input 
== 
default  
)  !
{ 
Error 
( 
message 
??  
$"! #
$str# 3
{3 4
parameterName4 A
}A B
$strB O
"O P
)P Q
;Q R
} 
return 
input 
; 
} 	
public 
static 
DateOnly 
DefaultDateTime .
(. /
this/ 3
IGuardClause4 @
guardClauseA L
,L M
DateOnlyN V
inputW \
,\ ]
string^ d
parameterNamee r
=s t
$stru |
,| }
string	~ Ñ
message
Ö å
=
ç é
null
è ì
!
ì î
)
î ï
{ 	
if 
( 
input 
== 
default  
)  !
{ 
Error 
( 
message 
??  
$"! #
$str# 3
{3 4
parameterName4 A
}A B
$strB O
"O P
)P Q
;Q R
} 
return 
input 
; 
} 	
} 
} £
k/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardAgainstLengthExtensions.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

static 
partial 
class !
GuardClauseExtensions  5
{ 
public 
static 
string 
LengthGreaterThan .
( 	
this		 
IGuardClause		 
guardClause		 )
,		) *
string

 
input

 
,

 
int 
	maxLength 
, 
string 
message 
= 
null !
!! "
," #
[ $
CallerArgumentExpression %
(% &
$str& -
)- .
]. /
string0 6
?6 7
parameterName8 E
=F G
nullH L
) 	
{ 	
if 
( 
input 
. 
Length 
> 
	maxLength (
)( )
{ 
Error 
( 
message 
??  
$"! #
$str# $
{$ %
parameterName% 2
}2 3
$str3 Z
{Z [
	maxLength[ d
}d e
$stre q
"q r
)r s
;s t
} 
return 
input 
; 
} 	
} 
} ø
i/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardAgainstNullExtensions.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

static 
partial 
class !
GuardClauseExtensions  5
{ 
public 
static 
string 
NullOrEmpty (
( 	
this		 
IGuardClause		 
guardClause		 )
,		) *
string

 
input

 
,

 
string 
? 
message 
= 
null "
," #
[ $
CallerArgumentExpression %
(% &
$str& -
)- .
]. /
string0 6
?6 7
parameterName8 E
=F G
nullH L
) 	
{ 	
if 
( 
string 
. 
IsNullOrEmpty $
($ %
input% *
)* +
)+ ,
{ 
Error 
( 
message 
??  
$"! #
$str# 3
{3 4
parameterName4 A
}A B
$strB O
"O P
)P Q
;Q R
} 
return 
input 
! 
; 
} 	
} 
} ·-
k/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardAgainstNumberExtensions.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

static 
partial 
class !
GuardClauseExtensions  5
{ 
public 
static 
int 
LessThan "
( 	
this		 
IGuardClause		 
guardClause		 )
,		) *
int

 
input

 
,

 
int 
minValue 
, 
string 
message 
= 
null !
!! "
," #
[ $
CallerArgumentExpression %
(% &
$str& -
)- .
]. /
string0 6
?6 7
parameterName8 E
=F G
nullH L
) 	
{ 	
if 
( 
input 
< 
minValue  
)  !
{ 
Error 
( 
message 
??  
$"! #
$str# $
{$ %
parameterName% 2
}2 3
$str3 K
{K L
minValueL T
}T U
$strU V
"V W
)W X
;X Y
} 
return 
input 
; 
} 	
public 
static 
decimal 
LessThan &
( 	
this 
IGuardClause 
guardClause )
,) *
decimal 
input 
, 
decimal 
minValue 
, 
string 
message 
= 
null !
!! "
," #
[ $
CallerArgumentExpression %
(% &
$str& -
)- .
]. /
string0 6
?6 7
parameterName8 E
=F G
nullH L
) 	
{ 	
if   
(   
input   
<   
minValue    
)    !
{!! 
Error"" 
("" 
message"" 
??""  
$"""! #
$str""# $
{""$ %
parameterName""% 2
}""2 3
$str""3 K
{""K L
minValue""L T
}""T U
$str""U V
"""V W
)""W X
;""X Y
}## 
return$$ 
input$$ 
;$$ 
}%% 	
public'' 
static'' 
int'' 
GreaterThan'' %
((( 	
this)) 
IGuardClause)) 
guardClause)) )
,))) *
int** 
input** 
,** 
int++ 
minValue++ 
,++ 
string,, 
message,, 
=,, 
null,, !
!,,! "
,,," #
[-- $
CallerArgumentExpression-- %
(--% &
$str--& -
)--- .
]--. /
string--0 6
?--6 7
parameterName--8 E
=--F G
null--H L
).. 	
{// 	
if00 
(00 
input00 
<00 
minValue00  
)00  !
{11 
Error22 
(22 
message22 
??22  
$"22! #
$str22# $
{22$ %
parameterName22% 2
}222 3
$str223 V
{22V W
minValue22W _
}22_ `
$str22` a
"22a b
)22b c
;22c d
}33 
return44 
input44 
;44 
}55 	
public77 
static77 
decimal77 
GreaterThan77 )
(88 	
this99 
IGuardClause99 
guardClause99 )
,99) *
decimal:: 
input:: 
,:: 
int;; 
minValue;; 
,;; 
string<< 
message<< 
=<< 
null<< !
!<<! "
,<<" #
[== $
CallerArgumentExpression== %
(==% &
$str==& -
)==- .
]==. /
string==0 6
?==6 7
parameterName==8 E
===F G
null==H L
)>> 	
{?? 	
if@@ 
(@@ 
input@@ 
<@@ 
minValue@@  
)@@  !
{AA 
ErrorBB 
(BB 
messageBB 
??BB  
$"BB! #
$strBB# $
{BB$ %
parameterNameBB% 2
}BB2 3
$strBB3 V
{BBV W
minValueBBW _
}BB_ `
$strBB` a
"BBa b
)BBb c
;BBc d
}CC 
returnDD 
inputDD 
;DD 
}EE 	
publicGG 
staticGG 
decimalGG '
GreaterThanTwoDecimalPlacesGG 9
(GG9 :
thisGG: >
IGuardClauseGG? K
guardClauseGGL W
,GGW X
decimalGGY `
inputGGa f
,GGf g
stringGGh n
parameterNameGGo |
=GG} ~
$str	GG á
,
GGá à
string
GGâ è
message
GGê ó
=
GGò ô
null
GGö û
!
GGû ü
)
GGü †
{HH 	
ifII 
(II 
inputII 
%II 
$numII 
!=II  
$numII! "
)II" #
{JJ 
ErrorKK 
(KK 
messageKK 
??KK  
$"KK! #
$strKK# $
{KK$ %
parameterNameKK% 2
}KK2 3
$strKK3 V
"KKV W
)KKW X
;KKX Y
}LL 
returnMM 
inputMM 
;MM 
}NN 	
}OO 
}PP “

h/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardAgainstUrlExtensions.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

static 
partial 
class !
GuardClauseExtensions  5
{ 
public 
static 
string 

InvalidUrl '
(' (
this( ,
IGuardClause- 9
guardClause: E
,E F
stringG M
urlN Q
,Q R
stringS Y
parameterNameZ g
=h i
$strj o
,o p
stringq w
messagex 
=
Ä Å
null
Ç Ü
!
Ü á
)
á à
{ 	
try 
{		 
_

 
=

 
new

 
Uri

 
(

 
url

 
)

  
;

  !
} 
catch 
{ 
Error 
( 
message 
??  
$"! #
$str# 5
{5 6
parameterName6 C
}C D
$strD E
"E F
)F G
;G H
} 
return 
url 
; 
} 	
} 
} π
d/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardClauseExtensions.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Guards !
{ 
public 

static 
partial 
class !
GuardClauseExtensions  5
{ 
private 
static 
void 
Error !
(! "
string" (
message) 0
)0 1
{ 	
throw		 
new		 
DomainException		 %
(		% &
message		& -
)		- .
;		. /
}

 	
} 
} ÿ
a/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Interfaces/IAggregateRoot.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Interfaces %
{ 
public 

	interface 
IAggregateRoot #
{ 
} 
} Ê
`/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Interfaces/IBusinessRule.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Interfaces %
{ 
public 

	interface 
IBusinessRule "
<" #
T# $
>$ %
{ 
void 
SetNext 
( 
IBusinessRule "
<" #
T# $
>$ %
next& *
)* +
;+ ,
Task		 
<		 
ValidationResult		 
>		 
Validate		 '
(		' (
T		( )
request		* 1
)		1 2
;		2 3
}

 
} •
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Interfaces/ICommandHandler.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Interfaces %
{ 
public 

	interface 
ICommandHandler $
<$ %
TCommand% -
>- .
{ 
Task 
< 
Result 
< 
bool 
> 
> 
Handle !
(! "
TCommand" *
command+ 2
)2 3
;3 4
void		 
SetNext		 
(		 
ICommandHandler		 $
<		$ %
TCommand		% -
>		- .
next		/ 3
)		3 4
;		4 5
}

 
} √

^/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Interfaces/IRepository.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Interfaces %
{ 
public 

	interface 
IRepository  
<  !
T! "
>" #
{ 
Task 
< 
Result 
< 
T 
> 
> 
GetByIdAsync $
($ %
int% (
id) +
,+ ,
bool- 1
asNoTracking2 >
=? @
falseA F
)F G
;G H
Task 
< 
Result 
< 
int 
> 
> 
InsertAsync %
(% &
T& '
entity( .
). /
;/ 0
Task		 
<		 
Result		 
<		 
int		 
>		 
>		 
Update		  
(		  !
T		! "
entity		# )
)		) *
;		* +
Task

 
<

 
Result

 
<

 
int

 
>

 
>

 
Delete

  
(

  !
int

! $
entityID

% -
)

- .
;

. /
} 
} „
^/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Interfaces/IUnitOfWork.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 

Interfaces %
{ 
public 

	interface 
IUnitOfWork  
:! "
IDisposable# .
{ 
Task 
< 
int 
> 
CommitAsync 
( 
CancellationToken /
cancellationToken0 A
=B C
defaultD K
)K L
;L M
} 
} ∞$
W/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/Error.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
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
}88 Á
Y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/Helpers.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
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
;Q R
public 
static 

Dictionary  
<  !
string! '
,' (
int) ,
>, -
LoadMetaData. :
(: ;
MetaData; C
dataD H
)H I
{		 	

Dictionary

 
<

 
string

 
,

 
int

 "
>

" #
metaData

$ ,
=

- .
new

/ 2
(

2 3
)

3 4
{ 
{ 
$str 
, 
data  $
.$ %

TotalCount% /
}0 1
,1 2
{ 
$str 
, 
data "
." #
PageSize# +
}, -
,- .
{ 
$str 
,  
data! %
.% &
CurrentPage& 1
}2 3
,3 4
{ 
$str 
, 
data  $
.$ %

TotalPages% /
}0 1
} 
; 
return 
metaData 
; 
} 	
} 
} Á	
Z/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/MetaData.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
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
} ﬂ
[/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/PagedList.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
{ 
public 

class 
	PagedList 
< 
T 
> 
: 
List  $
<$ %
T% &
>& '
{ 
public 
MetaData 
MetaData  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
	PagedList 
( 
List 
< 
T 
>  
items! &
,& '
int( +
count, 1
,1 2
int3 6

pageNumber7 A
,A B
intC F
pageSizeG O
)O P
{ 	
MetaData		 
=		 
new		 
MetaData		 #
{

 

TotalCount 
= 
count "
," #
PageSize 
= 
pageSize #
,# $
CurrentPage 
= 

pageNumber (
,( )

TotalPages 
= 
( 
int !
)! "
Math" &
.& '
Ceiling' .
(. /
count/ 4
/5 6
(7 8
double8 >
)> ?
pageSize? G
)G H
} 
; 
AddRange 
( 
items 
) 
; 
} 	
public 
static 
	PagedList 
<  
T  !
>! "
CreatePagedList# 2
(2 3
List3 7
<7 8
T8 9
>9 :
source; A
,A B
intC F
totalRecordsG S
,S T
intU X

pageNumberY c
,c d
inte h
pageSizei q
)q r
{ 	
return 
new 
	PagedList  
<  !
T! "
>" #
(# $
source$ *
,* +
totalRecords, 8
,8 9

pageNumber: D
,D E
pageSizeF N
)N O
;O P
} 	
} 
} ≈
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/PagingParameters.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
{ 
public 

record 
PagingParameters "
(" #
int# &

PageNumber' 1
,1 2
int3 6
PageSize7 ?
)? @
;@ A
} É)
X/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/Result.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
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
}66 ◊
Y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/ResultT.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
	Utilities $
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
} 