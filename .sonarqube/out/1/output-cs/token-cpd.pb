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
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
BusinessRule &
<& '
T' (
>( )
:* +
IBusinessRule, 9
<9 :
T: ;
>; <
{ 
	protected 
IBusinessRule 
<  
T  !
>! "
?" #
Next$ (
{) *
get+ .
;. /
private0 7
set8 ;
;; <
}= >
public

 
void

 
SetNext

 
(

 
IBusinessRule

 )
<

) *
T

* +
>

+ ,
next

- 1
)

1 2
{ 	
Next 
= 
next 
; 
} 	
public 
virtual 
async 
Task !
<! "
ValidationResult" 2
>2 3
Validate4 <
(< =
T= >
request? F
)F G
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
if 
( 
Next 
is 
not 
null  
)  !
{ 
await 
Next 
. 
Validate #
(# $
request$ +
)+ ,
;, -
} 
return 
validationResult #
;# $
} 	
} 
} Ù
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
} ˆ

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
public		 
EntityStatus		 
EntityStatus		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
=		7 8
EntityStatus		9 E
.		E F

Unmodified		F P
;		P Q
public 
DateTime 
? 
ModifiedDate %
{& '
get( +
;+ ,
private- 4
set5 8
;8 9
}: ;
public 
void 
UpdateModifiedDate &
(& '
)' (
{ 	
ModifiedDate 
= 
DateTime #
.# $
UtcNow$ *
;* +
} 	
	protected 
virtual 
void 
CheckValidity ,
(, -
)- .
{ 	
} 	
} 
} ª
Y/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/EntityStatus.cs
	namespace 	
AWC
 
. 
SharedKernel 
. 
Base 
{ 
public 

abstract 
class 
EntityStatus &
:' (
Enumeration) 4
<4 5
EntityStatus5 A
>A B
{ 
public 
static 
readonly 
EntityStatus +

Unmodified, 6
=7 8
new9 <
UnmodifiedStatus= M
(M N
)N O
;O P
public 
static 
readonly 
EntityStatus +
Added, 1
=2 3
new4 7
AddedStatus8 C
(C D
)D E
;E F
public 
static 
readonly 
EntityStatus +
Modified, 4
=5 6
new7 :
ModifiedStatus; I
(I J
)J K
;K L
public 
static 
readonly 
EntityStatus +
Deleted, 3
=4 5
new6 9
DeletedStatus: G
(G H
)H I
;I J
	protected

 
EntityStatus

 
(

 
int

 "
value

# (
,

( )
string

* 0
name

1 5
)

5 6
: 
base 
( 
value 
, 
name 
) 
{ 	
}
 
private 
sealed 
class 
UnmodifiedStatus -
:. /
EntityStatus0 <
{ 	
public 
UnmodifiedStatus #
(# $
)$ %
: 
base 
( 
$num 
, 
$str &
)& '
{ 
} 
} 	
private 
sealed 
class 
AddedStatus (
:) *
EntityStatus+ 7
{ 	
public 
AddedStatus 
( 
)  
: 
base 
( 
$num 
, 
$str !
)! "
{ 
} 
} 	
private 
sealed 
class 
ModifiedStatus +
:, -
EntityStatus. :
{ 	
public 
ModifiedStatus !
(! "
)" #
: 
base 
( 
$num 
, 
$str $
)$ %
{   
}   
}!! 	
private## 
sealed## 
class## 
DeletedStatus## *
:##+ ,
EntityStatus##- 9
{$$ 	
public%% 
DeletedStatus%%  
(%%  !
)%%! "
:&& 
base&& 
(&& 
$num&& 
,&& 
$str&& #
)&&# $
{'' 
}'' 
}(( 	
})) 
}** àF
X/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/Enumeration.cs
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
class 
Enumeration %
<% &
TEnum& +
>+ ,
:- .

