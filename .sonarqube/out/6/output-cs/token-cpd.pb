≠
Z/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/ApplicationAssembly.cs
	namespace 	
AWC
 
. 
Application 
; 
public 
static 
class 
ApplicationAssembly '
{ 
public 

static 
readonly 
Assembly #
Instance$ ,
=- .
typeof/ 5
(5 6
ApplicationAssembly6 I
)I J
.J K
AssemblyK S
;S T
} Œ
p/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Behaviors/BusinessRulesValidationBehavior.cs
	namespace 	
AWC
 
. 
Application 
. 
	Behaviors #
{ 
public		 

sealed		 
class		 +
BusinessRulesValidationBehavior		 7
<		7 8
TRequest		8 @
,		@ A
	TResponse		B K
>		K L
:		M N
IPipelineBehavior		O `
<		` a
TRequest		a i
,		i j
	TResponse		k t
>		t u
where

 
TRequest

 
:

 
ICommand

 !
<

! "
int

" %
>

% &
,

& '
IRequest

( 0
<

0 1
	TResponse

1 :
>

: ;
where 
	TResponse 
: 
Result  
{ 
private 
readonly 
CommandValidator )
<) *
TRequest* 2
>2 3#
_businessRulesValidator4 K
;K L
public +
BusinessRulesValidationBehavior .
(. /
CommandValidator/ ?
<? @
TRequest@ H
>H I
rulesValidatorJ X
)X Y
=> #
_businessRulesValidator &
=' (
rulesValidator) 7
;7 8
public 
async 
Task 
< 
	TResponse #
># $
Handle% +
( 	
TRequest 
request 
, 
CancellationToken 
cancellationToken /
,/ 0"
RequestHandlerDelegate "
<" #
	TResponse# ,
>, -
next. 2
) 	
{ 	
Result 
result 
= 
await !#
_businessRulesValidator" 9
.9 :
Validate: B
(B C
requestC J
)J K
;K L
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
return 
await 
next !
(! "
)" #
;# $
} 
else 
{   
var!! 
retVal!! 
=!! 
Result!! #
<!!# $
int!!$ '
>!!' (
.!!( )
Failure!!) 0
<!!0 1
int!!1 4
>!!4 5
(!!5 6
new!!6 9
Error!!: ?
(!!? @
$str!!@ h
,!!h i
result!!j p
.!!p q
Error!!q v
.!!v w
Message!!w ~
)!!~ 
)	!! Ä
;
!!Ä Å
return"" 
("" 
retVal"" 
)"" 
as""  "
	TResponse""# ,
;"", -
}## 
}$$ 	
}%% 
}&& ≈!
i/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Behaviors/FluentValidationBehavior.cs
	namespace 	
AWC
 
. 
Application 
. 
	Behaviors #
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
FluentValidationBehavior

 0
<

0 1
TRequest

1 9
,

9 :
	TResponse

; D
>

D E
:

F G
IPipelineBehavior

H Y
<

Y Z
TRequest

Z b
,

b c
	TResponse

d m
>

m n
where 
TRequest 
: 
IRequest !
<! "
	TResponse" +
>+ ,
where 
	TResponse 
