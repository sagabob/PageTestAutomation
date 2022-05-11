Feature: BrowseAllHousingSites
	Simply browse all housing sites

@browseHousingPageGeneric
Scenario Outline: From an input client
	Given a client with alias with "<alias>"	
	When I go to the page
	Then the page should be "<pageStatus>"

Examples:
| alias         | pageStatus |
| albury        | true       |
| bass-coast    | true       |
| baw-baw       | true       |
| fakealias     | false      |
| coffs-harbour | true       |
| gunnedah      | true       |
| shoalhaven    | true       |