IEquatable/ 9
<9 :
Enumeration: E
<E F
TEnumF K
>K L
>L M
where 
TEnum 
: 
Enumeration !
<! "
TEnum" '
>' (
{ 
private 
static 
readonly 
Lazy  $
<$ %

Dictionary% /
</ 0
int0 3
,3 4
TEnum5 :
>: ;
>; <"
EnumerationsDictionary= S
=T U
new		 
(		 
(		 
)		 
=>		 '
CreateEnumerationDictionary		 1
(		1 2
typeof		2 8
(		8 9
TEnum		9 >
)		> ?
)		? @
)		@ A
;		A B
	protected 
Enumeration 
( 
int !
id" $
,$ %
string& ,
name- 1
)1 2
: 
this 
( 
) 
{ 	
Id 
= 
id 
; 
Name 
= 
name 
; 
} 	
	protected 
Enumeration 
( 
) 
=>  "
Name# '
=( )
string* 0
.0 1
Empty1 6
;6 7
public 
int 
Id 
{ 
get 
; 
	protected &
init' +
;+ ,
}- .
public 
string 
Name 
{ 
get  
;  !
	protected" +
init, 0
;0 1
}2 3
=4 5
string6 <
.< =
Empty= B
;B C
public 
static 
bool 
operator #
==$ &
(& '
Enumeration' 2
<2 3
TEnum3 8
>8 9
?9 :
a; <
,< =
Enumeration> I
<I J
TEnumJ O
>O P
?P Q
bR S
)S T
{ 	
if 
( 
a 
is 
null 
&& 
b 
is !
null" &
)& '
{ 
return 
true 
; 
} 
if 
( 
a 
is 
null 
|| 
b 
is !
null" &
)& '
{   
return!! 
false!! 
;!! 
}"" 
return$$ 
a$$ 
.$$ 
Equals$$ 
($$ 
b$$ 
)$$ 
;$$ 
}%% 	
public'' 
static'' 
bool'' 
operator'' #
!=''$ &
(''& '
Enumeration''' 2
<''2 3
TEnum''3 8
>''8 9
a'': ;
,''; <
Enumeration''= H
<''H I
TEnum''I N
>''N O
b''P Q
)''Q R
=>''S U
!''V W
(''W X
a''X Y
==''Z \
b''] ^
)''^ _
;''_ `
public)) 
static)) 
IReadOnlyCollection)) )
<))) *
TEnum))* /
>))/ 0
	GetValues))1 :
()): ;
))); <
=>))= ?"
EnumerationsDictionary))@ V
.))V W
Value))W \
.))\ ]
Values))] c
.))c d
ToList))d j
())j k
)))k l
;))l m
public++ 
static++ 
TEnum++ 
?++ 
FromId++ #
(++# $
int++$ '
id++( *
)++* +
=>++, ."
EnumerationsDictionary++/ E
.++E F
Value++F K
.++K L
TryGetValue++L W
(++W X
id++X Z
,++Z [
out++\ _
TEnum++` e
?++e f
enumeration++g r
)++r s
?++t u
enumeration	++v Å
:
++Ç É
null
++Ñ à
;
++à â
public-- 
static-- 
TEnum-- 
?-- 
FromName-- %
(--% &
string--& ,
name--- 1
)--1 2
=>--3 5"
EnumerationsDictionary--6 L
.--L M
Value--M R
.--R S
Values--S Y
.--Y Z
SingleOrDefault--Z i
(--i j
x--j k
=>--l n
x--o p
.--p q
Name--q u
==--v x
name--y }
)--} ~
;--~ 
public// 
static// 
bool// 
Contains// #
(//# $
int//$ '
id//( *
)//* +
=>//, ."
EnumerationsDictionary/// E
.//E F
Value//F K
.//K L
ContainsKey//L W
(//W X
id//X Z
)//Z [
;//[ \
public22 
virtual22 
bool22 
Equals22 "
(22" #
Enumeration22# .
<22. /
TEnum22/ 4
>224 5
?225 6
other227 <
)22< =
{33 	
if44 
(44 
other44 
is44 
null44 
)44 
{55 
return66 
false66 
;66 
}77 
return99 
GetType99 
(99 
)99 
==99 
other99  %
.99% &
GetType99& -
(99- .
)99. /
&&990 2
other993 8
.998 9
Id999 ;
.99; <
Equals99< B
(99B C
Id99C E
)99E F
;99F G
}:: 	
public== 
override== 
bool== 
Equals== #
(==# $
object==$ *
?==* +
obj==, /
)==/ 0
{>> 	
if?? 
(?? 
obj?? 
is?? 
null?? 
)?? 
{@@ 
returnAA 
falseAA 
;AA 
}BB 
ifDD 
(DD 
GetTypeDD 
(DD 
)DD 
!=DD 
objDD  
.DD  !
GetTypeDD! (
(DD( )
)DD) *
)DD* +
{EE 
returnFF 
falseFF 
;FF 
}GG 
returnII 
objII 
isII 
EnumerationII %
<II% &
TEnumII& +
>II+ ,

otherValueII- 7
&&II8 :

otherValueII; E
.IIE F
IdIIF H
.IIH I
EqualsIII O
(IIO P
IdIIP R
)IIR S
;IIS T
}JJ 	
publicMM 
overrideMM 
intMM 
GetHashCodeMM '
(MM' (
)MM( )
=>MM* ,
IdMM- /
.MM/ 0
GetHashCodeMM0 ;
(MM; <
)MM< =
*MM> ?
$numMM@ B
;MMB C
privateOO 
staticOO 

DictionaryOO !
<OO! "
intOO" %
,OO% &
TEnumOO' ,
>OO, -'
CreateEnumerationDictionaryOO. I
(OOI J
TypeOOJ N
enumTypeOOO W
)OOW X
=>OOY [
GetFieldsForTypeOO\ l
(OOl m
enumTypeOOm u
)OOu v
.OOv w
ToDictionary	OOw É
(
OOÉ Ñ
t
OOÑ Ö
=>
OOÜ à
t
OOâ ä
.
OOä ã
Id
OOã ç
)
OOç é
;
OOé è
privateQQ 
staticQQ 
IEnumerableQQ "
<QQ" #
TEnumQQ# (
>QQ( )
GetFieldsForTypeQQ* :
(QQ: ;
TypeQQ; ?
enumTypeQQ@ H
)QQH I
=>QQJ L
enumTypeRR 
.RR 
	GetFieldsRR 
(RR 
BindingFlagsRR +
.RR+ ,
PublicRR, 2
|RR3 4
BindingFlagsRR5 A
.RRA B
StaticRRB H
|RRI J
BindingFlagsRRK W
.RRW X
FlattenHierarchyRRX h
)RRh i
.SS 
WhereSS 
(SS 
	fieldInfoSS  
=>SS! #
enumTypeSS$ ,
.SS, -
IsAssignableFromSS- =
(SS= >
	fieldInfoSS> G
.SSG H
	FieldTypeSSH Q
)SSQ R
)SSR S
.TT 
SelectTT 
(TT 
	fieldInfoTT !
=>TT" $
(TT% &
TEnumTT& +
)TT+ ,
	fieldInfoTT, 5
.TT5 6
GetValueTT6 >
(TT> ?
defaultTT? F
)TTF G
!TTG H
)TTH I
;TTI J
}UU 
}VV Ê
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
} Ê
X/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Base/ValueObject.cs
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
class 
ValueObject %
:& '

IEquatable( 2
<2 3
ValueObject3 >
>> ?
{ 
public 
abstract 
IEnumerable #
<# $
object$ *
>* +
GetAtomicValues, ;
(; <
)< =
;= >
public		 
bool		 
Equals		 
(		 
ValueObject		 &
?		& '
other		( -
)		- .
{

 	
return 
other 
is 
not 
null  $
&&% '
ValuesAreEqual( 6
(6 7
other7 <
)< =
;= >
} 	
public 
override 
bool 
Equals #
(# $
object$ *
?* +
obj, /
)/ 0
{ 	
return 
obj 
is 
ValueObject %
other& +
&&, .
ValuesAreEqual/ =
(= >
other> C
)C D
;D E
} 	
public 
override 
int 
GetHashCode '
(' (
)( )
{ 	
return 
GetAtomicValues "
(" #
)# $
. 
	Aggregate 
( 
default 
( 
int 
)  
,  !
HashCode 
. 
Combine $
)$ %
;% &
} 	
private 
bool 
ValuesAreEqual #
(# $
ValueObject$ /
other0 5
)5 6
{ 	
return 
GetAtomicValues "
(" #
)# $
.$ %
SequenceEqual% 2
(2 3
other3 8
.8 9
GetAtomicValues9 H
(H I
)I J
)J K
;K L
} 	
} 
}   °	
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
DefaultDateOnly .
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
} µ
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
} 	
public 
static 
object 
Null !
( 	
this 
IGuardClause 
guardClause )
,) *
object 
input 
, 
string 
? 
message 
= 
null "
," #
[ $
CallerArgumentExpression %
(% &
$str& -
)- .
]. /
string0 6
?6 7
parameterName8 E
=F G
nullH L
) 	
{ 	
if 
( 
input 
is 
null 
) 
{ 
Error   
(   
message   
??    
$"  ! #
$str  # 3
{  3 4
parameterName  4 A
}  A B
$str  B O
"  O P
)  P Q
;  Q R
}!! 
return"" 
input"" 
!"" 
;"" 
}## 	
}$$ 
}%% Ÿ.
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
$str3 J
{J K
minValueK S
}S T
$strT U
"U V
)V W
;W X
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
$str""3 J
{""J K
minValue""K S
}""S T
$str""T U
"""U V
)""V W
;""W X
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
maxValue++ 
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
>00 
maxValue00  
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
$str223 G
{22G H
maxValue22H P
}22P Q
$str22Q R
"22R S
)22S T
;22T U
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
,:: 
decimal;; 
maxValue;; 
,;; 
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
>@@ 
maxValue@@  
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
$strBB3 G
{BBG H
maxValueBBH P
}BBP Q
$strBBQ R
"BBR S
)BBS T
;BBT U
}CC 
returnDD 
inputDD 
;DD 
}EE 	
publicGG 
staticGG 
decimalGG '
GreaterThanTwoDecimalPlacesGG 9
(HH 	
thisII 
IGuardClauseII 
guardClauseII )
,II) *
decimalJJ 
inputJJ 
,JJ 
stringKK 
messageKK 
=KK 
nullKK !
!KK! "
,KK" #
[LL $
CallerArgumentExpressionLL %
(LL% &
$strLL& -
)LL- .
]LL. /
stringLL0 6
?LL6 7
parameterNameLL8 E
=LLF G
nullLLH L
)MM 	
{NN 	
ifOO 
(OO 
inputOO 
%OO 
$numOO 
!=OO  
$numOO! "
)OO" #
{PP 
ErrorQQ 
(QQ 
messageQQ 
??QQ  
$"QQ! #
$strQQ# $
{QQ$ %
parameterNameQQ% 2
}QQ2 3
$strQQ3 V
"QQV W
)QQW X
;QQX Y
}RR 
returnSS 
inputSS 
;SS 
}TT 	
}UU 
}VV ¡
h/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Guards/GuardAgainstUrlExtensions.cs
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
string 

InvalidUrl '
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
string 
message 
= 
null !
!! "
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
{ 	
try 
{ 
_ 
= 
new 
Uri 
( 
input !
)! "
;" #
} 
catch 
{ 
Error 
( 
message 
??  
$"! #
{# $
parameterName$ 1
}1 2
$str2 F
"F G
)G H
;H I
} 
return 
input 
; 
} 	
} 
} π
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
} ≠
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
new 
( 
value 
, 
true 
, 
Error "
." #
None# '
)' (
;( )
public   
static   
Result   
Failure   $
(  $ %
Error  % *
error  + 0
)  0 1
=>  2 4
new!! 
(!! 
false!! 
,!! 
error!! 
)!! 
;!! 
public## 
static## 
Result## 
<## 
TValue## #
>### $
Failure##% ,
<##, -
TValue##- 3
>##3 4
(##4 5
Error##5 :
error##; @
)##@ A
=>##B D
new$$ 
($$ 
default$$ 
,$$ 
false$$ 
,$$ 
error$$  %
)$$% &
;$$& '
public&& 
static&& 
Result&& 
<&& 
TValue&& #
>&&# $
Create&&% +
<&&+ ,
TValue&&, 2
>&&2 3
(&&3 4
TValue&&4 :
?&&: ;
value&&< A
)&&A B
=>&&C E
value'' 
is'' 
not'' 
null'' 
?'' 
Success''  '
(''' (
value''( -
)''- .
:''/ 0
Failure''1 8
<''8 9
TValue''9 ?
>''? @
(''@ A
Error''A F
.''F G
	NullValue''G P
)''P Q
;''Q R
}(( 
})) Ω
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/ResultExtensions.cs
	namespace 	
SharedKernel
 
. 
	Utilities  
{ 
public 

static 
class 
ResultExtensions (
{ 
public 
static 
Result 
< 
T 
> 
Ensure  &
<& '
T' (
>( )
( 	
this		 
Result		 
<		 
T		 
>		 
result		 !
,		! "
Func

 
<

 
T

 
,

 
bool

 
>

 
	predicate

 #
,

# $
Error 
error 
) 	
{ 	
if 
( 
result 
. 
	IsFailure  
)  !
return 
result 
; 
return 
	predicate 
( 
result #
.# $
Value$ )
)) *
?+ ,
result- 3
:4 5
Result6 <
.< =
Failure= D
<D E
TE F
>F G
(G H
errorH M
)M N
;N O
} 	
public 
static 
Result 
< 
TOut !
>! "
Map# &
<& '
TIn' *
,* +
TOut, 0
>0 1
(1 2
this 
Result 
< 
TIn 
> 
result #
,# $
Func 
< 
TIn 
, 
TOut 
> 
mappingFunc '
)' (
{ 	
return 
result 
. 
	IsSuccess #
?$ %
Result 
. 
Success 
( 
mappingFunc *
(* +
result+ 1
.1 2
Value2 7
)7 8
)8 9
:: ;
Result 
. 
Failure 
< 
TOut #
># $
($ %
result% +
.+ ,
Error, 1
)1 2
;2 3
} 	
} 
} ◊
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
} à
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/SharedKernel/Utilities/ValidationResult.cs
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
} 