: 
Result  
{ 
private 
readonly 
IEnumerable $
<$ %

IValidator% /
</ 0
TRequest0 8
>8 9
>9 :
_validators; F
;F G
public $
FluentValidationBehavior '
(' (
IEnumerable( 3
<3 4

IValidator4 >
<> ?
TRequest? G
>G H
>H I

validatorsJ T
)T U
=> 
_validators 
= 

validators '
;' (
public 
async 
Task 
< 
	TResponse #
># $
Handle% +
( 	
TRequest 
request 
, 
CancellationToken 
cancellationToken /
,/ 0"
RequestHandlerDelegate "
<" #
	TResponse# ,
>, -
next. 2
) 	
{ 	
if 
( 
_validators 
. 
Any 
(  
)  !
)! "
{ 
var 
context 
= 
new !
ValidationContext" 3
<3 4
TRequest4 <
>< =
(= >
request> E
)E F
;F G
var 
validationResults %
=& '
await( -
Task. 2
.2 3
WhenAll3 :
(: ;
_validators; F
.F G
SelectG M
(M N
vN O
=>P R
vS T
.T U
ValidateAsyncU b
(b c
contextc j
,j k
cancellationTokenl }
)} ~
)~ 
)	 Ä
;
Ä Å
var 
failures 
= 
validationResults 0
.0 1

SelectMany1 ;
(; <
r< =
=>> @
rA B
.B C
ErrorsC I
)I J
.0 1
Where1 6
(6 7
f7 8
=>9 ;
f< =
!=> @
nullA E
)E F
.  0 1
ToList  1 7
(  7 8
)  8 9
;  9 :
if"" 
("" 
failures"" 
."" 
Count"" "
!=""# %
$num""& '
)""' (
{## 
StringBuilder$$ !
sb$$" $
=$$% &
new$$' *
($$* +
)$$+ ,
;$$, -
failures%% 
.%% 
ToList%% #
(%%# $
)%%$ %
.%%% &
ForEach%%& -
(%%- .
err%%. 1
=>%%2 4
sb%%5 7
.%%7 8

AppendLine%%8 B
(%%B C
err%%C F
.%%F G
ErrorMessage%%G S
)%%S T
)%%T U
;%%U V
return'' 
('' 
Result'' "
<''" #
int''# &
>''& '
.''' (
Failure''( /
<''/ 0
int''0 3
>''3 4
(''4 5
new''5 8
Error''9 >
(''> ?
$str''? `
,''` a
sb''b d
.''d e
ToString''e m
(''m n
)''n o
)''o p
)''p q
)''q r
as''s u
	TResponse''v 
;	'' Ä
}(( 
})) 
return++ 
await++ 
next++ 
(++ 
)++ 
;++  
},, 	
}-- 
}.. à
`/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Behaviors/LoggingBehavior.cs
	namespace 	
AWC
 
. 
Application 
. 
	Behaviors #
{ 
public		 

sealed		 
class		 
LoggingBehavior		 '
<		' (
TRequest		( 0
,		0 1
	TResponse		2 ;
>		; <
:		= >
IPipelineBehavior		? P
<		P Q
TRequest		Q Y
,		Y Z
	TResponse		[ d
>		d e
where

 
TRequest

 
:

 
IRequest

 !
<

! "
	TResponse

" +
>

+ ,
where 
	TResponse 
: 
Result  
{ 
private 
readonly 
ILogger  
<  !
LoggingBehavior! 0
<0 1
TRequest1 9
,9 :
	TResponse; D
>D E
>E F
_loggerG N
;N O
public 
LoggingBehavior 
( 
ILogger &
<& '
LoggingBehavior' 6
<6 7
TRequest7 ?
,? @
	TResponseA J
>J K
>K L
loggerM S
)S T
=> 
_logger 
= 
logger 
;  
public 
async 
Task 
< 
	TResponse #
># $
Handle% +
( 	
TRequest 
request 
, 
CancellationToken 
cancellationToken /
,/ 0"
RequestHandlerDelegate "
<" #
	TResponse# ,
>, -
next. 2
) 	
{ 	
_logger 
. 
LogInformation "
(" #
$str A
,A B
typeof 
( 
TRequest 
)  
.  !
Name! %
,% &
DateTime 
. 
UtcNow 
)  
;  !
var 
result 
= 
await 
next #
(# $
)$ %
;% &
if   
(   
result   
.   
	IsFailure    
)    !
{!! 
_logger"" 
."" 
LogError""  
(""  !
$str## N
,##N O
typeof$$ 
($$ 
TRequest$$ #
)$$# $
.$$$ %
Name$$% )
,$$) *
result%% 
.%% 
Error%%  
.%%  !
Message%%! (
,%%( )
DateTime&& 
.&& 
UtcNow&& #
)&&# $
;&&$ %
}'' 
_logger)) 
.)) 
LogInformation)) "
())" #
$str** B
,**B C
typeof++ 
(++ 
TRequest++ 
)++  
.++  !
Name++! %
,++% &
DateTime,, 
.,, 
UtcNow,, 
),,  
;,,  !
return.. 
result.. 
;.. 
}// 	
}00 
}11 …
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/CreateEmployeeDepartmentMustExist.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class -
!CreateEmployeeDepartmentMustExist 9
:: ;
BusinessRule< H
<H I!
CreateEmployeeCommandI ^
>^ _
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public -
!CreateEmployeeDepartmentMustExist 0
(0 1(
IValidationRepositoryManager1 M
repoN R
)R S
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
CreateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
var 

department 
= 
employee %
.% &
DepartmentHistories& 9
!9 :
.: ;
FirstOrDefault; I
(I J
)J K
;K L
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >#
ValidateDepartmentExist> U
(U V
(V W
shortW \
)\ ]

department] g
!g h
.h i
DepartmentIDi u
)u v
;v w
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else   
{!! 
validationResult""  
.""  !
Messages""! )
."") *
Add""* -
(""- .
result"". 4
.""4 5
Error""5 :
."": ;
Message""; B
)""B C
;""C D
}## 
return%% 
validationResult%% #
;%%# $
}&& 	
}'' 
}(( ˚
É/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/CreateEmployeeEmailMustBeUnique.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class +
CreateEmployeeEmailMustBeUnique 7
:8 9
BusinessRule: F
<F G!
CreateEmployeeCommandG \
>\ ]
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public +
CreateEmployeeEmailMustBeUnique .
(. /(
IValidationRepositoryManager/ K
repoL P
)P Q
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
CreateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >)
ValidateEmployeeEmailIsUnique> [
([ \
employee\ d
.d e
BusinessEntityIDe u
,u v
employeew 
.	 Ä
EmailAddress
Ä å
)
å ç
;
ç é
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else 
{   
validationResult!!  
.!!  !
Messages!!! )
.!!) *
Add!!* -
(!!- .
result!!. 4
.!!4 5
Error!!5 :
.!!: ;
Message!!; B
)!!B C
;!!C D
}"" 
return$$ 
validationResult$$ #
;$$# $
}%% 	
}&& 
}'' ì
Ç/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/CreateEmployeeManagerMustExist.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class *
CreateEmployeeManagerMustExist 6
:7 8
BusinessRule9 E
<E F!
CreateEmployeeCommandF [
>[ \
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public *
CreateEmployeeManagerMustExist -
(- .(
IValidationRepositoryManager. J
repoK O
)O P
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
CreateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= > 
ValidateManagerExist> R
(R S
employeeS [
.[ \
	ManagerID\ e
)e f
;f g
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else 
{   
validationResult!!  
.!!  !
Messages!!! )
.!!) *
Add!!* -
(!!- .
result!!. 4
.!!4 5
Error!!5 :
.!!: ;
Message!!; B
)!!B C
;!!C D
}"" 
return$$ 
validationResult$$ #
;$$# $
}%% 	
}&& 
}'' ¯
Ç/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/CreateEmployeeNameMustBeUnique.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class *
CreateEmployeeNameMustBeUnique 6
:7 8
BusinessRule9 E
<E F!
CreateEmployeeCommandF [
>[ \
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public *
CreateEmployeeNameMustBeUnique -
(- .(
IValidationRepositoryManager. J
repoK O
)O P
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
CreateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >&
ValidatePersonNameIsUnique> X
(X Y
employeeY a
.a b
BusinessEntityIDb r
,r s
employeet |
.| }
	FirstName	} Ü
,
Ü á
employee
à ê
.
ê ë
LastName
ë ô
,
ô ö
employee
õ £
.
£ §

MiddleName
§ Æ
)
Æ Ø
;
Ø ∞
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
else 
{ 
validationResult  
.  !
Messages! )
.) *
Add* -
(- .
result. 4
.4 5
Error5 :
.: ;
Message; B
)B C
;C D
}   
return"" 
validationResult"" #
;""# $
}## 	
}$$ 
}%% •
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/CreateEmployeeNationalIdNumberMustBeUnique.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class 6
*CreateEmployeeNationalIdNumberMustBeUnique B
:C D
BusinessRuleE Q
<Q R!
CreateEmployeeCommandR g
>g h
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public 6
*CreateEmployeeNationalIdNumberMustBeUnique 9
(9 :(
IValidationRepositoryManager: V
repoW [
)[ \
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
CreateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >,
 ValidateNationalIdNumberIsUnique> ^
(^ _
employee_ g
.g h
BusinessEntityIDh x
,x y
employee	z Ç
.
Ç É
NationalIDNumber
É ì
)
ì î
;
î ï
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else 
{   
validationResult!!  
.!!  !
Messages!!! )
.!!) *
Add!!* -
(!!- .
result!!. 4
.!!4 5
Error!!5 :
.!!: ;
Message!!; B
)!!B C
;!!C D
}"" 
return$$ 
validationResult$$ #
;$$# $
}%% 	
}&& 
}'' Ø
Ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/CreateEmployeeShiftMustExist.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class (
CreateEmployeeShiftMustExist 4
:5 6
BusinessRule7 C
<C D!
CreateEmployeeCommandD Y
>Y Z
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public (
CreateEmployeeShiftMustExist +
(+ ,(
IValidationRepositoryManager, H
repoI M
)M N
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
CreateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
var 

department 
= 
employee %
.% &
DepartmentHistories& 9
!9 :
.: ;
FirstOrDefault; I
(I J
)J K
;K L
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >
ValidateShiftExist> P
(P Q
(Q R
byteR V
)V W

departmentW a
!a b
.b c
ShiftIDc j
)j k
;k l
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else   
{!! 
validationResult""  
.""  !
Messages""! )
."") *
Add""* -
(""- .
result"". 4
.""4 5
Error""5 :
."": ;
Message""; B
)""B C
;""C D
}## 
return%% 
validationResult%% #
;%%# $
}&& 	
}'' 
}(( µ
{/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/DeleteEmployeeMustExist.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class #
DeleteEmployeeMustExist /
:0 1
BusinessRule2 >
<> ?!
DeleteEmployeeCommand? T
>T U
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public #
DeleteEmployeeMustExist &
(& '(
IValidationRepositoryManager' C
repoD H
)H I
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
DeleteEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >!
ValidateEmployeeExist> S
(S T
employeeT \
.\ ]
BusinessEntityID] m
)m n
;n o
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
else 
{ 
validationResult $
.$ %
IsValid% ,
=- .
true/ 3
;3 4
} 
}   
else!! 
{"" 
validationResult##  
.##  !
Messages##! )
.##) *
Add##* -
(##- .
result##. 4
.##4 5
Error##5 :
.##: ;
Message##; B
)##B C
;##C D
}$$ 
return&& 
validationResult&& #
;&&# $
}'' 	
}(( 
})) Ö
{/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/UpdateEmployeeMustExist.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class #
UpdateEmployeeMustExist /
:0 1
BusinessRule2 >
<> ?!
UpdateEmployeeCommand? T
>T U
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public #
UpdateEmployeeMustExist &
(& '(
IValidationRepositoryManager' C
repoD H
)H I
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
UpdateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >!
ValidateEmployeeExist> S
(S T
employeeT \
.\ ]
BusinessEntityID] m
)m n
;n o
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else 
{   
validationResult!!  
.!!  !
Messages!!! )
.!!) *
Add!!* -
(!!- .
result!!. 4
.!!4 5
Error!!5 :
.!!: ;
Message!!; B
)!!B C
;!!C D
}"" 
return$$ 
validationResult$$ #
;$$# $
}%% 	
}&& 
}'' ¯
Ç/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/UpdateEmployeeNameMustBeUnique.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class *
UpdateEmployeeNameMustBeUnique 6
:7 8
BusinessRule9 E
<E F!
UpdateEmployeeCommandF [
>[ \
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public *
UpdateEmployeeNameMustBeUnique -
(- .(
IValidationRepositoryManager. J
repoK O
)O P
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
UpdateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >&
ValidatePersonNameIsUnique> X
(X Y
employeeY a
.a b
BusinessEntityIDb r
,r s
employeet |
.| }
	FirstName	} Ü
,
Ü á
employee
à ê
.
ê ë
LastName
ë ô
,
ô ö
employee
õ £
.
£ §

MiddleName
§ Æ
)
Æ Ø
;
Ø ∞
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
else 
{ 
validationResult  
.  !
Messages! )
.) *
Add* -
(- .
result. 4
.4 5
Error5 :
.: ;
Message; B
)B C
;C D
}   
return"" 
validationResult"" #
;""# $
}## 	
}$$ 
}%% •
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/BusinessRules/HumanResources/UpdateEmployeeNationalIdNumberMustBeUnique.cs
	namespace 	
AWC
 
. 
Application 
. 
BusinessRules '
.' (
HumanResources( 6
{ 
public 

sealed 
class 6
*UpdateEmployeeNationalIdNumberMustBeUnique B
:C D
BusinessRuleE Q
<Q R!
UpdateEmployeeCommandR g
>g h
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repository

6 A
;

A B
public 6
*UpdateEmployeeNationalIdNumberMustBeUnique 9
(9 :(
IValidationRepositoryManager: V
repoW [
)[ \
=> 
_repository 
= 
repo !
;! "
public 
override 
async 
Task "
<" #
ValidationResult# 3
>3 4
Validate5 =
(= >!
UpdateEmployeeCommand> S
employeeT \
)\ ]
{ 	
ValidationResult 
validationResult -
=. /
new0 3
(3 4
)4 5
;5 6
Result 
result 
= 
await 
_repository !
.! "'
EmployeeAggregateRepository" =
.= >,
 ValidateNationalIdNumberIsUnique> ^
(^ _
employee_ g
.g h
BusinessEntityIDh x
,x y
employee	z Ç
.
Ç É
NationalIDNumber
É ì
)
ì î
;
î ï
if 
( 
result 
. 
	IsSuccess  
)  !
{ 
validationResult  
.  !
IsValid! (
=) *
true+ /
;/ 0
if 
( 
Next 
is 
not 
null  $
)$ %
{ 
validationResult $
=% &
await' ,
Next- 1
.1 2
Validate2 :
(: ;
employee; C
)C D
;D E
} 
} 
else 
{   
validationResult!!  
.!!  !
Messages!!! )
.!!) *
Add!!* -
(!!- .
result!!. 4
.!!4 5
Error!!5 :
.!!: ;
Message!!; B
)!!B C
;!!C D
}"" 
return$$ 
validationResult$$ #
;$$# $
}%% 	
}&& 
}'' Ÿ§
/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/Common/BuildEmployeeDomainObject.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
Common2 8
{ 
public 

static 
class %
BuildEmployeeDomainObject 1
{ 
public 
static 
Result 
< 
Employee %
>% &
Build' ,
(, -!
CreateEmployeeCommand- B
commandC J
,J K
IMapperL S
mapperT Z
)Z [
{ 	"
EmployeeGenericCommand "
genericCommand# 1
=2 3
mapper4 :
.: ;
Map; >
<> ?"
EmployeeGenericCommand? U
>U V
(V W
commandW ^
)^ _
;_ `
return 
BuildEmployee  
(  !
genericCommand! /
)/ 0
;0 1
} 	
public 
static 
Result 
< 
Employee %
>% &
Build' ,
(, -!
UpdateEmployeeCommand- B
commandC J
,J K
IMapperL S
mapperT Z
)Z [
{ 	"
EmployeeGenericCommand "
genericCommand# 1
=2 3
mapper4 :
.: ;
Map; >
<> ?"
EmployeeGenericCommand? U
>U V
(V W
commandW ^
)^ _
;_ `
return 
BuildEmployee  
(  !
genericCommand! /
)/ 0
;0 1
} 	
private 
static 
Result 
< 
Employee &
>& '
BuildEmployee( 5
(5 6"
EmployeeGenericCommand6 L
commandM T
)T U
{ 	
Result 
< 
Employee 
> 
aggregateRootResult 0
=1 2
BuildAggregateRoot3 E
(E F
commandF M
)M N
;N O
if!! 
(!! 
aggregateRootResult!! #
.!!# $
	IsFailure!!$ -
)!!- .
return"" 
Result"" 
<"" 
Employee"" &
>""& '
.""' (
Failure""( /
<""/ 0
Employee""0 8
>""8 9
(""9 :
new"": =
Error""> C
(""C D
$str""D m
,""m n 
aggregateRootResult	""o Ç
.
""Ç É
Error
""É à
.
""à â
Message
""â ê
)
""ê ë
)
""ë í
;
""í ì
Employee%% 
employee%% 
=%% 
aggregateRootResult%%  3
.%%3 4
Value%%4 9
;%%9 :
Result(( 
entitiesResult(( !
=((" #"
BuildAggregateEntities(($ :
(((: ;
command((; B
,((B C
ref((D G
employee((H P
)((P Q
;((Q R
if)) 
()) 
entitiesResult)) 
.)) 
	IsFailure)) (
)))( )
return** 
Result** 
<** 
Employee** &
>**& '
.**' (
Failure**( /
<**/ 0
Employee**0 8
>**8 9
(**9 :
new**: =
Error**> C
(**C D
$str**D m
,**m n
entitiesResult**o }
.**} ~
Error	**~ É
.
**É Ñ
Message
**Ñ ã
)
**ã å
)
**å ç
;
**ç é
return,, 
employee,, 
;,, 
}-- 	
private// 
static// 
Result// 
<// 
Employee// &
>//& '
BuildAggregateRoot//( :
(//: ;"
EmployeeGenericCommand//; Q
command//R Y
)//Y Z
{00 	
Result22 
<22 
Employee22 
>22 
employeeResult22 +
=22, -
Employee22. 6
.226 7
Create227 =
(33 
new44 

EmployeeID44 
(44 
command44 &
.44& '
BusinessEntityID44' 7
)447 8
,448 9
$str55 
,55 
(66 
	NameStyle66 
)66 
command66 "
.66" #
	NameStyle66# ,
,66, -
command77 
.77 
Title77 
,77 
command88 
.88 
	FirstName88 !
!88! "
,88" #
command99 
.99 
LastName99  
!99  !
,99! "
command:: 
.:: 

MiddleName:: "
!::" #
,::# $
command;; 
.;; 
Suffix;; 
,;; 
new<< 

EmployeeID<< 
(<< 
command<< &
.<<& '
	ManagerID<<' 0
)<<0 1
,<<1 2
command== 
.== 
NationalIDNumber== (
!==( )
,==) *
command>> 
.>> 
LoginID>> 
!>>  
,>>  !
command?? 
.?? 
JobTitle??  
!??  !
,??! "
DateOnly@@ 
.@@ 
FromDateTime@@ %
(@@% &
command@@& -
.@@- .
	BirthDate@@. 7
)@@7 8
,@@8 9
commandAA 
.AA 
MaritalStatusAA %
!AA% &
,AA& '
commandBB 
.BB 
GenderBB 
!BB 
,BB  
DateOnlyCC 
.CC 
FromDateTimeCC %
(CC% &
commandCC& -
.CC- .
HireDateCC. 6
)CC6 7
,CC7 8
commandDD 
.DD 
SalariedDD  
,DD  !
commandEE 
.EE 
VacationHoursEE %
,EE% &
commandFF 
.FF 
SickLeaveHoursFF &
,FF& '
commandGG 
.GG 
ActiveGG 
)HH 
;HH 
ifJJ 
(JJ 
employeeResultJJ 
.JJ 
	IsFailureJJ (
)JJ( )
returnKK 
ResultKK 
<KK 
EmployeeKK &
>KK& '
.KK' (
FailureKK( /
<KK/ 0
EmployeeKK0 8
>KK8 9
(KK9 :
newKK: =
ErrorKK> C
(KKC D
$strKKD r
,KKr s
employeeResult	KKt Ç
.
KKÇ É
Error
KKÉ à
.
KKà â
Message
KKâ ê
)
KKê ë
)
KKë í
;
KKí ì
EmployeeMM 
employeeMM 
=MM 
employeeResultMM  .
.MM. /
ValueMM/ 4
;MM4 5
ifPP 
(PP 
commandPP 
.PP 
PayHistoriesPP $
!PP$ %
.PP% &
AnyPP& )
(PP) *
)PP* +
)PP+ ,
{QQ 
ResultRR 
payHistoryResultRR '
=RR( )
AddPayHistoriesRR* 9
(RR9 :
refRR: =
employeeRR> F
,RRF G
commandRRH O
.RRO P
PayHistoriesRRP \
!RR\ ]
)RR] ^
;RR^ _
ifSS 
(SS 
payHistoryResultSS $
.SS$ %
	IsFailureSS% .
)SS. /
returnTT 
ResultTT !
<TT! "
EmployeeTT" *
>TT* +
.TT+ ,
FailureTT, 3
<TT3 4
EmployeeTT4 <
>TT< =
(TT= >
newTT> A
ErrorTTB G
(TTG H
$strTTH x
,TTx y
payHistoryResult	TTz ä
.
TTä ã
Error
TTã ê
.
TTê ë
Message
TTë ò
)
TTò ô
)
TTô ö
;
TTö õ
}UU 
ifXX 
(XX 
commandXX 
.XX 
DepartmentHistoriesXX +
!XX+ ,
.XX, -
AnyXX- 0
(XX0 1
)XX1 2
)XX2 3
{YY 
ResultZZ #
departmentHistoryResultZZ .
=ZZ/ 0"
AddDepartmentHistoriesZZ1 G
(ZZG H
refZZH K
employeeZZL T
,ZZT U
commandZZV ]
.ZZ] ^
DepartmentHistoriesZZ^ q
!ZZq r
)ZZr s
;ZZs t
if[[ 
([[ #
departmentHistoryResult[[ +
.[[+ ,
	IsFailure[[, 5
)[[5 6
return\\ 
Result\\ !
<\\! "
Employee\\" *
>\\* +
.\\+ ,
Failure\\, 3
<\\3 4
Employee\\4 <
>\\< =
(\\= >
new\\> A
Error\\B G
(\\G H
$str\\H x
,\\x y$
departmentHistoryResult	\\z ë
.
\\ë í
Error
\\í ó
.
\\ó ò
Message
\\ò ü
)
\\ü †
)
\\† °
;
\\° ¢
}]] 
return`` 
employeeResult`` !
.``! "
Value``" '
;``' (
}aa 	
privatecc 
staticcc 
Resultcc "
BuildAggregateEntitiescc 4
(cc4 5"
EmployeeGenericCommandcc5 K
commandccL S
,ccS T
refccU X
EmployeeccY a
employeeccb j
)ccj k
{dd 	
Resultff 
addressResultff  
=ff! "

AddAddressff# -
(ff- .
refgg 
employeegg 
,gg 
$numhh 
,hh 
commandii 
.ii 
AddressLine1ii $
!ii$ %
,ii% &
commandjj 
.jj 
AddressLine2jj $
,jj$ %
commandkk 
.kk 
Citykk 
!kk 
,kk 
commandll 
.ll 
StateProvinceIDll '
,ll' (
commandmm 
.mm 

PostalCodemm "
!mm" #
)nn 
;nn 
ifpp 
(pp 
addressResultpp 
.pp 
	IsFailurepp '
)pp' (
returnqq 
Resultqq 
.qq 
Failureqq %
(qq% &
newqq& )
Errorqq* /
(qq/ 0
$strqq0 d
,qqd e
addressResultqqf s
.qqs t
Errorqqt y
.qqy z
Message	qqz Å
)
qqÅ Ç
)
qqÇ É
;
qqÉ Ñ
Resulttt 
emailAddressResulttt %
=tt& '
AddEmailAddresstt( 7
(tt7 8
reftt8 ;
employeett< D
,ttD E
$numttF G
,ttG H
commandttI P
.ttP Q
EmailAddressttQ ]
!tt] ^
)tt^ _
;tt_ `
ifvv 
(vv 
emailAddressResultvv "
.vv" #
	IsFailurevv# ,
)vv, -
returnww 
Resultww 
.ww 
Failureww %
(ww% &
newww& )
Errorww* /
(ww/ 0
$strww0 d
,wwd e
emailAddressResultwwf x
.wwx y
Errorwwy ~
.ww~ 
Message	ww Ü
)
wwÜ á
)
wwá à
;
wwà â
Resultzz 
personPhoneResultzz $
=zz% &
AddPersonPhonezz' 5
(zz5 6
refzz6 9
employeezz: B
,zzB C
(zzD E
PhoneNumberTypezzE T
)zzT U
commandzzU \
.zz\ ]
PhoneNumberTypeIDzz] n
,zzn o
commandzzp w
.zzw x
PhoneNumber	zzx É
!
zzÉ Ñ
)
zzÑ Ö
;
zzÖ Ü
if|| 
(|| 
personPhoneResult|| !
.||! "
	IsFailure||" +
)||+ ,
return}} 
Result}} 
.}} 
Failure}} %
(}}% &
new}}& )
Error}}* /
(}}/ 0
$str}}0 d
,}}d e
personPhoneResult}}f w
.}}w x
Error}}x }
.}}} ~
Message	}}~ Ö
)
}}Ö Ü
)
}}Ü á
;
}}á à
return
ÅÅ 
Result
ÅÅ 
.
ÅÅ 
Success
ÅÅ !
(
ÅÅ! "
)
ÅÅ" #
;
ÅÅ# $
}
ÇÇ 	
private
ÑÑ 
static
ÑÑ 
Result
ÑÑ $
AddDepartmentHistories
ÑÑ 4
(
ÑÑ4 5
ref
ÑÑ5 8
Employee
ÑÑ9 A
employee
ÑÑB J
,
ÑÑJ K
List
ÑÑL P
<
ÑÑP Q&
DepartmentHistoryCommand
ÑÑQ i
>
ÑÑi j
?
ÑÑj k!
departmentHistories
ÑÑl 
)ÑÑ Ä
{
ÖÖ 	
foreach
ÜÜ 
(
ÜÜ &
DepartmentHistoryCommand
ÜÜ -

department
ÜÜ. 8
in
ÜÜ9 ;!
departmentHistories
ÜÜ< O
!
ÜÜO P
)
ÜÜP Q
{
áá 
Result
àà 
<
àà 
DepartmentHistory
àà (
>
àà( )
result
àà* 0
=
àà1 2
employee
àà3 ;
.
àà; <"
AddDepartmentHistory
àà< P
(
ââ 
new
ää !
DepartmentHistoryID
ää +
(
ää+ ,

department
ää, 6
.
ää6 7
BusinessEntityID
ää7 G
)
ääG H
,
ääH I
new
ãã 
DepartmentID
ãã $
(
ãã$ %

department
ãã% /
.
ãã/ 0
DepartmentID
ãã0 <
)
ãã< =
,
ãã= >
new
åå 
ShiftID
åå 
(
åå  

department
åå  *
.
åå* +
ShiftID
åå+ 2
)
åå2 3
,
åå3 4
DateOnly
çç 
.
çç 
FromDateTime
çç )
(
çç) *

department
çç* 4
.
çç4 5
	StartDate
çç5 >
)
çç> ?
,
çç? @
DateOnly
éé 
.
éé 
FromDateTime
éé )
(
éé) *
(
éé* +
DateTime
éé+ 3
)
éé3 4

department
éé4 >
.
éé> ?
EndDate
éé? F
!
ééF G
)
ééG H
)
êê 
;
êê 
if
íí 
(
íí 
result
íí 
.
íí 
	IsFailure
íí $
)
íí$ %
return
ìì 
Result
ìì !
.
ìì! "
Failure
ìì" )
(
ìì) *
new
ìì* -
Error
ìì. 3
(
ìì3 4
$str
ìì4 h
,
ììh i
result
ììj p
.
ììp q
Error
ììq v
.
ììv w
Message
ììw ~
)
ìì~ 
)ìì Ä
;ììÄ Å
}
îî 
return
ïï 
Result
ïï 
.
ïï 
Success
ïï !
(
ïï! "
)
ïï" #
;
ïï# $
}
ññ 	
private
òò 
static
òò 
Result
òò 
AddPayHistories
òò -
(
òò- .
ref
òò. 1
Employee
òò2 :
employee
òò; C
,
òòC D
List
òòE I
<
òòI J
PayHistoryCommand
òòJ [
>
òò[ \
?
òò\ ]
payHistories
òò^ j
)
òòj k
{
ôô 	
foreach
öö 
(
öö 
PayHistoryCommand
öö &
pay
öö' *
in
öö+ -
payHistories
öö. :
!
öö: ;
)
öö; <
{
õõ 
Result
úú 
result
úú 
=
úú 
employee
úú  (
.
úú( )
AddPayHistory
úú) 6
(
úú6 7
new
ùù 
PayHistoryID
ùù $
(
ùù$ %
pay
ùù% (
.
ùù( )
BusinessEntityID
ùù) 9
)
ùù9 :
,
ùù: ;
pay
ûû 
.
ûû 
RateChangeDate
ûû &
,
ûû& '
pay
üü 
.
üü 
Rate
üü 
,
üü 
(
†† 
PayFrequency
†† !
)
††! "
pay
††" %
.
††% &
PayFrequency
††& 2
)
°° 
;
°° 
if
££ 
(
££ 
result
££ 
.
££ 
	IsFailure
££ $
)
££$ %
return
§§ 
Result
§§ !
.
§§! "
Failure
§§" )
(
§§) *
new
§§* -
Error
§§. 3
(
§§3 4
$str
§§4 a
,
§§a b
result
§§c i
.
§§i j
Error
§§j o
.
§§o p
Message
§§p w
)
§§w x
)
§§x y
;
§§y z
}
•• 
return
¶¶ 
Result
¶¶ 
.
¶¶ 
Success
¶¶ !
(
¶¶! "
)
¶¶" #
;
¶¶# $
}
ßß 	
private
©© 
static
©© 
Result
©© 

AddAddress
©© (
(
™™ 	
ref
´´ 
Employee
´´ 
employee
´´ !
,
´´! "
int
¨¨ 
	addressID
¨¨ 
,
¨¨ 
string
≠≠ 
line1
≠≠ 
,
≠≠ 
string
ÆÆ 
?
ÆÆ 
line2
ÆÆ 
,
ÆÆ 
string
ØØ 
city
ØØ 
,
ØØ 
int
∞∞ 
stateProvinceID
∞∞ 
,
∞∞  
string
±± 

postalCode
±± 
)
≤≤ 	
{
≥≥ 	
Result
¥¥ 
result
¥¥ 
=
¥¥ 
employee
¥¥ $
.
¥¥$ %

AddAddress
¥¥% /
(
µµ 
new
∂∂ 
	AddressID
∂∂ 
(
∂∂ 
	addressID
∂∂ '
)
∂∂' (
,
∂∂( )
AddressType
∑∑ 
.
∑∑ 
Home
∑∑  
,
∑∑  !
line1
∏∏ 
,
∏∏ 
line2
ππ 
,
ππ 
city
∫∫ 
,
∫∫ 
stateProvinceID
ªª 
,
ªª  

postalCode
ºº 
)
ΩΩ 
;
ΩΩ 
if
øø 
(
øø 
result
øø 
.
øø 
	IsFailure
øø  
)
øø  !
return
¿¿ 
Result
¿¿ 
.
¿¿ 
Failure
¿¿ %
(
¿¿% &
new
¿¿& )
Error
¿¿* /
(
¿¿/ 0
$str
¿¿0 X
,
¿¿X Y
result
¿¿Z `
.
¿¿` a
Error
¿¿a f
.
¿¿f g
Message
¿¿g n
)
¿¿n o
)
¿¿o p
;
¿¿p q
else
¡¡ 
return
¬¬ 
Result
¬¬ 
.
¬¬ 
Success
¬¬ %
(
¬¬% &
)
¬¬& '
;
¬¬' (
}
√√ 	
private
≈≈ 
static
≈≈ 
Result
≈≈ 
AddEmailAddress
≈≈ -
(
≈≈- .
ref
≈≈. 1
Employee
≈≈2 :
employee
≈≈; C
,
≈≈C D
int
≈≈E H
emailAddressId
≈≈I W
,
≈≈W X
string
≈≈Y _
emailAddress
≈≈` l
)
≈≈l m
{
∆∆ 	
Result
«« 
result
«« 
=
«« 
employee
«« $
.
««$ %
AddEmailAddress
««% 4
(
««4 5
new
««5 8"
PersonEmailAddressID
««9 M
(
««M N
emailAddressId
««N \
)
««\ ]
,
««] ^
emailAddress
««_ k
)
««k l
;
««l m
if
…… 
(
…… 
result
…… 
.
…… 
	IsFailure
……  
)
……  !
return
   
Result
   
.
   
Failure
   %
(
  % &
new
  & )
Error
  * /
(
  / 0
$str
  0 ]
,
  ] ^
result
  _ e
.
  e f
Error
  f k
.
  k l
Message
  l s
)
  s t
)
  t u
;
  u v
else
ÀÀ 
return
ÃÃ 
Result
ÃÃ 
.
ÃÃ 
Success
ÃÃ %
(
ÃÃ% &
)
ÃÃ& '
;
ÃÃ' (
}
ÕÕ 	
private
œœ 
static
œœ 
Result
œœ 
AddPersonPhone
œœ ,
(
œœ, -
ref
œœ- 0
Employee
œœ1 9
employee
œœ: B
,
œœB C
PhoneNumberType
œœD S
phoneNumberType
œœT c
,
œœc d
string
œœe k
phoneNumber
œœl w
)
œœw x
{
–– 	
Result
—— 
result
—— 
=
—— 
employee
—— $
.
——$ %
AddPhoneNumber
——% 3
(
——3 4
new
——4 7
PersonPhoneID
——8 E
(
——E F
employee
——F N
.
——N O
Id
——O Q
.
——Q R
Value
——R W
)
——W X
,
——X Y
phoneNumberType
——Z i
,
——i j
phoneNumber
——k v
)
——v w
;
——w x
if
”” 
(
”” 
result
”” 
.
”” 
	IsFailure
””  
)
””  !
return
‘‘ 
Result
‘‘ 
.
‘‘ 
Failure
‘‘ %
(
‘‘% &
new
‘‘& )
Error
‘‘* /
(
‘‘/ 0
$str
‘‘0 \
,
‘‘\ ]
result
‘‘^ d
.
‘‘d e
Error
‘‘e j
.
‘‘j k
Message
‘‘k r
)
‘‘r s
)
‘‘s t
;
‘‘t u
else
’’ 
return
÷÷ 
Result
÷÷ 
.
÷÷ 
Success
÷÷ %
(
÷÷% &
)
÷÷& '
;
÷÷' (
}
◊◊ 	
}
ÿÿ 
}ŸŸ …
ë/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/CreateEmployee/CreateEmployeeBusinessRuleValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
CreateEmployee2 @
{ 
public 

sealed 
class /
#CreateEmployeeBusinessRuleValidator ;
:< =
CommandValidator> N
<N O!
CreateEmployeeCommandO d
>d e
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repo

6 ;
;

; <
public /
#CreateEmployeeBusinessRuleValidator 2
(2 3(
IValidationRepositoryManager3 O
repoP T
)T U
=> 
_repo 
= 
repo 
; 
public 
override 
async 
Task "
<" #
Result# )
>) *
Validate+ 3
(3 4!
CreateEmployeeCommand4 I
commandJ Q
)Q R
{ 	*
CreateEmployeeNameMustBeUnique *"
verifyNameIsUniqueRule+ A
=B C
newD G
(G H
_repoH M
)M N
;N O+
CreateEmployeeEmailMustBeUnique +#
verifyEmailIsUniqueRule, C
=D E
newF I
(I J
_repoJ O
)O P
;P Q6
*CreateEmployeeNationalIdNumberMustBeUnique 6(
verifyNationalIdIsUniqueRule7 S
=T U
newV Y
(Y Z
_repoZ _
)_ `
;` a-
!CreateEmployeeDepartmentMustExist -
verifyDeptExistRule. A
=B C
newD G
(G H
_repoH M
)M N
;N O(
CreateEmployeeShiftMustExist ( 
verifyShiftExistRule) =
=> ?
new@ C
(C D
_repoD I
)I J
;J K*
CreateEmployeeManagerMustExist *
verifyMgrExistRule+ =
=> ?
new@ C
(C D
_repoD I
)I J
;J K"
verifyNameIsUniqueRule "
." #
SetNext# *
(* +#
verifyEmailIsUniqueRule+ B
)B C
;C D#
verifyEmailIsUniqueRule #
.# $
SetNext$ +
(+ ,(
verifyNationalIdIsUniqueRule, H
)H I
;I J(
verifyNationalIdIsUniqueRule (
.( )
SetNext) 0
(0 1
verifyDeptExistRule1 D
)D E
;E F 
verifyShiftExistRule  
.  !
SetNext! (
(( )
verifyMgrExistRule) ;
); <
;< =
ValidationResult 
result #
=$ %
await& +"
verifyNameIsUniqueRule, B
.B C
ValidateC K
(K L
commandL S
)S T
;T U
if 
( 
result 
. 
IsValid 
) 
{   
return!! 
Result!! 
.!! 
Success!! %
(!!% &
)!!& '
;!!' (
}"" 
else## 
{$$ 
return%% 
Result%% 
.%% 
Failure%% %
(%%% &
new%%& )
Error%%* /
(%%/ 0
$str%%0 ^
,%%^ _
result%%` f
.%%f g
Messages%%g o
[%%o p
$num%%p q
]%%q r
)%%r s
)%%s t
;%%t u
}&& 
}'' 	
}(( 
})) ’
É/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/CreateEmployee/CreateEmployeeCommand.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
CreateEmployee2 @
;@ A
public 
sealed 
record !
CreateEmployeeCommand *
( 
int 
BusinessEntityID 
, 
int 
	NameStyle 
, 
string		 

?		
 
Title		 
,		 
string

 

	FirstName

 
,

 
string 

LastName 
, 
string 

?
 

MiddleName 
, 
string 

?
 
Suffix 
, 
string 

JobTitle 
, 
string 

PhoneNumber 
, 
int 
PhoneNumberTypeID 
, 
string 

EmailAddress 
, 
int 
EmailPromotion 
, 
string 

NationalIDNumber 
, 
string 

LoginID 
, 
string 

AddressLine1 
, 
string 

AddressLine2 
, 
string 

City 
, 
int 
StateProvinceID 
, 
string 


PostalCode 
, 
DateTime 
	BirthDate 
, 
string 

MaritalStatus 
, 
string 

Gender 
, 
DateTime 
HireDate 
, 
bool 
Salaried	 
, 
int 
VacationHours 
, 
int   
SickLeaveHours   
,   
bool!! 
Active!!	 
,!! 
int"" 
	ManagerID"" 
,"" 
List## 
<## 	$
DepartmentHistoryCommand##	 !
>##! "
?##" #
DepartmentHistories##$ 7
,##7 8
List$$ 
<$$ 	
PayHistoryCommand$$	 
>$$ 
?$$ 
PayHistories$$ )
)%% 
:%% 
ICommand%% 
<%% 
int%% 
>%% 
;%% ﬁ
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/CreateEmployee/CreateEmployeeCommandHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
CreateEmployee2 @
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
 (
CreateEmployeeCommandHandler

 4
:

5 6
ICommandHandler

7 F
<

F G!
CreateEmployeeCommand

G \
,

\ ]
int

^ a
>

a b
{ 
private 
readonly #
IWriteRepositoryManager 0
_repo1 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
public (
CreateEmployeeCommandHandler +
(+ ,#
IWriteRepositoryManager, C
repoD H
,H I
IMapperJ Q
mapperR X
)X Y
=> 
( 
_repo 
, 
_mapper 
) 
=  !
(" #
repo# '
,' (
mapper) /
)/ 0
;0 1
public 
async 
Task 
< 
Result  
<  !
int! $
>$ %
>% &
Handle' -
(- .!
CreateEmployeeCommand. C
commandD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 	
Result 
< 
Employee 
>  
employeeDomainObject 1
=2 3%
BuildEmployeeDomainObject4 M
.M N
BuildN S
(S T
commandT [
,[ \
_mapper] d
)d e
;e f
if 
(  
employeeDomainObject $
.$ %
	IsFailure% .
). /
return 
Result 
< 
int !
>! "
." #
Failure# *
<* +
int+ .
>. /
(/ 0
new0 3
Error4 9
(9 :
$str: _
,_ ` 
employeeDomainObjecta u
.u v
Errorv {
.{ |
Message	| É
)
É Ñ
)
Ñ Ö
;
Ö Ü
Result 
< 
int 
> 
insertDbResult &
=' (
await) .
_repo/ 4
.4 5'
EmployeeAggregateRepository5 P
.P Q
InsertAsyncQ \
(\ ] 
employeeDomainObject] q
.q r
Valuer w
)w x
;x y
if 
( 
insertDbResult 
. 
	IsFailure (
)( )
return 
Result 
< 
int !
>! "
." #
Failure# *
<* +
int+ .
>. /
(/ 0
new0 3
Error4 9
(9 :
$str: _
,_ `
insertDbResulta o
.o p
Errorp u
.u v
Messagev }
)} ~
)~ 
;	 Ä
return 
insertDbResult !
;! "
} 	
}   
}!! Çå
â/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/CreateEmployee/CreateEmployeeDataValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
CreateEmployee2 @
{ 
public 

class '
CreateEmployeeDataValidator ,
:- .
AbstractValidator/ @
<@ A!
CreateEmployeeCommandA V
>V W
{ 
public '
CreateEmployeeDataValidator *
(* +
)+ ,
{		 	
RuleFor

 
(

 
employee

 
=>

 
employee

  (
.

( )
BusinessEntityID

) 9
)

9 :
.( )
Equal) .
(. /
$num/ 0
)0 1
.( )
WithMessage) 4
(4 5
$str5 Z
)Z [
;[ \
RuleFor 
( 
employee 
=> 
employee  (
.( )
Title) .
). /
.( )
MaximumLength) 6
(6 7
$num7 8
)8 9
.9 :
WithMessage: E
(E F
$strF p
)p q
;q r
RuleFor 
( 
employee 
=> 
employee  (
.( )
	FirstName) 2
)2 3
.( )
NotEmpty) 1
(1 2
)2 3
.3 4
WithMessage4 ?
(? @
$str@ h
)h i
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$str	G Ä
)
Ä Å
;
Å Ç
RuleFor 
( 
employee 
=> 
employee  (
.( )
LastName) 1
)1 2
.( )
NotEmpty) 1
(1 2
)2 3
.3 4
WithMessage4 ?
(? @
$str@ g
)g h
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$strG 
)	 Ä
;
Ä Å
RuleFor 
( 
employee 
=> 
employee  (
.( )

MiddleName) 3
)3 4
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$str	G Å
)
Å Ç
;
Ç É
RuleFor 
( 
employee 
=> 
employee  (
.( )
Suffix) /
)/ 0
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$strG s
)s t
;t u
RuleFor 
( 
employee 
=> 
employee  (
.( )
EmailPromotion) 7
)7 8
.  ( )
Must  ) -
(  - .

emailPromo  . 8
=>  9 ;

emailPromo  < F
>=  G I
$num  J K
&&  L N

emailPromo  O Y
<=  Z \
$num  ] ^
)  ^ _
.!!( )
WithMessage!!) 4
(!!4 5
$str!!5 ^
)!!^ _
;!!_ `
RuleFor## 
(## 
employee## 
=>## 
employee##  (
.##( )
NationalIDNumber##) 9
)##9 :
.$$( )
NotEmpty$$) 1
($$1 2
)$$2 3
.$$3 4
WithMessage$$4 ?
($$? @
$str$$@ `
)$$` a
.%%( )
Matches%%) 0
(%%0 1
$str%%1 <
)%%< =
.%%= >
WithMessage%%> I
(%%I J
$str	%%J ì
)
%%ì î
.&&( )
MinimumLength&&) 6
(&&6 7
$num&&7 8
)&&8 9
.&&9 :
WithMessage&&: E
(&&E F
$str&&F w
)&&w x
.''( )
MaximumLength'') 6
(''6 7
$num''7 8
)''8 9
.''9 :
WithMessage'': E
(''E F
$str''F v
)''v w
;''w x
RuleFor)) 
()) 
employee)) 
=>)) 
employee))  (
.))( )
LoginID))) 0
)))0 1
.**( )
NotEmpty**) 1
(**1 2
)**2 3
.**3 4
WithMessage**4 ?
(**? @
$str**@ c
)**c d
.++( )
MaximumLength++) 6
(++6 7
$num++7 9
)++9 :
.++: ;
WithMessage++; F
(++F G
$str++G |
)++| }
;++} ~
RuleFor-- 
(-- 
employee-- 
=>-- 
employee--  (
.--( )
JobTitle--) 1
)--1 2
...( )
NotEmpty..) 1
(..1 2
)..2 3
...3 4
WithMessage..4 ?
(..? @
$str..@ g
)..g h
.//( )
MaximumLength//) 6
(//6 7
$num//7 9
)//9 :
.//: ;
WithMessage//; F
(//F G
$str//G 
)	// Ä
;
//Ä Å
RuleFor11 
(11 
employee11 
=>11 
employee11  (
.11( )
	BirthDate11) 2
)112 3
.22( )
NotEmpty22) 1
(221 2
)222 3
.223 4
WithMessage224 ?
(22? @
$str22@ b
)22b c
.33( ) 
GreaterThanOrEqualTo33) =
(33= >
new33> A
DateTime33B J
(33J K
$num33K O
,33O P
$num33Q R
,33R S
$num33T U
,33U V
$num33W X
,33X Y
$num33Z [
,33[ \
$num33] ^
,33^ _
DateTimeKind33` l
.33l m
Local33m r
)33r s
)33s t
.33t u
WithMessage	33u Ä
(
33Ä Å
$str
33Å ´
)
33´ ¨
.44( )
LessThanOrEqualTo44) :
(44: ;
DateTime44; C
.44C D
Now44D G
.44G H
AddYears44H P
(44P Q
-44Q R
$num44R T
)44T U
)44U V
.44V W
WithMessage44W b
(44b c
$str	44c å
)
44å ç
;
44ç é
RuleFor66 
(66 
employee66 
=>66 
employee66  (
.66( )
MaritalStatus66) 6
)666 7
.77( )
NotEmpty77) 1
(771 2
)772 3
.773 4
WithMessage774 ?
(77? @
$str77@ f
)77f g
.88( )
Must88) -
(88- .
status88. 4
=>885 7
string888 >
.88> ?
Equals88? E
(88E F
status88F L
,88L M
$str88N Q
,88Q R
StringComparison88S c
.88c d$
CurrentCultureIgnoreCase88d |
)88| }
||	88~ Ä
string998 >
.99> ?
Equals99? E
(99E F
status99F L
,99L M
$str99N Q
,99Q R
StringComparison99S c
.99c d
OrdinalIgnoreCase99d u
)99u v
)99v w
.::( )
WithMessage::) 4
(::4 5
$str::5 l
)::l m
;::m n
RuleFor<< 
(<< 
employee<< 
=><< 
employee<<  (
.<<( )
Gender<<) /
)<</ 0
.==( )
NotEmpty==) 1
(==1 2
)==2 3
.==3 4
WithMessage==4 ?
(==? @
$str==@ ^
)==^ _
.>>( )
Must>>) -
(>>- .
gender>>. 4
=>>>5 7
string>>8 >
.>>> ?
Equals>>? E
(>>E F
gender>>F L
,>>L M
$str>>N Q
,>>Q R
StringComparison>>S c
.>>c d
OrdinalIgnoreCase>>d u
)>>u v
||>>w y
string??8 >
.??> ?
Equals??? E
(??E F
gender??F L
,??L M
$str??N Q
,??Q R
StringComparison??S c
.??c d
OrdinalIgnoreCase??d u
)??u v
)??v w
.@@( )
WithMessage@@) 4
(@@4 5
$str@@5 a
)@@a b
;@@b c
RuleForBB 
(BB 
employeeBB 
=>BB 
employeeBB  (
.BB( )
HireDateBB) 1
)BB1 2
.CC( )
NotEmptyCC) 1
(CC1 2
)CC2 3
.CC3 4
WithMessageCC4 ?
(CC? @
$strCC@ a
)CCa b
.DD( )
MustDD) -
(DD- .
hireDateDD. 6
=>DD7 9
hireDateDD: B
>=DDC E
newDDF I
DateTimeDDJ R
(DDR S
$numDDS W
,DDW X
$numDDY Z
,DDZ [
$numDD\ ]
,DD] ^
$numDD_ `
,DD` a
$numDDb c
,DDc d
$numDDe f
,DDf g
DateTimeKindDDh t
.DDt u
LocalDDu z
)DDz {
)DD{ |
.EE( )
WithMessageEE) 4
(EE4 5
$strEE5 b
)EEb c
;EEc d
RuleForGG 
(GG 
employeeGG 
=>GG 
employeeGG  (
.GG( )
VacationHoursGG) 6
)GG6 7
.HH( )
MustHH) -
(HH- .
vacationHH. 6
=>HH7 9
vacationHH: B
>=HHC E
-HHF G
$numHHG I
&&HHJ L
vacationHHM U
<=HHV X
$numHHY \
)HH\ ]
.II( )
WithMessageII) 4
(II4 5
$strII5 l
)IIl m
;IIm n
RuleForKK 
(KK 
employeeKK 
=>KK 
employeeKK  (
.KK( )
SickLeaveHoursKK) 7
)KK7 8
.LL( )
MustLL) -
(LL- .
	sickleaveLL. 7
=>LL8 :
	sickleaveLL; D
>=LLE G
$numLLH I
&&LLJ L
	sickleaveLLM V
<=LLW Y
$numLLZ ]
)LL] ^
.MM( )
WithMessageMM) 4
(MM4 5
$strMM5 d
)MMd e
;MMe f
RuleForOO 
(OO 
employeeOO 
=>OO 
employeeOO  (
.OO( )
ActiveOO) /
)OO/ 0
.PP( )
MustPP) -
(PP- .
statusPP. 4
=>PP5 7
statusPP8 >
)PP> ?
.QQ( )
WithMessageQQ) 4
(QQ4 5
$strQQ5 c
)QQc d
;QQd e
RuleForSS 
(SS 
employeeSS 
=>SS 
employeeSS  (
.SS( )
	ManagerIDSS) 2
)SS2 3
.TT( )
GreaterThanTT) 4
(TT4 5
$numTT5 6
)TT6 7
.UU( )
WithMessageUU) 4
(UU4 5
$strUU5 P
)UUP Q
;UUQ R
RuleForWW 
(WW 
employeeWW 
=>WW 
employeeWW  (
.WW( )
AddressLine1WW) 5
)WW5 6
.XX( )
NotEmptyXX) 1
(XX1 2
)XX2 3
.XX3 4
WithMessageXX4 ?
(XX? @
$strXX@ c
)XXc d
.YY( )
MaximumLengthYY) 6
(YY6 7
$numYY7 9
)YY9 :
.YY: ;
WithMessageYY; F
(YYF G
$strYYG y
)YYy z
;YYz {
RuleFor[[ 
([[ 
employee[[ 
=>[[ 
employee[[  (
.[[( )
AddressLine2[[) 5
)[[5 6
.\\( )
MaximumLength\\) 6
(\\6 7
$num\\7 9
)\\9 :
.\\: ;
WithMessage\\; F
(\\F G
$str\\G y
)\\y z
;\\z {
RuleFor^^ 
(^^ 
employee^^ 
=>^^ 
employee^^  (
.^^( )
City^^) -
)^^- .
.__( )
NotEmpty__) 1
(__1 2
)__2 3
.__3 4
WithMessage__4 ?
(__? @
$str__@ ^
)__^ _
.``( )
MaximumLength``) 6
(``6 7
$num``7 9
)``9 :
.``: ;
WithMessage``; F
(``F G
$str``G v
)``v w
;``w x
RuleForbb 
(bb 
employeebb 
=>bb 
employeebb  (
.bb( )
StateProvinceIDbb) 8
)bb8 9
.cc( )
GreaterThancc) 4
(cc4 5
$numcc5 6
)cc6 7
.dd( )
WithMessagedd) 4
(dd4 5
$strdd5 S
)ddS T
;ddT U
RuleForff 
(ff 
employeeff 
=>ff 
employeeff  (
.ff( )

PostalCodeff) 3
)ff3 4
.gg( )
NotEmptygg) 1
(gg1 2
)gg2 3
.gg3 4
WithMessagegg4 ?
(gg? @
$strgg@ `
)gg` a
.hh( )
MaximumLengthhh) 6
(hh6 7
$numhh7 9
)hh9 :
.hh: ;
WithMessagehh; F
(hhF G
$strhhG v
)hhv w
;hhw x
RuleForjj 
(jj 
employeejj 
=>jj 
employeejj  (
.jj( )
EmailAddressjj) 5
)jj5 6
.jj6 7
EmailAddressjj7 C
(jjC D
)jjD E
;jjE F
RuleForll 
(ll 
employeell 
=>ll 
employeell  (
.ll( )
PhoneNumberll) 4
)ll4 5
.ll5 6
Matchesll6 =
(ll= >
$str	ll> ò
)
llò ô
;
llô ö
RuleFornn 
(nn 
employeenn 
=>nn 
employeenn  (
.nn( )
PhoneNumberTypeIDnn) :
)nn: ;
.oo( )
Mustoo) -
(oo- .
phTypeoo. 4
=>oo5 7
phTypeoo8 >
>=oo? A
$numooB C
&&ooD F
phTypeooG M
<=ooN P
$numooQ R
)ooR S
.pp( )
WithMessagepp) 4
(pp4 5
$strpp5 s
)pps t
;ppt u
RuleForrr 
(rr 
employeerr 
=>rr 
employeerr  (
.rr( )
DepartmentHistoriesrr) <
)rr< =
.rr= >
NotEmptyrr> F
(rrF G
)rrG H
.ss= >
Mustss> B
(ssB C
listssC G
=>ssH J
listssK O
!ssO P
.ssP Q
CountssQ V
==ssW Y
$numssZ [
)ss[ \
.tt= >
WithMessagett> I
(ttI J
$str	ttJ Ü
)
ttÜ á
;
ttá à
RuleForEachvv 
(vv 
employeevv  
=>vv! #
employeevv$ ,
.vv, -
DepartmentHistoriesvv- @
)vv@ A
.vvA B
SetValidatorvvB N
(vvN O
newvvO R,
 DepartmentHistoryCreateValidatorvvS s
(vvs t
)vvt u
)vvu v
;vvv w
RuleForxx 
(xx 
employeexx 
=>xx 
employeexx  (
.xx( )
PayHistoriesxx) 5
)xx5 6
.xx6 7
NotEmptyxx7 ?
(xx? @
)xx@ A
.yy6 7
Mustyy7 ;
(yy; <
listyy< @
=>yyA C
listyyD H
!yyH I
.yyI J
CountyyJ O
==yyP R
$numyyS T
)yyT U
.zz6 7
WithMessagezz7 B
(zzB C
$strzzC x
)zzx y
;zzy z
RuleForEach|| 
(|| 
employee||  
=>||! #
employee||$ ,
.||, -
PayHistories||- 9
)||9 :
.||: ;
SetValidator||; G
(||G H
new||H K%
PayHistoryCreateValidator||L e
(||e f
)||f g
)||g h
;||h i
RuleFor~~ 
(~~ 
employee~~ 
=>~~ 
employee~~  (
)~~( )
.~~) *
Custom~~* 0
(~~0 1
(~~1 2
employeeArgs~~2 >
,~~> ?
context~~@ G
)~~G H
=>~~I K
{ &
DepartmentHistoryCommand
ÅÅ (
?
ÅÅ( )&
departmentHistoryCommand
ÅÅ* B
=
ÅÅC D
employeeArgs
ÅÅE Q
.
ÅÅQ R!
DepartmentHistories
ÅÅR e
!
ÅÅe f
.
ÅÅf g
FirstOrDefault
ÅÅg u
(
ÅÅu v
)
ÅÅv w
;
ÅÅw x
PayHistoryCommand
ÇÇ !
?
ÇÇ! "
payHistoryCommand
ÇÇ# 4
=
ÇÇ5 6
employeeArgs
ÇÇ7 C
.
ÇÇC D
PayHistories
ÇÇD P
!
ÇÇP Q
.
ÇÇQ R
FirstOrDefault
ÇÇR `
(
ÇÇ` a
)
ÇÇa b
;
ÇÇb c
if
ÑÑ 
(
ÑÑ &
departmentHistoryCommand
ÑÑ ,
is
ÑÑ- /
not
ÑÑ0 3
null
ÑÑ4 8
&&
ÑÑ9 ;&
departmentHistoryCommand
ÑÑ< T
.
ÑÑT U
	StartDate
ÑÑU ^
!=
ÑÑ_ a
employeeArgs
ÑÑb n
.
ÑÑn o
HireDate
ÑÑo w
)
ÑÑw x
{
ÖÖ 
context
ÜÜ 
.
ÜÜ 

AddFailure
ÜÜ &
(
ÜÜ& '
$str
ÜÜ' ]
)
ÜÜ] ^
;
ÜÜ^ _
}
áá 
if
ââ 
(
ââ 
payHistoryCommand
ââ %
is
ââ& (
not
ââ) ,
null
ââ- 1
&&
ââ2 4
payHistoryCommand
ââ5 F
.
ââF G
RateChangeDate
ââG U
!=
ââV X
employeeArgs
ââY e
.
ââe f
HireDate
ââf n
)
âân o
{
ää 
context
ãã 
.
ãã 

AddFailure
ãã &
(
ãã& '
$str
ãã' X
)
ããX Y
;
ããY Z
}
åå 
}
çç 
)
çç 
;
çç 
}
éé 	
}
èè 
}êê º
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/CreateEmployee/DepartmentHistoryCreateValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
CreateEmployee2 @
{ 
public 

class ,
 DepartmentHistoryCreateValidator 1
:2 3
AbstractValidator4 E
<E F$
DepartmentHistoryCommandF ^
>^ _
{ 
public ,
 DepartmentHistoryCreateValidator /
(/ 0
)0 1
{		 	
RuleFor

 
(

 
departHistory

 !
=>

" $
departHistory

% 2
.

2 3
BusinessEntityID

3 C
)

C D
.2 3
Equal3 8
(8 9
$num9 :
): ;
.2 3
WithMessage3 >
(> ?
$str? |
)| }
;} ~
RuleFor 
( 
departHistory !
=>" $
departHistory% 2
.2 3
DepartmentID3 ?
)? @
.2 3
GreaterThan3 >
(> ?
$num? @
)@ A
.2 3
WithMessage3 >
(> ?
$str? ]
)] ^
;^ _
RuleFor 
( 
departHistory !
=>" $
departHistory% 2
.2 3
ShiftID3 :
): ;
.2 3
GreaterThan3 >
(> ?
$num? @
)@ A
.2 3
WithMessage3 >
(> ?
$str? X
)X Y
;Y Z
RuleFor 
( 
departHistory !
=>" $
departHistory% 2
.2 3
	StartDate3 <
)< =
.2 3
NotEmpty3 ;
(; <
)< =
.= >
WithMessage> I
(I J
$strJ x
)x y
;y z
} 	
} 
} â
á/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/CreateEmployee/PayHistoryCreateValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
CreateEmployee2 @
{ 
public 

class %
PayHistoryCreateValidator *
:+ ,
AbstractValidator- >
<> ?
PayHistoryCommand? P
>P Q
{ 
public %
PayHistoryCreateValidator (
(( )
)) *
{		 	
RuleFor

 
(

 

payHistory

 
=>

 !

payHistory

" ,
.

, -
BusinessEntityID

- =
)

= >
., -
Equal- 2
(2 3
$num3 4
)4 5
., -
WithMessage- 8
(8 9
$str9 o
)o p
;p q
RuleFor 
( 

payHistory 
=> !

payHistory" ,
., -
RateChangeDate- ;
); <
., -
NotEmpty- 5
(5 6
)6 7
.7 8
WithMessage8 C
(C D
$strD x
)x y
;y z
RuleFor 
( 

payHistory 
=> !

payHistory" ,
., -
Rate- 1
)1 2
., -
Must- 1
(1 2
pay2 5
=>6 8
pay9 <
>== ?
$num@ E
&&F H
payI L
<=M O
$numP T
)T U
., -
WithMessage- 8
(8 9
$str9 p
)p q
;q r
RuleFor 
( 

payHistory 
=> !

payHistory" ,
., -
PayFrequency- 9
)9 :
., -
Must- 1
(1 2
freq2 6
=>7 9
freq: >
==? A
$numB C
||D F
freqG K
==L N
$numO P
)P Q
., -
WithMessage- 8
(8 9
$str9 v
)v w
;w x
} 	
} 
} ◊
ë/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/DeleteEmployee/DeleteEmployeeBusinessRuleValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
DeleteEmployee2 @
{ 
public 

sealed 
class /
#DeleteEmployeeBusinessRuleValidator ;
:< =
CommandValidator> N
<N O!
DeleteEmployeeCommandO d
>d e
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repo

6 ;
;

; <
public /
#DeleteEmployeeBusinessRuleValidator 2
(2 3(
IValidationRepositoryManager3 O
repoP T
)T U
=> 
_repo 
= 
repo 
; 
public 
override 
async 
Task "
<" #
Result# )
>) *
Validate+ 3
(3 4!
DeleteEmployeeCommand4 I
commandJ Q
)Q R
{ 	#
DeleteEmployeeMustExist #
verifyEmployeeExist$ 7
=8 9
new: =
(= >
_repo> C
)C D
;D E
ValidationResult 
result #
=$ %
await& +
verifyEmployeeExist, ?
.? @
Validate@ H
(H I
commandI P
)P Q
;Q R
if 
( 
result 
. 
IsValid 
) 
{ 
return 
Result 
. 
Success %
(% &
)& '
;' (
} 
else 
{ 
return 
Result 
. 
Failure %
(% &
new& )
Error* /
(/ 0
$str0 ^
,^ _
result` f
.f g
Messagesg o
[o p
$nump q
]q r
)r s
)s t
;t u
} 
} 	
} 
} ¯
É/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/DeleteEmployee/DeleteEmployeeCommand.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
DeleteEmployee2 @
{ 
public 

sealed 
record !
DeleteEmployeeCommand .
(. /
int/ 2
BusinessEntityID3 C
)C D
:E F
ICommandG O
<O P
intP S
>S T
;T U
} …
ê/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/DeleteEmployee/DeleteEmployeeCommandDataValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
DeleteEmployee2 @
{ 
public 

sealed 
class .
"DeleteEmployeeCommandDataValidator :
:; <
AbstractValidator= N
<N O!
DeleteEmployeeCommandO d
>d e
{ 
public .
"DeleteEmployeeCommandDataValidator 1
(1 2
)2 3
{ 	
RuleFor		 
(		 
employee		 
=>		 
employee		  (
.		( )
BusinessEntityID		) 9
)		9 :
.

( )
GreaterThan

) 4
(

4 5
$num

5 6
)

6 7
.( )
WithMessage) 4
(4 5
$str5 w
)w x
;x y
} 	
} 
} —
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/DeleteEmployee/DeleteEmployeeCommandHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
DeleteEmployee2 @
{ 
public 

sealed 
class (
DeleteEmployeeCommandHandler 4
:5 6
ICommandHandler7 F
<F G!
DeleteEmployeeCommandG \
,\ ]
int^ a
>a b
{ 
private		 
const		 
int		 
RETURN_VALUE		 &
=		' (
$num		) *
;		* +
private

 
readonly

 #
IWriteRepositoryManager

 0
_repo

1 6
;

6 7
public (
DeleteEmployeeCommandHandler +
(+ ,#
IWriteRepositoryManager, C
repoD H
)H I
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
int! $
>$ %
>% &
Handle' -
(- .!
DeleteEmployeeCommand. C
requestD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 	
try 
{ 
Result 
< 
int 
> 
deleteDbResult *
=+ ,
await- 2
_repo3 8
.8 9'
EmployeeAggregateRepository9 T
.T U
DeleteU [
([ \
request\ c
.c d
BusinessEntityIDd t
)t u
;u v
if 
( 
deleteDbResult "
." #
	IsFailure# ,
), -
return 
Result !
<! "
int" %
>% &
.& '
Failure' .
<. /
int/ 2
>2 3
(3 4
new4 7
Error8 =
(= >
$str> c
,c d
deleteDbResulte s
.s t
Errort y
.y z
Message	z Å
)
Å Ç
)
Ç É
;
É Ñ
return 
RETURN_VALUE #
;# $
} 
catch 
( 
	Exception 
ex 
)  
{ 
return 
Result 
< 
int !
>! "
." #
Failure# *
<* +
int+ .
>. /
(/ 0
new0 3
Error4 9
(9 :
$str: _
,_ `
Helpersa h
.h i
GetExceptionMessagei |
(| }
ex} 
)	 Ä
)
Ä Å
)
Å Ç
;
Ç É
} 
} 	
} 
}   ◊
è/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateCompany/UpdateCompanyBusinessRuleValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateCompany2 ?
{ 
public 

sealed 
class .
"UpdateCompanyBusinessRuleValidator :
:; <
CommandValidator= M
<M N 
UpdateCompanyCommandN b
>b c
{ 
public 
override 
async 
Task "
<" #
Result# )
>) *
Validate+ 3
(3 4 
UpdateCompanyCommand4 H
commandI P
)P Q
{		 	
return

 
await

 
Task

 
.

 

FromResult

 (
(

( )
Result

) /
.

/ 0
Success

0 7
(

7 8
)

8 9
)

9 :
;

: ;
} 	
} 
} ≤
Å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateCompany/UpdateCompanyCommand.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateCompany2 ?
{ 
public 

sealed 
class  
UpdateCompanyCommand ,
:- .
ICommand/ 7
<7 8
int8 ;
>; <
{ 
public 
int 
	CompanyID 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
? 
CompanyName "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
string		 
?		 
	LegalName		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public

 
string

 
?

 
EIN

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
string 
? 
CompanyWebSite %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
? 
MailAddressLine1 '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
? 
MailAddressLine2 '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
? 
MailCity 
{  !
get" %
;% &
set' *
;* +
}, -
public 
int 
MailStateProvinceID &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
? 
MailPostalCode %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
string 
?  
DeliveryAddressLine1 +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
?  
DeliveryAddressLine2 +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
? 
DeliveryCity #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
int #
DeliveryStateProvinceID *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
string 
? 
DeliveryPostalCode )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
public 
string 
? 
	Telephone  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
? 
Fax 
{ 
get  
;  !
set" %
;% &
}' (
} 
} ¸@
é/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateCompany/UpdateCompanyCommandDataValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateCompany2 ?
{ 
public 

class -
!UpdateCompanyCommandDataValidator 2
:3 4
AbstractValidator5 F
<F G 
UpdateCompanyCommandG [
>[ \
{ 
public -
!UpdateCompanyCommandDataValidator 0
(0 1
)1 2
{ 	
RuleFor		 
(		 
company		 
=>		 
company		 &
.		& '
	CompanyID		' 0
)		0 1
.

& '
GreaterThan

' 2
(

2 3
$num

3 4
)

4 5
.& '
WithMessage' 2
(2 3
$str3 t
)t u
;u v
RuleFor 
( 
company 
=> 
company &
.& '
CompanyName' 2
)2 3
.& '
NotEmpty' /
(/ 0
)0 1
.1 2
WithMessage2 =
(= >
$str> _
)_ `
.& '
MaximumLength' 4
(4 5
$num5 7
)7 8
.8 9
WithMessage9 D
(D E
$strE w
)w x
;x y
RuleFor 
( 
company 
=> 
company &
.& '
	LegalName' 0
)0 1
.& '
MaximumLength' 4
(4 5
$num5 7
)7 8
.8 9
WithMessage9 D
(D E
$strE u
)u v
;v w
RuleFor 
( 
company 
=> 
company &
.& '
EIN' *
)* +
.& '
NotEmpty' /
(/ 0
)0 1
.1 2
WithMessage2 =
(= >
$str> q
)q r
.& '
Matches' .
(. /
$str/ E
)E F
.F G
WithMessageG R
(R S
$str	S §
)
§ •
;
• ¶
RuleFor 
( 
company 
=> 
company &
.& '
CompanyWebSite' 5
)5 6
.& '
Matches' .
(. /
$str	/ Ä
)
Ä Å
.
Å Ç
WithMessage
Ç ç
(
ç é
$str
é ú
)
ú ù
.& '
MaximumLength' 4
(4 5
$num5 7
)7 8
.8 9
WithMessage9 D
(D E
$strE v
)v w
;w x
RuleFor 
( 
company 
=> 
company &
.& '
MailAddressLine1' 7
)7 8
.& '
NotEmpty' /
(/ 0
)0 1
.1 2
WithMessage2 =
(= >
$str> f
)f g
.& '
MaximumLength' 4
(4 5
$num5 7
)7 8
.8 9
WithMessage9 D
(D E
$strE |
)| }
;} ~
RuleFor   
(   
company   
=>   
company   &
.  & '
MailAddressLine2  ' 7
)  7 8
.!!& '
MaximumLength!!' 4
(!!4 5
$num!!5 7
)!!7 8
.!!8 9
WithMessage!!9 D
(!!D E
$str!!E |
)!!| }
;!!} ~
RuleFor## 
(## 
company## 
=>## 
company## &
.##& '
MailCity##' /
)##/ 0
.$$& '
NotEmpty$$' /
($$/ 0
)$$0 1
.$$1 2
WithMessage$$2 =
($$= >
$str$$> \
)$$\ ]
.%%& '
MaximumLength%%' 4
(%%4 5
$num%%5 7
)%%7 8
.%%8 9
WithMessage%%9 D
(%%D E
$str%%E t
)%%t u
;%%u v
RuleFor'' 
('' 
company'' 
=>'' 
company'' &
.''& '
MailStateProvinceID''' :
)'': ;
.((& '
GreaterThan((' 2
(((2 3
$num((3 4
)((4 5
.))& '
WithMessage))' 2
())2 3
$str))3 U
)))U V
;))V W
RuleFor++ 
(++ 
company++ 
=>++ 
company++ &
.++& '
MailPostalCode++' 5
)++5 6
.,,& '
NotEmpty,,' /
(,,/ 0
),,0 1
.,,1 2
WithMessage,,2 =
(,,= >
$str,,> c
),,c d
.--& '
MaximumLength--' 4
(--4 5
$num--5 7
)--7 8
.--8 9
WithMessage--9 D
(--D E
$str--E {
)--{ |
;--| }
RuleFor// 
(// 
company// 
=>// 
company// &
.//& ' 
DeliveryAddressLine1//' ;
)//; <
.00& '
NotEmpty00' /
(00/ 0
)000 1
.001 2
WithMessage002 =
(00= >
$str00> j
)00j k
.11& '
MaximumLength11' 4
(114 5
$num115 7
)117 8
.118 9
WithMessage119 D
(11D E
$str	11E Ä
)
11Ä Å
;
11Å Ç
RuleFor33 
(33 
company33 
=>33 
company33 &
.33& ' 
DeliveryAddressLine233' ;
)33; <
.44& '
MaximumLength44' 4
(444 5
$num445 7
)447 8
.448 9
WithMessage449 D
(44D E
$str	44E Ä
)
44Ä Å
;
44Å Ç
RuleFor66 
(66 
company66 
=>66 
company66 &
.66& '
DeliveryCity66' 3
)663 4
.77& '
NotEmpty77' /
(77/ 0
)770 1
.771 2
WithMessage772 =
(77= >
$str77> `
)77` a
.88& '
MaximumLength88' 4
(884 5
$num885 7
)887 8
.888 9
WithMessage889 D
(88D E
$str88E x
)88x y
;88y z
RuleFor:: 
(:: 
company:: 
=>:: 
company:: &
.::& '#
DeliveryStateProvinceID::' >
)::> ?
.;;& '
GreaterThan;;' 2
(;;2 3
$num;;3 4
);;4 5
.<<& '
WithMessage<<' 2
(<<2 3
$str<<3 U
)<<U V
;<<V W
RuleFor>> 
(>> 
company>> 
=>>> 
company>> &
.>>& '
DeliveryPostalCode>>' 9
)>>9 :
.??& '
NotEmpty??' /
(??/ 0
)??0 1
.??1 2
WithMessage??2 =
(??= >
$str??> g
)??g h
.@@& '
MaximumLength@@' 4
(@@4 5
$num@@5 7
)@@7 8
.@@8 9
WithMessage@@9 D
(@@D E
$str@@E 
)	@@ Ä
;
@@Ä Å
RuleForBB 
(BB 
companyBB 
=>BB 
companyBB &
.BB& '
	TelephoneBB' 0
)BB0 1
.CC& '
NotEmptyCC' /
(CC/ 0
)CC0 1
.CC1 2
WithMessageCC2 =
(CC= >
$strCC> c
)CCc d
.DD& '
MaximumLengthDD' 4
(DD4 5
$numDD5 7
)DD7 8
.DD8 9
WithMessageDD9 D
(DDD E
$strDDE {
)DD{ |
;DD| }
RuleForFF 
(FF 
companyFF 
=>FF 
companyFF &
.FF& '
FaxFF' *
)FF* +
.GG& '
NotEmptyGG' /
(GG/ 0
)GG0 1
.GG1 2
WithMessageGG2 =
(GG= >
$strGG> V
)GGV W
.HH& '
MaximumLengthHH' 4
(HH4 5
$numHH5 7
)HH7 8
.HH8 9
WithMessageHH9 D
(HHD E
$strHHE n
)HHn o
;HHo p
}II 	
}JJ 
}KK ‹(
à/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateCompany/UpdateCompanyCommandHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateCompany2 ?
{ 
public 

sealed 
class '
UpdateCompanyCommandHandler 3
:4 5
ICommandHandler6 E
<E F 
UpdateCompanyCommandF Z
,Z [
int\ _
>_ `
{		 
private

 
const

 
int

 
RETURN_VALUE

 &
=

' (
$num

) *
;

* +
private 
readonly #
IWriteRepositoryManager 0
_repo1 6
;6 7
public '
UpdateCompanyCommandHandler *
(* +#
IWriteRepositoryManager+ B
repoC G
)G H
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
int! $
>$ %
>% &
Handle' -
(- . 
UpdateCompanyCommand. B
requestC J
,J K
CancellationTokenL ]
cancellationToken^ o
)o p
{ 	
try 
{ 
Result 
< 
Company 
> 
result  &
=' (
Company) 0
.0 1
Create1 7
(7 8
request 
. 
	CompanyID %
,% &
request 
. 
CompanyName '
!' (
,( )
request 
. 
	LegalName %
!% &
,& '
request 
. 
EIN 
!  
,  !
request 
. 
CompanyWebSite *
!* +
,+ ,
request 
. 
MailAddressLine1 ,
!, -
,- .
request 
. 
MailAddressLine2 ,
,, -
request 
. 
MailCity $
!$ %
,% &
request 
. 
MailStateProvinceID /
,/ 0
request 
. 
MailPostalCode *
!* +
,+ ,
request 
.  
DeliveryAddressLine1 0
!0 1
,1 2
request   
.    
DeliveryAddressLine2   0
,  0 1
request!! 
.!! 
DeliveryCity!! (
!!!( )
,!!) *
request"" 
."" #
DeliveryStateProvinceID"" 3
,""3 4
request## 
.## 
DeliveryPostalCode## .
!##. /
,##/ 0
request$$ 
.$$ 
	Telephone$$ %
!$$% &
,$$& '
request%% 
.%% 
Fax%% 
!%%  
)&& 
;&& 
if(( 
((( 
result(( 
.(( 
	IsFailure(( $
)(($ %
return)) 
Result)) !
<))! "
int))" %
>))% &
.))& '
Failure))' .
<)). /
int))/ 2
>))2 3
())3 4
new))4 7
Error))8 =
())= >
$str))> b
,))b c
result))d j
.))j k
Error))k p
.))p q
Message))q x
)))x y
)))y z
;))z {
Result++ 
<++ 
int++ 
>++ 
updateDbResult++ *
=+++ ,
await++- 2
_repo++3 8
.++8 9&
CompanyAggregateRepository++9 S
.++S T
Update++T Z
(++Z [
result++[ a
.++a b
Value++b g
)++g h
;++h i
if-- 
(-- 
updateDbResult-- "
.--" #
	IsFailure--# ,
)--, -
return.. 
Result.. !
<..! "
int.." %
>..% &
...& '
Failure..' .
<... /
int../ 2
>..2 3
(..3 4
new..4 7
Error..8 =
(..= >
$str..> b
,..b c
updateDbResult..d r
...r s
Error..s x
...x y
Message	..y Ä
)
..Ä Å
)
..Å Ç
;
..Ç É
return00 
RETURN_VALUE00 #
;00# $
}11 
catch22 
(22 
	Exception22 
ex22 
)22  
{33 
return44 
Result44 
<44 
int44 !
>44! "
.44" #
Failure44# *
<44* +
int44+ .
>44. /
(44/ 0
new440 3
Error444 9
(449 :
$str44: ^
,44^ _
Helpers44` g
.44g h
GetExceptionMessage44h {
(44{ |
ex44| ~
)44~ 
)	44 Ä
)
44Ä Å
;
44Å Ç
}55 
}66 	
}77 
}88 â
á/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateEmployee/PayHistoryUpdateValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateEmployee2 @
{ 
public 

class %
PayHistoryUpdateValidator *
:+ ,
AbstractValidator- >
<> ?
PayHistoryCommand? P
>P Q
{ 
public %
PayHistoryUpdateValidator (
(( )
)) *
{		 	
RuleFor

 
(

 

payHistory

 
=>

 !

payHistory

" ,
.

, -
BusinessEntityID

- =
)

= >
., -
Equal- 2
(2 3
$num3 4
)4 5
., -
WithMessage- 8
(8 9
$str9 o
)o p
;p q
RuleFor 
( 

payHistory 
=> !

payHistory" ,
., -
RateChangeDate- ;
); <
., -
NotEmpty- 5
(5 6
)6 7
.7 8
WithMessage8 C
(C D
$strD x
)x y
;y z
RuleFor 
( 

payHistory 
=> !

payHistory" ,
., -
Rate- 1
)1 2
., -
Must- 1
(1 2
pay2 5
=>6 8
pay9 <
>== ?
$num@ E
&&F H
payI L
<=M O
$numP T
)T U
., -
WithMessage- 8
(8 9
$str9 p
)p q
;q r
RuleFor 
( 

payHistory 
=> !

payHistory" ,
., -
PayFrequency- 9
)9 :
., -
Must- 1
(1 2
freq2 6
=>7 9
freq: >
==? A
$numB C
||D F
freqG K
==L N
$numO P
)P Q
., -
WithMessage- 8
(8 9
$str9 v
)v w
;w x
} 	
} 
} Í
ë/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateEmployee/UpdateEmployeeBusinessRuleValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateEmployee2 @
{ 
public 

sealed 
class /
#UpdateEmployeeBusinessRuleValidator ;
:< =
CommandValidator> N
<N O!
UpdateEmployeeCommandO d
>d e
{		 
private

 
readonly

 (
IValidationRepositoryManager

 5
_repo

6 ;
;

; <
public /
#UpdateEmployeeBusinessRuleValidator 2
(2 3(
IValidationRepositoryManager3 O
repoP T
)T U
=> 
_repo 
= 
repo 
; 
public 
override 
async 
Task "
<" #
Result# )
>) *
Validate+ 3
(3 4!
UpdateEmployeeCommand4 I
commandJ Q
)Q R
{ 	#
UpdateEmployeeMustExist #
verifyEmployeeExist$ 7
=8 9
new: =
(= >
_repo> C
)C D
;D E*
UpdateEmployeeNameMustBeUnique *
verifyNameIsUnique+ =
=> ?
new@ C
(C D
_repoD I
)I J
;J K6
*UpdateEmployeeNationalIdNumberMustBeUnique 6$
verifyNationalIdIsUnique7 O
=P Q
newR U
(U V
_repoV [
)[ \
;\ ]
verifyEmployeeExist 
.  
SetNext  '
(' (
verifyNameIsUnique( :
): ;
;; <
verifyNameIsUnique 
. 
SetNext &
(& '$
verifyNationalIdIsUnique' ?
)? @
;@ A
ValidationResult 
result #
=$ %
await& +
verifyEmployeeExist, ?
.? @
Validate@ H
(H I
commandI P
)P Q
;Q R
if 
( 
result 
. 
IsValid 
) 
{ 
return 
Result 
. 
Success %
(% &
)& '
;' (
} 
else 
{ 
return   
Result   
.   
Failure   %
(  % &
new  & )
Error  * /
(  / 0
$str  0 ^
,  ^ _
result  ` f
.  f g
Messages  g o
[  o p
$num  p q
]  q r
)  r s
)  s t
;  t u
}!! 
}"" 	
}## 
}$$ Ê
É/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateEmployee/UpdateEmployeeCommand.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateEmployee2 @
{ 
public 

sealed 
record !
UpdateEmployeeCommand .
( 
int 
BusinessEntityID 
, 
int		 
	NameStyle		 
,		 
string

 
?

 
Title

 
,

 
string 
	FirstName 
, 
string 
LastName 
, 
string 
? 

MiddleName 
, 
string 
? 
Suffix 
, 
string 
JobTitle 
, 
string 
PhoneNumber 
, 
int 
PhoneNumberTypeID 
, 
string 
EmailAddress 
, 
int 
EmailPromotion 
, 
string 
NationalIDNumber 
,  
string 
LoginID 
, 
string 
AddressLine1 
, 
string 
AddressLine2 
, 
string 
City 
, 
int 
StateProvinceID 
, 
string 

PostalCode 
, 
DateTime 
	BirthDate 
, 
string 
MaritalStatus 
, 
string 
Gender 
, 
DateTime 
HireDate 
, 
bool 
Salaried 
, 
int   
VacationHours   
,   
int!! 
SickLeaveHours!! 
,!! 
bool"" 
Active"" 
,"" 
int## 
	ManagerID## 
,## 
List$$ 
<$$ $
DepartmentHistoryCommand$$ %
>$$% &
?$$& '
DepartmentHistories$$( ;
,$$; <
List%% 
<%% 
PayHistoryCommand%% 
>%% 
?%%  
PayHistories%%! -
)&& 
:&& 
ICommand&& 
<&& 
int&& 
>&& 
;&& 
}'' ‡o
ê/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateEmployee/UpdateEmployeeCommandDataValidator.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateEmployee2 @
{ 
public 

sealed 
class .
"UpdateEmployeeCommandDataValidator :
:; <
AbstractValidator= N
<N O!
UpdateEmployeeCommandO d
>d e
{ 
public .
"UpdateEmployeeCommandDataValidator 1
(1 2
)2 3
{ 	
RuleFor		 
(		 
employee		 
=>		 
employee		  (
.		( )
BusinessEntityID		) 9
)		9 :
.

( )
GreaterThan

) 4
(

4 5
$num

5 6
)

6 7
.( )
WithMessage) 4
(4 5
$str5 w
)w x
;x y
RuleFor 
( 
employee 
=> 
employee  (
.( )
Title) .
). /
.( )
MaximumLength) 6
(6 7
$num7 8
)8 9
.9 :
WithMessage: E
(E F
$strF p
)p q
;q r
RuleFor 
( 
employee 
=> 
employee  (
.( )
	FirstName) 2
)2 3
.( )
NotEmpty) 1
(1 2
)2 3
.3 4
WithMessage4 ?
(? @
$str@ h
)h i
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$str	G Ä
)
Ä Å
;
Å Ç
RuleFor 
( 
employee 
=> 
employee  (
.( )
LastName) 1
)1 2
.( )
NotEmpty) 1
(1 2
)2 3
.3 4
WithMessage4 ?
(? @
$str@ g
)g h
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$strG 
)	 Ä
;
Ä Å
RuleFor 
( 
employee 
=> 
employee  (
.( )

MiddleName) 3
)3 4
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$str	G Å
)
Å Ç
;
Ç É
RuleFor 
( 
employee 
=> 
employee  (
.( )
Suffix) /
)/ 0
.( )
MaximumLength) 6
(6 7
$num7 9
)9 :
.: ;
WithMessage; F
(F G
$strG s
)s t
;t u
RuleFor 
( 
employee 
=> 
employee  (
.( )
EmailPromotion) 7
)7 8
.( )
Must) -
(- .

emailPromo. 8
=>9 ;

emailPromo< F
>=G I
$numJ K
&&L N

emailPromoO Y
<=Z \
$num] ^
)^ _
.  ( )
WithMessage  ) 4
(  4 5
$str  5 ^
)  ^ _
;  _ `
RuleFor"" 
("" 
employee"" 
=>"" 
employee""  (
.""( )
NationalIDNumber"") 9
)""9 :
.##( )
NotEmpty##) 1
(##1 2
)##2 3
.##3 4
WithMessage##4 ?
(##? @
$str##@ `
)##` a
.$$( )
Matches$$) 0
($$0 1
$str$$1 <
)$$< =
.$$= >
WithMessage$$> I
($$I J
$str	$$J ì
)
$$ì î
.%%( )
MinimumLength%%) 6
(%%6 7
$num%%7 8
)%%8 9
.%%9 :
WithMessage%%: E
(%%E F
$str%%F w
)%%w x
.&&( )
MaximumLength&&) 6
(&&6 7
$num&&7 8
)&&8 9
.&&9 :
WithMessage&&: E
(&&E F
$str&&F v
)&&v w
;&&w x
RuleFor(( 
((( 
employee(( 
=>(( 
employee((  (
.((( )
LoginID(() 0
)((0 1
.))( )
NotEmpty))) 1
())1 2
)))2 3
.))3 4
WithMessage))4 ?
())? @
$str))@ c
)))c d
.**( )
MaximumLength**) 6
(**6 7
$num**7 9
)**9 :
.**: ;
WithMessage**; F
(**F G
$str**G |
)**| }
;**} ~
RuleFor,, 
(,, 
employee,, 
=>,, 
employee,,  (
.,,( )
JobTitle,,) 1
),,1 2
.--( )
NotEmpty--) 1
(--1 2
)--2 3
.--3 4
WithMessage--4 ?
(--? @
$str--@ g
)--g h
...( )
MaximumLength..) 6
(..6 7
$num..7 9
)..9 :
...: ;
WithMessage..; F
(..F G
$str..G 
)	.. Ä
;
..Ä Å
RuleFor00 
(00 
employee00 
=>00 
employee00  (
.00( )
	BirthDate00) 2
)002 3
.11( )
NotEmpty11) 1
(111 2
)112 3
.113 4
WithMessage114 ?
(11? @
$str11@ b
)11b c
.22( ) 
GreaterThanOrEqualTo22) =
(22= >
new22> A
DateTime22B J
(22J K
$num22K O
,22O P
$num22Q R
,22R S
$num22T U
,22U V
$num22W X
,22X Y
$num22Z [
,22[ \
$num22] ^
,22^ _
DateTimeKind22` l
.22l m
Local22m r
)22r s
)22s t
.22t u
WithMessage	22u Ä
(
22Ä Å
$str
22Å ´
)
22´ ¨
.33( )
LessThanOrEqualTo33) :
(33: ;
DateTime33; C
.33C D
Now33D G
.33G H
AddYears33H P
(33P Q
-33Q R
$num33R T
)33T U
)33U V
.33V W
WithMessage33W b
(33b c
$str	33c å
)
33å ç
;
33ç é
RuleFor55 
(55 
employee55 
=>55 
employee55  (
.55( )
MaritalStatus55) 6
)556 7
.66( )
NotEmpty66) 1
(661 2
)662 3
.663 4
WithMessage664 ?
(66? @
$str66@ f
)66f g
.77( )
Must77) -
(77- .
status77. 4
=>775 7
string778 >
.77> ?
Equals77? E
(77E F
status77F L
,77L M
$str77N Q
,77Q R
StringComparison77S c
.77c d$
CurrentCultureIgnoreCase77d |
)77| }
||	77~ Ä
string888 >
.88> ?
Equals88? E
(88E F
status88F L
,88L M
$str88N Q
,88Q R
StringComparison88S c
.88c d
OrdinalIgnoreCase88d u
)88u v
)88v w
.99( )
WithMessage99) 4
(994 5
$str995 l
)99l m
;99m n
RuleFor;; 
(;; 
employee;; 
=>;; 
employee;;  (
.;;( )
Gender;;) /
);;/ 0
.<<( )
NotEmpty<<) 1
(<<1 2
)<<2 3
.<<3 4
WithMessage<<4 ?
(<<? @
$str<<@ ^
)<<^ _
.==( )
Must==) -
(==- .
gender==. 4
=>==5 7
string==8 >
.==> ?
Equals==? E
(==E F
gender==F L
,==L M
$str==N Q
,==Q R
StringComparison==S c
.==c d
OrdinalIgnoreCase==d u
)==u v
||==w y
string>>8 >
.>>> ?
Equals>>? E
(>>E F
gender>>F L
,>>L M
$str>>N Q
,>>Q R
StringComparison>>S c
.>>c d
OrdinalIgnoreCase>>d u
)>>u v
)>>v w
.??( )
WithMessage??) 4
(??4 5
$str??5 a
)??a b
;??b c
RuleForAA 
(AA 
employeeAA 
=>AA 
employeeAA  (
.AA( )
HireDateAA) 1
)AA1 2
.BB( )
NotEmptyBB) 1
(BB1 2
)BB2 3
.BB3 4
WithMessageBB4 ?
(BB? @
$strBB@ a
)BBa b
.CC( )
MustCC) -
(CC- .
hireDateCC. 6
=>CC7 9
hireDateCC: B
>=CCC E
newCCF I
DateTimeCCJ R
(CCR S
$numCCS W
,CCW X
$numCCY Z
,CCZ [
$numCC\ ]
,CC] ^
$numCC_ `
,CC` a
$numCCb c
,CCc d
$numCCe f
,CCf g
DateTimeKindCCh t
.CCt u
LocalCCu z
)CCz {
)CC{ |
.DD( )
WithMessageDD) 4
(DD4 5
$strDD5 b
)DDb c
;DDc d
RuleForFF 
(FF 
employeeFF 
=>FF 
employeeFF  (
.FF( )
VacationHoursFF) 6
)FF6 7
.GG( )
MustGG) -
(GG- .
vacationGG. 6
=>GG7 9
vacationGG: B
>=GGC E
-GGF G
$numGGG I
&&GGJ L
vacationGGM U
<=GGV X
$numGGY \
)GG\ ]
.HH( )
WithMessageHH) 4
(HH4 5
$strHH5 l
)HHl m
;HHm n
RuleForJJ 
(JJ 
employeeJJ 
=>JJ 
employeeJJ  (
.JJ( )
SickLeaveHoursJJ) 7
)JJ7 8
.KK( )
MustKK) -
(KK- .
	sickleaveKK. 7
=>KK8 :
	sickleaveKK; D
>=KKE G
$numKKH I
&&KKJ L
	sickleaveKKM V
<=KKW Y
$numKKZ ]
)KK] ^
.LL( )
WithMessageLL) 4
(LL4 5
$strLL5 d
)LLd e
;LLe f
RuleForNN 
(NN 
employeeNN 
=>NN 
employeeNN  (
.NN( )
ActiveNN) /
)NN/ 0
.OO( )
MustOO) -
(OO- .
statusOO. 4
=>OO5 7
statusOO8 >
)OO> ?
.PP( )
WithMessagePP) 4
(PP4 5
$strPP5 c
)PPc d
;PPd e
RuleForRR 
(RR 
employeeRR 
=>RR 
employeeRR  (
.RR( )
	ManagerIDRR) 2
)RR2 3
.SS( )
GreaterThanSS) 4
(SS4 5
$numSS5 6
)SS6 7
.TT( )
WithMessageTT) 4
(TT4 5
$strTT5 P
)TTP Q
;TTQ R
RuleForVV 
(VV 
employeeVV 
=>VV 
employeeVV  (
.VV( )
AddressLine1VV) 5
)VV5 6
.WW( )
NotEmptyWW) 1
(WW1 2
)WW2 3
.WW3 4
WithMessageWW4 ?
(WW? @
$strWW@ c
)WWc d
.XX( )
MaximumLengthXX) 6
(XX6 7
$numXX7 9
)XX9 :
.XX: ;
WithMessageXX; F
(XXF G
$strXXG y
)XXy z
;XXz {
RuleForZZ 
(ZZ 
employeeZZ 
=>ZZ 
employeeZZ  (
.ZZ( )
AddressLine2ZZ) 5
)ZZ5 6
.[[( )
MaximumLength[[) 6
([[6 7
$num[[7 9
)[[9 :
.[[: ;
WithMessage[[; F
([[F G
$str[[G y
)[[y z
;[[z {
RuleFor]] 
(]] 
employee]] 
=>]] 
employee]]  (
.]]( )
City]]) -
)]]- .
.^^( )
NotEmpty^^) 1
(^^1 2
)^^2 3
.^^3 4
WithMessage^^4 ?
(^^? @
$str^^@ ^
)^^^ _
.__( )
MaximumLength__) 6
(__6 7
$num__7 9
)__9 :
.__: ;
WithMessage__; F
(__F G
$str__G v
)__v w
;__w x
RuleForaa 
(aa 
employeeaa 
=>aa 
employeeaa  (
.aa( )
StateProvinceIDaa) 8
)aa8 9
.bb( )
GreaterThanbb) 4
(bb4 5
$numbb5 6
)bb6 7
.cc( )
WithMessagecc) 4
(cc4 5
$strcc5 S
)ccS T
;ccT U
RuleForee 
(ee 
employeeee 
=>ee 
employeeee  (
.ee( )

PostalCodeee) 3
)ee3 4
.ff( )
NotEmptyff) 1
(ff1 2
)ff2 3
.ff3 4
WithMessageff4 ?
(ff? @
$strff@ `
)ff` a
.gg( )
MaximumLengthgg) 6
(gg6 7
$numgg7 9
)gg9 :
.gg: ;
WithMessagegg; F
(ggF G
$strggG v
)ggv w
;ggw x
RuleForii 
(ii 
employeeii 
=>ii 
employeeii  (
.ii( )
EmailAddressii) 5
)ii5 6
.ii6 7
EmailAddressii7 C
(iiC D
)iiD E
;iiE F
RuleForkk 
(kk 
employeekk 
=>kk 
employeekk  (
.kk( )
PhoneNumberkk) 4
)kk4 5
.kk5 6
Matcheskk6 =
(kk= >
$str	kk> ò
)
kkò ô
;
kkô ö
RuleFormm 
(mm 
employeemm 
=>mm 
employeemm  (
.mm( )
PhoneNumberTypeIDmm) :
)mm: ;
.nn( )
Mustnn) -
(nn- .
phTypenn. 4
=>nn5 7
phTypenn8 >
>=nn? A
$numnnB C
&&nnD F
phTypennG M
<=nnN P
$numnnQ R
)nnR S
.oo( )
WithMessageoo) 4
(oo4 5
$stroo5 s
)oos t
;oot u
}pp 	
}qq 
}rr ª 
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/UpdateEmployee/UpdateEmployeeCommandHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
UpdateEmployee2 @
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
 (
UpdateEmployeeCommandHandler

 4
:

5 6
ICommandHandler

7 F
<

F G!
UpdateEmployeeCommand

G \
,

\ ]
int

^ a
>

a b
{ 
private 
const 
int 
RETURN_VALUE &
=' (
$num) *
;* +
private 
readonly #
IWriteRepositoryManager 0
_repo1 6
;6 7
private 
readonly 
IMapper  
_mapper! (
;( )
public (
UpdateEmployeeCommandHandler +
(+ ,#
IWriteRepositoryManager, C
repoD H
,H I
IMapperJ Q
mapperR X
)X Y
=> 
( 
_repo 
, 
_mapper 
) 
=  !
(" #
repo# '
,' (
mapper) /
)/ 0
;0 1
public 
async 
Task 
< 
Result  
<  !
int! $
>$ %
>% &
Handle' -
(- .!
UpdateEmployeeCommand. C
commandD K
,K L
CancellationTokenM ^
cancellationToken_ p
)p q
{ 	
try 
{ 
Result 
< 
Employee 
>   
employeeDomainObject! 5
=6 7%
BuildEmployeeDomainObject8 Q
.Q R
BuildR W
(W X
commandX _
,_ `
_mappera h
)h i
;i j
if 
(  
employeeDomainObject (
.( )
	IsFailure) 2
)2 3
return 
Result !
<! "
int" %
>% &
.& '
Failure' .
<. /
int/ 2
>2 3
(3 4
new4 7
Error8 =
(= >
$str> c
,c d 
employeeDomainObjecte y
.y z
Errorz 
.	 Ä
Message
Ä á
)
á à
)
à â
;
â ä
Result 
< 
int 
> 
updateDbResult *
=+ ,
await- 2
_repo3 8
.8 9'
EmployeeAggregateRepository9 T
.T U
UpdateU [
([ \ 
employeeDomainObject\ p
.p q
Valueq v
)v w
;w x
if 
( 
updateDbResult "
." #
	IsFailure# ,
), -
return 
Result !
<! "
int" %
>% &
.& '
Failure' .
<. /
int/ 2
>2 3
(3 4
new4 7
Error8 =
(= >
$str> c
,c d
updateDbResulte s
.s t
Errort y
.y z
Message	z Å
)
Å Ç
)
Ç É
;
É Ñ
return!! 
RETURN_VALUE!! #
;!!# $
}## 
catch$$ 
($$ 
	Exception$$ 
ex$$ 
)$$  
{%% 
return&& 
Result&& 
<&& 
int&& !
>&&! "
.&&" #
Failure&&# *
<&&* +
int&&+ .
>&&. /
(&&/ 0
new&&0 3
Error&&4 9
(&&9 :
$str&&: _
,&&_ `
Helpers&&a h
.&&h i
GetExceptionMessage&&i |
(&&| }
ex&&} 
)	&& Ä
)
&&Ä Å
)
&&Å Ç
;
&&Ç É
}'' 
}(( 	
})) 
}** †
ü/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDepartments/GetCompanyDepartmentsFilteredQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2"
ViewCompanyDepartments2 H
{ 
public 

sealed 
class 5
)GetCompanyDepartmentsFilteredQueryHandler A
:B C
IQueryHandlerD Q
<Q R0
$GetCompanyDepartmentsFilteredRequestR v
,v w
	PagedList	x Å
<
Å Ç
DepartmentDetails
Ç ì
>
ì î
>
î ï
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public 5
)GetCompanyDepartmentsFilteredQueryHandler 8
(8 9"
IReadRepositoryManager9 O
repoP T
)T U
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
	PagedList! *
<* +
DepartmentDetails+ <
>< =
>= >
>> ?
Handle@ F
( 	0
$GetCompanyDepartmentsFilteredRequest 0
request1 8
,8 9
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
	PagedList  
<  !
DepartmentDetails! 2
>2 3
>3 4
result5 ;
=< =
await 
_repo 
.  !
CompanyReadRepository  5
.5 6)
GetCompanyDepartmentsFiltered6 S
(S T
requestT [
.[ \
SearchCriteria\ j
)j k
;k l
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
	PagedList" +
<+ ,
DepartmentDetails, =
>= >
>> ?
.? @
Failure@ G
<G H
	PagedListH Q
<Q R
DepartmentDetailsR c
>c d
>d e
(e f
new 
Error !
(! "
$str" T
,T U
resultV \
.\ ]
Error] b
.b c
Messagec j
)j k
) 
; 
} 
return!! 
result!! 
.!! 
Value!! #
;!!# $
}## 
catch$$ 
($$ 
	Exception$$ 
ex$$ 
)$$  
{%% 
return&& 
Result&& 
<&& 
	PagedList&& '
<&&' (
DepartmentDetails&&( 9
>&&9 :
>&&: ;
.&&; <
Failure&&< C
<&&C D
	PagedList&&D M
<&&M N
DepartmentDetails&&N _
>&&_ `
>&&` a
(&&a b
new'' 
Error'' 
('' 
$str'' P
,''P Q
Helpers''R Y
.''Y Z
GetExceptionMessage''Z m
(''m n
ex''n p
)''p q
)''q r
)(( 
;(( 
})) 
}** 	
}++ 
},, ˝
ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDepartments/GetCompanyDepartmentsFilteredRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2"
ViewCompanyDepartments2 H
{ 
public 

sealed 
record 0
$GetCompanyDepartmentsFilteredRequest =
(= > 
StringSearchCriteria> R
SearchCriteriaS a
)a b
:c d
IQuerye k
<k l
	PagedListl u
<u v
DepartmentDetails	v á
>
á à
>
à â
;
â ä
} Ó
ó/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDepartments/GetCompanyDepartmentsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2"
ViewCompanyDepartments2 H
{ 
public 

sealed 
class -
!GetCompanyDepartmentsQueryHandler 9
:: ;
IQueryHandler< I
<I J(
GetCompanyDepartmentsRequestJ f
,f g
	PagedListh q
<q r
DepartmentDetails	r É
>
É Ñ
>
Ñ Ö
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public -
!GetCompanyDepartmentsQueryHandler 0
(0 1"
IReadRepositoryManager1 G
repoH L
)L M
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
	PagedList! *
<* +
DepartmentDetails+ <
>< =
>= >
>> ?
Handle@ F
( 	(
GetCompanyDepartmentsRequest (
request) 0
,0 1
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
	PagedList  
<  !
DepartmentDetails! 2
>2 3
>3 4
result5 ;
=< =
await 
_repo 
.  !
CompanyReadRepository  5
.5 6!
GetCompanyDepartments6 K
(K L
requestL S
.S T
PagingParametersT d
)d e
;e f
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
	PagedList" +
<+ ,
DepartmentDetails, =
>= >
>> ?
.? @
Failure@ G
<G H
	PagedListH Q
<Q R
DepartmentDetailsR c
>c d
>d e
(e f
new 
Error !
(! "
$str" L
,L M
resultN T
.T U
ErrorU Z
.Z [
Message[ b
)b c
) 
; 
}   
return"" 
result"" 
."" 
Value"" #
;""# $
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
return'' 
Result'' 
<'' 
	PagedList'' '
<''' (
DepartmentDetails''( 9
>''9 :
>'': ;
.''; <
Failure''< C
<''C D
	PagedList''D M
<''M N
DepartmentDetails''N _
>''_ `
>''` a
(''a b
new(( 
Error(( 
((( 
$str(( H
,((H I
Helpers((J Q
.((Q R
GetExceptionMessage((R e
(((e f
ex((f h
)((h i
)((i j
))) 
;)) 
}** 
}++ 	
},, 
}-- Â
í/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDepartments/GetCompanyDepartmentsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2"
ViewCompanyDepartments2 H
{ 
public 

sealed 
record (
GetCompanyDepartmentsRequest 5
(5 6
PagingParameters6 F
PagingParametersG W
)W X
:Y Z
IQuery[ a
<a b
	PagedListb k
<k l
DepartmentDetailsl }
>} ~
>~ 
;	 Ä
} è
£/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDepartments/GetCompanyDepartmentsSearchByNameQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2"
ViewCompanyDepartments2 H
{ 
public 

sealed 
class 9
-GetCompanyDepartmentsSearchByNameQueryHandler E
:F G
IQueryHandlerH U
<U V4
(GetCompanyDepartmentsSearchByNameRequestV ~
,~ 
	PagedList
Ä â
<
â ä
DepartmentDetails
ä õ
>
õ ú
>
ú ù
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public 9
-GetCompanyDepartmentsSearchByNameQueryHandler <
(< ="
IReadRepositoryManager= S
repoT X
)X Y
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
	PagedList! *
<* +
DepartmentDetails+ <
>< =
>= >
>> ?
Handle@ F
( 	4
(GetCompanyDepartmentsSearchByNameRequest 4
request5 <
,< =
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
	PagedList  
<  !
DepartmentDetails! 2
>2 3
>3 4
result5 ;
=< =
await 
_repo 
.  !
CompanyReadRepository  5
.5 6-
!GetCompanyDepartmentsSearchByName6 W
(W X
requestX _
._ `
DepartmentName` n
,n o
requestp w
.w x
PagingParameters	x à
)
à â
;
â ä
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
	PagedList" +
<+ ,
DepartmentDetails, =
>= >
>> ?
.? @
Failure@ G
<G H
	PagedListH Q
<Q R
DepartmentDetailsR c
>c d
>d e
(e f
new 
Error !
(! "
$str" X
,X Y
resultZ `
.` a
Errora f
.f g
Messageg n
)n o
) 
; 
}   
return"" 
result"" 
."" 
Value"" #
;""# $
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
return'' 
Result'' 
<'' 
	PagedList'' '
<''' (
DepartmentDetails''( 9
>''9 :
>'': ;
.''; <
Failure''< C
<''C D
	PagedList''D M
<''M N
DepartmentDetails''N _
>''_ `
>''` a
(''a b
new(( 
Error(( 
((( 
$str(( T
,((T U
Helpers((V ]
.((] ^
GetExceptionMessage((^ q
(((q r
ex((r t
)((t u
)((u v
))) 
;)) 
}** 
}++ 	
},, 
}--  
û/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDepartments/GetCompanyDepartmentsSearchByNameRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2"
ViewCompanyDepartments2 H
{ 
public 

sealed 
record 4
(GetCompanyDepartmentsSearchByNameRequest A
(A B
stringB H
DepartmentNameI W
,W X
PagingParametersY i
PagingParametersj z
)z {
:| }
IQuery	~ Ñ
<
Ñ Ö
	PagedList
Ö é
<
é è
DepartmentDetails
è †
>
† °
>
° ¢
;
¢ £
} Î
è/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDetails/GetCompanyCommandQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewCompanyDetails2 D
{ 
public 

sealed 
class )
GetCompanyCommandQueryHandler 5
:6 7
IQueryHandler8 E
<E F$
GetCompanyCommandRequestF ^
,^ _!
CompanyGenericCommand` u
>u v
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public )
GetCompanyCommandQueryHandler ,
(, -"
IReadRepositoryManager- C
repoD H
)H I
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !!
CompanyGenericCommand! 6
>6 7
>7 8
Handle9 ?
( 	$
GetCompanyCommandRequest $
request% ,
,, -
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< !
CompanyGenericCommand ,
>, -
result. 4
=5 6
await7 <
_repo= B
.B C!
CompanyReadRepositoryC X
.X Y
GetCompanyCommandY j
(j k
requestk r
.r s
	CompanyIDs |
)| }
;} ~
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "!
CompanyGenericCommand" 7
>7 8
.8 9
Failure9 @
<@ A!
CompanyGenericCommandA V
>V W
(W X
new 
Error !
(! "
$str" H
,H I
resultJ P
.P Q
ErrorQ V
.V W
MessageW ^
)^ _
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% !
CompanyGenericCommand%% 3
>%%3 4
.%%4 5
Failure%%5 <
<%%< =!
CompanyGenericCommand%%= R
>%%R S
(%%S T
new&& 
Error&& 
(&& 
$str&& D
,&&D E
Helpers&&F M
.&&M N
GetExceptionMessage&&N a
(&&a b
ex&&b d
)&&d e
)&&e f
)'' 
;'' 
}(( 
})) 	
}** 
}++ è
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDetails/GetCompanyCommandRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewCompanyDetails2 D
{ 
public 

sealed 
record $
GetCompanyCommandRequest 1
(1 2
int2 5
	CompanyID6 ?
)? @
:A B
IQueryC I
<I J!
CompanyGenericCommandJ _
>_ `
;` a
} ∫
è/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDetails/GetCompanyDetailsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewCompanyDetails2 D
{ 
public 

sealed 
class )
GetCompanyDetailsQueryHandler 5
:6 7
IQueryHandler8 E
<E F$
GetCompanyDetailsRequestF ^
,^ _
CompanyDetails` n
>n o
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public )
GetCompanyDetailsQueryHandler ,
(, -"
IReadRepositoryManager- C
repoD H
)H I
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
CompanyDetails! /
>/ 0
>0 1
Handle2 8
( 	$
GetCompanyDetailsRequest $
request% ,
,, -
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
CompanyDetails %
>% &
result' -
=. /
await0 5
_repo6 ;
.; <!
CompanyReadRepository< Q
.Q R
GetCompanyDetailsR c
(c d
requestd k
.k l
	CompanyIDl u
)u v
;v w
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
CompanyDetails" 0
>0 1
.1 2
Failure2 9
<9 :
CompanyDetails: H
>H I
(I J
new 
Error !
(! "
$str" G
,G H
resultI O
.O P
ErrorP U
.U V
MessageV ]
)] ^
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
CompanyDetails%% ,
>%%, -
.%%- .
Failure%%. 5
<%%5 6
CompanyDetails%%6 D
>%%D E
(%%E F
new&& 
Error&& 
(&& 
$str&& C
,&&C D
Helpers&&E L
.&&L M
GetExceptionMessage&&M `
(&&` a
ex&&a c
)&&c d
)&&d e
)'' 
;'' 
}(( 
})) 	
}** 
}++ à
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyDetails/GetCompanyDetailsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewCompanyDetails2 D
{ 
public 

sealed 
record $
GetCompanyDetailsRequest 1
(1 2
int2 5
	CompanyID6 ?
)? @
:A B
IQueryC I
<I J
CompanyDetailsJ X
>X Y
;Y Z
} ä
ç/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyShifts/GetCompanyShiftsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewCompanyShifts2 C
{ 
public 

class (
GetCompanyShiftsQueryHandler -
:. /
IQueryHandler0 =
<= >#
GetCompanyShiftsRequest> U
,U V
	PagedListW `
<` a
ShiftDetailsa m
>m n
>n o
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public (
GetCompanyShiftsQueryHandler +
(+ ,"
IReadRepositoryManager, B
repoC G
)G H
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
	PagedList! *
<* +
ShiftDetails+ 7
>7 8
>8 9
>9 :
Handle; A
( 	#
GetCompanyShiftsRequest #
request$ +
,+ ,
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
	PagedList  
<  !
ShiftDetails! -
>- .
>. /
result0 6
=7 8
await 
_repo 
.  !
CompanyReadRepository  5
.5 6
GetCompanyShifts6 F
(F G
requestG N
.N O
PagingParametersO _
)_ `
;` a
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
	PagedList" +
<+ ,
ShiftDetails, 8
>8 9
>9 :
.: ;
Failure; B
<B C
	PagedListC L
<L M
ShiftDetailsM Y
>Y Z
>Z [
([ \
new 
Error !
(! "
$str" G
,G H
resultI O
.O P
ErrorP U
.U V
MessageV ]
)] ^
) 
; 
}   
return"" 
result"" 
."" 
Value"" #
;""# $
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
return'' 
Result'' 
<'' 
	PagedList'' '
<''' (
ShiftDetails''( 4
>''4 5
>''5 6
.''6 7
Failure''7 >
<''> ?
	PagedList''? H
<''H I
ShiftDetails''I U
>''U V
>''V W
(''W X
new(( 
Error(( 
((( 
$str(( C
,((C D
Helpers((E L
.((L M
GetExceptionMessage((M `
(((` a
ex((a c
)((c d
)((d e
))) 
;)) 
}** 
}++ 	
},, 
}-- À
à/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewCompanyShifts/GetCompanyShiftsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewCompanyShifts2 C
{ 
public 

sealed 
record #
GetCompanyShiftsRequest 0
(0 1
PagingParameters1 A
PagingParametersB R
)R S
:T U
IQueryV \
<\ ]
	PagedList] f
<f g
ShiftDetailsg s
>s t
>t u
;u v
} û-
ë/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewEmployeeDetails/GetEmployeeCommandQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewEmployeeDetails2 E
{ 
public 

class *
GetEmployeeCommandQueryHandler /
:0 1
IQueryHandler2 ?
<? @%
GetEmployeeCommandRequest@ Y
,Y Z"
EmployeeGenericCommand[ q
>q r
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public *
GetEmployeeCommandQueryHandler -
(- ."
IReadRepositoryManager. D
repoE I
)I J
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !"
EmployeeGenericCommand! 7
>7 8
>8 9
Handle: @
( 	%
GetEmployeeCommandRequest %
request& -
,- .
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< "
EmployeeGenericCommand -
>- .
getGenericCommand/ @
=A B
await 
_repo 
.  "
EmployeeReadRepository  6
.6 7%
GetEmployeeGenericCommand7 P
(P Q
requestQ X
.X Y

EmployeeIDY c
)c d
;d e
if 
( 
getGenericCommand %
.% &
	IsFailure& /
)/ 0
{ 
return 
Result !
<! ""
EmployeeGenericCommand" 8
>8 9
.9 :
Failure: A
<A B"
EmployeeGenericCommandB X
>X Y
(Y Z
new 
Error !
(! "
$str" I
,I J
getGenericCommandK \
.\ ]
Error] b
.b c
Messagec j
)j k
) 
; 
} 
Result!! 
<!! 
List!! 
<!! 
PayHistoryCommand!! -
>!!- .
>!!. / 
getPayHistoryCommand!!0 D
=!!E F
await"" 
_repo"" 
.""  "
EmployeeReadRepository""  6
.""6 7!
GetPayHistoryCommands""7 L
(""L M
request""M T
.""T U

EmployeeID""U _
)""_ `
;""` a
if$$ 
($$  
getPayHistoryCommand$$ (
.$$( )
	IsFailure$$) 2
)$$2 3
{%% 
return&& 
Result&& !
<&&! ""
EmployeeGenericCommand&&" 8
>&&8 9
.&&9 :
Failure&&: A
<&&A B"
EmployeeGenericCommand&&B X
>&&X Y
(&&Y Z
new'' 
Error'' !
(''! "
$str''" I
,''I J 
getPayHistoryCommand''K _
.''_ `
Error''` e
.''e f
Message''f m
)''m n
)(( 
;(( 
})) 
getGenericCommand++ !
.++! "
Value++" '
.++' (
PayHistories++( 4
=++5 6
new++7 :
(++: ; 
getPayHistoryCommand++; O
.++O P
Value++P U
.++U V
ToList++V \
(++\ ]
)++] ^
)++^ _
;++_ `
Result-- 
<-- 
List-- 
<-- $
DepartmentHistoryCommand-- 4
>--4 5
>--5 6'
getDepartmentHistoryCommand--7 R
=--S T
await.. 
_repo.. 
...  "
EmployeeReadRepository..  6
...6 7(
GetDepartmentHistoryCommands..7 S
(..S T
$num..T V
)..V W
;..W X
if00 
(00 '
getDepartmentHistoryCommand00 /
.00/ 0
	IsFailure000 9
)009 :
{11 
return22 
Result22 !
<22! ""
EmployeeGenericCommand22" 8
>228 9
.229 :
Failure22: A
<22A B"
EmployeeGenericCommand22B X
>22X Y
(22Y Z
new33 
Error33 !
(33! "
$str33" I
,33I J'
getDepartmentHistoryCommand33K f
.33f g
Error33g l
.33l m
Message33m t
)33t u
)44 
;44 
}55 
getGenericCommand77 !
.77! "
Value77" '
.77' (
DepartmentHistories77( ;
=77< =
new77> A
(77A B'
getDepartmentHistoryCommand77B ]
.77] ^
Value77^ c
.77c d
ToList77d j
(77j k
)77k l
)77l m
;77m n
return99 
getGenericCommand99 (
.99( )
Value99) .
;99. /
};; 
catch<< 
(<< 
	Exception<< 
ex<< 
)<<  
{== 
return>> 
Result>> 
<>> "
EmployeeGenericCommand>> 4
>>>4 5
.>>5 6
Failure>>6 =
<>>= >"
EmployeeGenericCommand>>> T
>>>T U
(>>U V
new?? 
Error?? 
(?? 
$str?? E
,??E F
Helpers??G N
.??N O
GetExceptionMessage??O b
(??b c
ex??c e
)??e f
)??f g
)@@ 
;@@ 
}AA 
}BB 	
}CC 
}DD ï
å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewEmployeeDetails/GetEmployeeCommandRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewEmployeeDetails2 E
{ 
public 

sealed 
record %
GetEmployeeCommandRequest 2
(2 3
int3 6

EmployeeID7 A
)A B
:C D
IQueryE K
<K L"
EmployeeGenericCommandL b
>b c
;c d
} é
å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewEmployeeDetails/GetEmployeeDetailsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewEmployeeDetails2 E
{ 
public 

sealed 
record %
GetEmployeeDetailsRequest 2
(2 3
int3 6

EmployeeID7 A
)A B
:C D
IQueryE K
<K L
EmployeeDetailsL [
>[ \
;\ ]
} —,
ò/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewEmployeeDetails/GetEmployeeDetailsRequestQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewEmployeeDetails2 E
{ 
public 

sealed 
class 1
%GetEmployeeDetailsRequestQueryHandler =
:> ?
IQueryHandler@ M
<M N%
GetEmployeeDetailsRequestN g
,g h
EmployeeDetailsi x
>x y
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public 1
%GetEmployeeDetailsRequestQueryHandler 4
(4 5"
IReadRepositoryManager5 K
repoL P
)P Q
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
EmployeeDetails! 0
>0 1
>1 2
Handle3 9
( 	%
GetEmployeeDetailsRequest %
request& -
,- .
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
EmployeeDetails &
>& '
getEmployeeDetails( :
=; <
await 
_repo 
.  "
EmployeeReadRepository  6
.6 7
GetEmployeeDetails7 I
(I J
requestJ Q
.Q R

EmployeeIDR \
)\ ]
;] ^
if 
( 
getEmployeeDetails &
.& '
	IsFailure' 0
)0 1
{ 
return 
Result !
<! "
EmployeeDetails" 1
>1 2
.2 3
Failure3 :
<: ;
EmployeeDetails; J
>J K
(K L
new 
Error !
(! "
$str" P
,P Q
getEmployeeDetailsR d
.d e
Errore j
.j k
Messagek r
)r s
) 
; 
} 
Result!! 
<!! 
List!! 
<!! 

PayHistory!! &
>!!& '
>!!' (
getPayHistory!!) 6
=!!7 8
await"" 
_repo"" 
.""  "
EmployeeReadRepository""  6
.""6 7
GetPayHistories""7 F
(""F G
request""G N
.""N O

EmployeeID""O Y
)""Y Z
;""Z [
if$$ 
($$ 
getPayHistory$$ !
.$$! "
	IsFailure$$" +
)$$+ ,
{%% 
return&& 
Result&& !
<&&! "
EmployeeDetails&&" 1
>&&1 2
.&&2 3
Failure&&3 :
<&&: ;
EmployeeDetails&&; J
>&&J K
(&&K L
new'' 
Error'' !
(''! "
$str''" P
,''P Q
getPayHistory''R _
.''_ `
Error''` e
.''e f
Message''f m
)''m n
)(( 
;(( 
})) 
getEmployeeDetails++ "
.++" #
Value++# (
.++( )
PayHistories++) 5
=++6 7
new++8 ;
(++; <
getPayHistory++< I
.++I J
Value++J O
.++O P
ToList++P V
(++V W
)++W X
)++X Y
;++Y Z
Result-- 
<-- 
List-- 
<-- 
DepartmentHistory-- -
>--- .
>--. / 
getDepartmentHistory--0 D
=--E F
await.. 
_repo.. 
...  "
EmployeeReadRepository..  6
...6 7"
GetDepartmentHistories..7 M
(..M N
request..N U
...U V

EmployeeID..V `
)..` a
;..a b
if00 
(00  
getDepartmentHistory00 (
.00( )
	IsFailure00) 2
)002 3
{11 
return22 
Result22 !
<22! "
EmployeeDetails22" 1
>221 2
.222 3
Failure223 :
<22: ;
EmployeeDetails22; J
>22J K
(22K L
new33 
Error33 !
(33! "
$str33" P
,33P Q 
getDepartmentHistory33R f
.33f g
Error33g l
.33l m
Message33m t
)33t u
)44 
;44 
}55 
getEmployeeDetails77 "
.77" #
Value77# (
.77( )
DepartmentHistories77) <
=77= >
new77? B
(77B C 
getDepartmentHistory77C W
.77W X
Value77X ]
.77] ^
ToList77^ d
(77d e
)77e f
)77f g
;77g h
return99 
getEmployeeDetails99 )
.99) *
Value99* /
;99/ 0
};; 
catch<< 
(<< 
	Exception<< 
ex<< 
)<<  
{== 
return>> 
Result>> 
<>> 
EmployeeDetails>> -
>>>- .
.>>. /
Failure>>/ 6
<>>6 7
EmployeeDetails>>7 F
>>>F G
(>>G H
new?? 
Error?? 
(?? 
$str?? L
,??L M
Helpers??N U
.??U V
GetExceptionMessage??V i
(??i j
ex??j l
)??l m
)??m n
)@@ 
;@@ 
}AA 
}BB 	
}CC 
}DD ﬁ
ç/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewEmployees/GetEmployeeListItemsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewEmployees2 ?
{ 
public 

sealed 
class ,
 GetEmployeeListItemsQueryHandler 8
:9 :
IQueryHandler; H
<H I'
GetEmployeeListItemsRequestI d
,d e
	PagedListf o
<o p
EmployeeListItem	p Ä
>
Ä Å
>
Å Ç
{		 
private

 
readonly

 "
IReadRepositoryManager

 /
_repo

0 5
;

5 6
public ,
 GetEmployeeListItemsQueryHandler /
(/ 0"
IReadRepositoryManager0 F
repoG K
)K L
=> 
_repo 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
	PagedList! *
<* +
EmployeeListItem+ ;
>; <
>< =
>= >
Handle? E
( 	'
GetEmployeeListItemsRequest '
request( /
,/ 0
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
	PagedList  
<  !
EmployeeListItem! 1
>1 2
>2 3
result4 :
=; <
await 
_repo 
.  "
EmployeeReadRepository  6
.6 70
$GetEmployeeListItemsSearchByLastName7 [
([ \
request\ c
.c d
SearchCriteriad r
)r s
;s t
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
	PagedList" +
<+ ,
EmployeeListItem, <
>< =
>= >
.> ?
Failure? F
<F G
	PagedListG P
<P Q
EmployeeListItemQ a
>a b
>b c
(c d
new 
Error !
(! "
$str" L
,L M
resultN T
.T U
ErrorU Z
.Z [
Message[ b
)b c
) 
; 
}   
return"" 
result"" 
."" 
Value"" #
;""# $
}$$ 
catch%% 
(%% 
	Exception%% 
ex%% 
)%%  
{&& 
return'' 
Result'' 
<'' 
	PagedList'' '
<''' (
EmployeeListItem''( 8
>''8 9
>''9 :
.'': ;
Failure''; B
<''B C
	PagedList''C L
<''L M
EmployeeListItem''M ]
>''] ^
>''^ _
(''_ `
new(( 
Error(( 
((( 
$str(( G
,((G H
Helpers((I P
.((P Q
GetExceptionMessage((Q d
(((d e
ex((e g
)((g h
)((h i
))) 
;)) 
}** 
}++ 	
},, 
}-- “
à/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Features/HumanResources/ViewEmployees/GetEmployeeListItemsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Features "
." #
HumanResources# 1
.1 2
ViewEmployees2 ?
{ 
public 

sealed 
record '
GetEmployeeListItemsRequest 4
(4 5 
StringSearchCriteria5 I
SearchCriteriaJ X
)X Y
:Z [
IQuery\ b
<b c
	PagedListc l
<l m
EmployeeListItemm }
>} ~
>~ 
;	 Ä
}		 ·
l/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Interfaces/Messaging/CommandValidator.cs
	namespace 	
AWC
 
. 
Application 
. 

Interfaces $
.$ %
	Messaging% .
{ 
public 

abstract 
class 
CommandValidator *
<* +
TCommand+ 3
>3 4
:5 6
ICommandValidator7 H
<H I
TCommandI Q
>Q R
{ 
	protected 
ICommandValidator #
<# $
TCommand$ ,
>, -
?- .
Next/ 3
{4 5
get6 9
;9 :
private; B
setC F
;F G
}H I
public		 
void		 
SetNext		 
(		 
ICommandValidator		 -
<		- .
TCommand		. 6
>		6 7
next		8 <
)		< =
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
<! "
Result" (
>( )
Validate* 2
(2 3
TCommand3 ;
command< C
)C D
{ 	
if 
( 
Next 
is 
not 
null  
)  !
{ 
await 
Next 
. 
Validate #
(# $
command$ +
)+ ,
;, -
} 
return 
Result 
. 
Success !
(! "
)" #
;# $
} 	
} 
} ⁄
d/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Interfaces/Messaging/ICommand.cs
	namespace 	
AWC
 
. 
Application 
. 

Interfaces $
.$ %
	Messaging% .
;. /
public 
	interface 
ICommand 
: 
IRequest $
<$ %
Result% +
>+ ,
{ 
} 
public

 
	interface

 
ICommand

 
<

 
	TResponse

 #
>

# $
:

% &
IRequest

' /
<

/ 0
Result

0 6
<

6 7
	TResponse

7 @
>

@ A
>

A B
{ 
} ë	
k/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Interfaces/Messaging/ICommandHandler.cs
	namespace 	
AWC
 
. 
Application 
. 

Interfaces $
.$ %
	Messaging% .
;. /
public 
	interface 
ICommandHandler  
<  !
in! #
TCommand$ ,
>, -
:. /
IRequestHandler0 ?
<? @
TCommand@ H
,H I
ResultJ P
>P Q
where 	
TCommand
 
: 
ICommand 
{ 
}		 
public 
	interface 
ICommandHandler  
<  !
in! #
TCommand$ ,
,, -
	TResponse. 7
>7 8
:9 :
IRequestHandler; J
<J K
TCommandK S
,S T
ResultU [
<[ \
	TResponse\ e
>e f
>f g
where 	
TCommand
 
: 
ICommand 
< 
	TResponse '
>' (
{ 
} Ñ
m/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Interfaces/Messaging/ICommandValidator.cs
	namespace 	
AWC
 
. 
Application 
. 

Interfaces $
.$ %
	Messaging% .
{ 
public 

	interface 
ICommandValidator &
<& '
TCommand' /
>/ 0
:1 2
IRequest3 ;
<; <
TCommand< D
>D E
{ 
Task 
< 
Result 
> 
Validate 
( 
TCommand &
command' .
). /
;/ 0
void

 
SetNext

 
(

 
ICommandValidator

 &
<

& '
TCommand

' /
>

/ 0
next

1 5
)

5 6
;

6 7
} 
} ¶
b/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Interfaces/Messaging/IQuery.cs
	namespace 	
AWC
 
. 
Application 
. 

Interfaces $
.$ %
	Messaging% .
;. /
public 
	interface 
IQuery 
< 
	TResponse !
>! "
:# $
IRequest% -
<- .
Result. 4
<4 5
	TResponse5 >
>> ?
>? @
{ 
} ê
i/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Interfaces/Messaging/IQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 

Interfaces $
.$ %
	Messaging% .
;. /
public 
	interface 
IQueryHandler 
< 
in !
TQuery" (
,( )
	TResponse* 3
>3 4
:5 6
IRequestHandler7 F
<F G
TQueryG M
,M N
ResultO U
<U V
	TResponseV _
>_ `
>` a
where 	
TQuery
 
: 
IQuery 
< 
	TResponse #
># $
{ 
}		 À
ã/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/HumanResources/GetDepartmentIds/GetDepartmentIdsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
HumanResources" 0
.0 1
GetDepartmentIds1 A
{ 
public 

sealed 
class (
GetDepartmentIdsQueryHandler 4
:5 6
IQueryHandler7 D
<D E#
GetDepartmentIdsRequestE \
,\ ]
List^ b
<b c
DepartmentIdc o
>o p
>p q
{		 
private

 
readonly

 %
ILookupsRepositoryManager

 2
_repoMgr

3 ;
;

; <
public (
GetDepartmentIdsQueryHandler +
(+ ,%
ILookupsRepositoryManager, E
repoF J
)J K
=> 
_repoMgr 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
DepartmentId& 2
>2 3
>3 4
>4 5
Handle6 <
( 	#
GetDepartmentIdsRequest #
request$ +
,+ ,
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
List 
< 
DepartmentId (
>( )
>) *
result+ 1
=2 3
await4 9
_repoMgr: B
.B C+
HumanResourcesLookupsRepositoryC b
.b c
DepartmentIdsc p
(p q
)q r
;r s
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
List" &
<& '
DepartmentId' 3
>3 4
>4 5
.5 6
Failure6 =
<= >
List> B
<B C
DepartmentIdC O
>O P
>P Q
(Q R
new 
Error !
(! "
$str" G
,G H
resultI O
.O P
ErrorP U
.U V
MessageV ]
)] ^
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
List%% "
<%%" #
DepartmentId%%# /
>%%/ 0
>%%0 1
.%%1 2
Failure%%2 9
<%%9 :
List%%: >
<%%> ?
DepartmentId%%? K
>%%K L
>%%L M
(%%M N
new&& 
Error&& 
(&& 
$str&& C
,&&C D
Helpers&&E L
.&&L M
GetExceptionMessage&&M `
(&&` a
ex&&a c
)&&c d
)&&d e
)'' 
;'' 
}(( 
})) 	
}** 
}++ ﬁ
Ü/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/HumanResources/GetDepartmentIds/GetDepartmentIdsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
HumanResources" 0
.0 1
GetDepartmentIds1 A
{ 
public 

sealed 
record #
GetDepartmentIdsRequest 0
(0 1
int1 4$
SuppressSonarqubeWarning5 M
=N O
$numP Q
)Q R
:S T
IQueryU [
<[ \
List\ `
<` a
DepartmentIda m
>m n
>n o
;o p
} û
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/HumanResources/GetManagerIds/GetManagerIdsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
HumanResources" 0
.0 1
GetManagerIds1 >
{ 
public 

sealed 
class %
GetManagerIdsQueryHandler 1
:2 3
IQueryHandler4 A
<A B 
GetManagerIdsRequestB V
,V W
ListX \
<\ ]
	ManagerId] f
>f g
>g h
{		 
private

 
readonly

 %
ILookupsRepositoryManager

 2
_repoMgr

3 ;
;

; <
public %
GetManagerIdsQueryHandler (
(( )%
ILookupsRepositoryManager) B
repoC G
)G H
=> 
_repoMgr 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
	ManagerId& /
>/ 0
>0 1
>1 2
Handle3 9
( 	 
GetManagerIdsRequest  
request! (
,( )
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
List 
< 
	ManagerId %
>% &
>& '
result( .
=/ 0
await1 6
_repoMgr7 ?
.? @+
HumanResourcesLookupsRepository@ _
._ `

ManagerIds` j
(j k
)k l
;l m
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
List" &
<& '
	ManagerId' 0
>0 1
>1 2
.2 3
Failure3 :
<: ;
List; ?
<? @
	ManagerId@ I
>I J
>J K
(K L
new 
Error !
(! "
$str" D
,D E
resultF L
.L M
ErrorM R
.R S
MessageS Z
)Z [
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
List%% "
<%%" #
	ManagerId%%# ,
>%%, -
>%%- .
.%%. /
Failure%%/ 6
<%%6 7
List%%7 ;
<%%; <
	ManagerId%%< E
>%%E F
>%%F G
(%%G H
new&& 
Error&& 
(&& 
$str&& @
,&&@ A
Helpers&&B I
.&&I J
GetExceptionMessage&&J ]
(&&] ^
ex&&^ `
)&&` a
)&&a b
)'' 
;'' 
}(( 
})) 	
}** 
}++ œ
Ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/HumanResources/GetManagerIds/GetManagerIdsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
HumanResources" 0
.0 1
GetManagerIds1 >
{ 
public 

sealed 
record  
GetManagerIdsRequest -
(- .
int. 1$
SuppressSonarqubeWarning2 J
=K L
$numM N
)N O
:P Q
IQueryR X
<X Y
ListY ]
<] ^
	ManagerId^ g
>g h
>h i
;i j
} Ä
Å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/HumanResources/GetShiftIds/GetShiftIdsQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
HumanResources" 0
.0 1
GetShiftIds1 <
{ 
public 

sealed 
class #
GetShiftIdsQueryHandler /
:0 1
IQueryHandler2 ?
<? @
GetShiftIdsRequest@ R
,R S
ListT X
<X Y
ShiftIdY `
>` a
>a b
{		 
private

 
readonly

 %
ILookupsRepositoryManager

 2
_repoMgr

3 ;
;

; <
public #
GetShiftIdsQueryHandler &
(& '%
ILookupsRepositoryManager' @
repoA E
)E F
=> 
_repoMgr 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
ShiftId& -
>- .
>. /
>/ 0
Handle1 7
( 	
GetShiftIdsRequest 
request &
,& '
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
List 
< 
ShiftId #
># $
>$ %
result& ,
=- .
await/ 4
_repoMgr5 =
.= >+
HumanResourcesLookupsRepository> ]
.] ^
ShiftIds^ f
(f g
)g h
;h i
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
List" &
<& '
ShiftId' .
>. /
>/ 0
.0 1
Failure1 8
<8 9
List9 =
<= >
ShiftId> E
>E F
>F G
(G H
new 
Error !
(! "
$str" B
,B C
resultD J
.J K
ErrorK P
.P Q
MessageQ X
)X Y
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
List%% "
<%%" #
ShiftId%%# *
>%%* +
>%%+ ,
.%%, -
Failure%%- 4
<%%4 5
List%%5 9
<%%9 :
ShiftId%%: A
>%%A B
>%%B C
(%%C D
new&& 
Error&& 
(&& 
$str&& >
,&&> ?
Helpers&&@ G
.&&G H
GetExceptionMessage&&H [
(&&[ \
ex&&\ ^
)&&^ _
)&&_ `
)'' 
;'' 
}(( 
})) 	
}** 
}++ ƒ
|/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/HumanResources/GetShiftIds/GetShiftIdsRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
HumanResources" 0
.0 1
GetShiftIds1 <
{ 
public 

sealed 
record 
GetShiftIdsRequest +
(+ ,
int, /$
SuppressSonarqubeWarning0 H
=I J
$numK L
)L M
:N O
IQueryP V
<V W
ListW [
<[ \
ShiftId\ c
>c d
>d e
;e f
} ©
Å/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/Shared/GetCountryCodes/GetCountryCodesQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
Shared" (
.( )
GetCountryCodes) 8
{ 
public 

sealed 
class '
GetCountryCodesQueryHandler 3
:4 5
IQueryHandler6 C
<C D"
GetCountryCodesRequestD Z
,Z [
List\ `
<` a
CountryCodea l
>l m
>m n
{		 
private

 
readonly

 %
ILookupsRepositoryManager

 2
_repoMgr

3 ;
;

; <
public '
GetCountryCodesQueryHandler *
(* +%
ILookupsRepositoryManager+ D
repoE I
)I J
=> 
_repoMgr 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
CountryCode& 1
>1 2
>2 3
>3 4
Handle5 ;
( 	"
GetCountryCodesRequest "
request# *
,* +
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
List 
< 
CountryCode '
>' (
>( )
result* 0
=1 2
await3 8
_repoMgr9 A
.A B#
SharedLookupsRepositoryB Y
.Y Z
CountryRegionCodeZ k
(k l
)l m
;m n
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
List" &
<& '
CountryCode' 2
>2 3
>3 4
.4 5
Failure5 <
<< =
List= A
<A B
CountryCodeB M
>M N
>N O
(O P
new 
Error !
(! "
$str" F
,F G
resultH N
.N O
ErrorO T
.T U
MessageU \
)\ ]
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
List%% "
<%%" #
CountryCode%%# .
>%%. /
>%%/ 0
.%%0 1
Failure%%1 8
<%%8 9
List%%9 =
<%%= >
CountryCode%%> I
>%%I J
>%%J K
(%%K L
new&& 
Error&& 
(&& 
$str&& B
,&&B C
Helpers&&D K
.&&K L
GetExceptionMessage&&L _
(&&_ `
ex&&` b
)&&b c
)&&c d
)'' 
;'' 
}(( 
})) 	
}** 
}++ »
|/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/Shared/GetCountryCodes/GetCountryCodesRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
Shared" (
.( )
GetCountryCodes) 8
{ 
public 

sealed 
record "
GetCountryCodesRequest /
(/ 0
int0 3$
SuppressSonarqubeWarning4 L
=M N
$numO P
)P Q
:R S
IQueryT Z
<Z [
List[ _
<_ `
CountryCode` k
>k l
>l m
;m n
} π
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/Shared/GetStateCodesForAll/GetStateCodeIdForAllQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
Shared" (
.( )
GetStateCodesForAll) <
{ 
public 

sealed 
class ,
 GetStateCodeIdForAllQueryHandler 8
:9 :
IQueryHandler; H
<H I'
GetStateCodeIdForAllRequestI d
,d e
Listf j
<j k
	StateCodek t
>t u
>u v
{		 
private

 
readonly

 %
ILookupsRepositoryManager

 2
_repoMgr

3 ;
;

; <
public ,
 GetStateCodeIdForAllQueryHandler /
(/ 0%
ILookupsRepositoryManager0 I
repoJ N
)N O
=> 
_repoMgr 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
	StateCode& /
>/ 0
>0 1
>1 2
Handle3 9
( 	'
GetStateCodeIdForAllRequest '
request( /
,/ 0
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
List 
< 
	StateCode %
>% &
>& '
result( .
=/ 0
await1 6
_repoMgr7 ?
.? @#
SharedLookupsRepository@ W
.W X
StateCodeIdAllX f
(f g
)g h
;h i
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
List" &
<& '
	StateCode' 0
>0 1
>1 2
.2 3
Failure3 :
<: ;
List; ?
<? @
	StateCode@ I
>I J
>J K
(K L
new 
Error !
(! "
$str" K
,K L
resultM S
.S T
ErrorT Y
.Y Z
MessageZ a
)a b
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
List%% "
<%%" #
	StateCode%%# ,
>%%, -
>%%- .
.%%. /
Failure%%/ 6
<%%6 7
List%%7 ;
<%%; <
	StateCode%%< E
>%%E F
>%%F G
(%%G H
new&& 
Error&& 
(&& 
$str&& G
,&&G H
Helpers&&I P
.&&P Q
GetExceptionMessage&&Q d
(&&d e
ex&&e g
)&&g h
)&&h i
)'' 
;'' 
}(( 
})) 	
}** 
}++ Ÿ
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/Shared/GetStateCodesForAll/GetStateCodeIdForAllRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
Shared" (
.( )
GetStateCodesForAll) <
{ 
public 

sealed 
record '
GetStateCodeIdForAllRequest 4
(4 5
int5 8$
SuppressSonarqubeWarning9 Q
=R S
$numT U
)U V
:W X
IQueryY _
<_ `
List` d
<d e
	StateCodee n
>n o
>o p
;p q
} π
ä/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/Shared/GetStateCodesForUSA/GetStateCodeIdForUsaQueryHandler.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
Shared" (
.( )
GetStateCodesForUSA) <
{ 
public 

sealed 
class ,
 GetStateCodeIdForUsaQueryHandler 8
:9 :
IQueryHandler; H
<H I'
GetStateCodeIdForUsaRequestI d
,d e
Listf j
<j k
	StateCodek t
>t u
>u v
{		 
private

 
readonly

 %
ILookupsRepositoryManager

 2
_repoMgr

3 ;
;

; <
public ,
 GetStateCodeIdForUsaQueryHandler /
(/ 0%
ILookupsRepositoryManager0 I
repoJ N
)N O
=> 
_repoMgr 
= 
repo 
; 
public 
async 
Task 
< 
Result  
<  !
List! %
<% &
	StateCode& /
>/ 0
>0 1
>1 2
Handle3 9
( 	'
GetStateCodeIdForUsaRequest '
request( /
,/ 0
CancellationToken 
cancellationToken /
) 	
{ 	
try 
{ 
Result 
< 
List 
< 
	StateCode %
>% &
>& '
result( .
=/ 0
await1 6
_repoMgr7 ?
.? @#
SharedLookupsRepository@ W
.W X
StateCodeIdUSAX f
(f g
)g h
;h i
if 
( 
result 
. 
	IsFailure $
)$ %
{ 
return 
Result !
<! "
List" &
<& '
	StateCode' 0
>0 1
>1 2
.2 3
Failure3 :
<: ;
List; ?
<? @
	StateCode@ I
>I J
>J K
(K L
new 
Error !
(! "
$str" K
,K L
resultM S
.S T
ErrorT Y
.Y Z
MessageZ a
)a b
) 
; 
} 
return   
result   
.   
Value   #
;  # $
}"" 
catch## 
(## 
	Exception## 
ex## 
)##  
{$$ 
return%% 
Result%% 
<%% 
List%% "
<%%" #
	StateCode%%# ,
>%%, -
>%%- .
.%%. /
Failure%%/ 6
<%%6 7
List%%7 ;
<%%; <
	StateCode%%< E
>%%E F
>%%F G
(%%G H
new&& 
Error&& 
(&& 
$str&& G
,&&G H
Helpers&&I P
.&&P Q
GetExceptionMessage&&Q d
(&&d e
ex&&e g
)&&g h
)&&h i
)'' 
;'' 
}(( 
})) 	
}** 
}++ Ÿ
Ö/home/bthomas/Projects/NetCore/AdventureWorksCycles/src/Application/Lookups/Shared/GetStateCodesForUSA/GetStateCodeIdForUsaRequest.cs
	namespace 	
AWC
 
. 
Application 
. 
Lookups !
.! "
Shared" (
.( )
GetStateCodesForUSA) <
{ 
public 

sealed 
record '
GetStateCodeIdForUsaRequest 4
(4 5
int5 8$
SuppressSonarqubeWarning9 Q
=R S
$numT U
)U V
:W X
IQueryY _
<_ `
List` d
<d e
	StateCodee n
>n o
>o p
;p q
} 