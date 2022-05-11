Feature: CheckSiteMenu
	Simple test to check all left hand side menu

@checkHousingPageComponents
Scenario Outline: Check Main Menu
	Given an input client alias like "<alias>"	
	When I go to their page to check	
	Then the site should be valid
	And it should have the menu and it works
	| MenuText       |
	| Housing Demand |
	| Housing Supply |
	| Housing Consumption	|
	| Prices & Incomes	|
	| Housing Stress & Need	|
	| Affordability Monitor	|
	And sub-menu should also work

Examples:
| alias  |
| albury |
|baw-baw| 
| bass-coast	| 
|broken-hill 		| 

