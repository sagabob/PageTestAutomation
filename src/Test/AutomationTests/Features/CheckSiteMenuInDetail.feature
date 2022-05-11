Feature: CheckSiteMenuInDetail
	Full test to check all left hand side menu

@checkHousingPageComponents
Scenario Outline: Check Main Menu in Detail
	Given an input client alias with "<alias>"	
	When I go to their page	
	Then their site should be valid
	And it should have the menu
	| MenuText       |
	| Housing Demand |
	| Housing Supply |
	| Housing Consumption	|
	| Prices & Incomes	|
	| Housing Stress & Need	|
	| Affordability Monitor	|
	And sub-menu should work

Examples:
| alias                |
| albury               |
| baw-baw              |
| bass-coast           |
| broken-hill          |
| snowy-monaro         |
| knox                 |
| whittlesea           |
| glenorchy            |
| salisbury            |
| south-gippsland      |
| midcoast             |
| frankston            |
| bayside              |
| mornington-peninsula |
| cardinia             |
| townsville           |
| shoalhaven           |
| east-gippsland       |
| tamworth             |
| gunnedah             |
| coffs-harbour        |
| g21-region           |
