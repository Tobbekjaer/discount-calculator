Feature: Discount Calculator
As a business
I want to apply discounts based on customer type, order amount and season
So that customers are rewarded correctly

Scenario Outline: Calculate discount based on customer type, order amount and season
    Given a <customerType> customer
    And the current season is <season>
    When the order amount is <amount>
    Then the discount should be <discount>

Examples:
    | customerType | amount | season | discount |
    | Standard     |     99 | Other  |        0 |
    | Standard     |    100 | Other  |        5 |
    | Standard     |    500 | Other  |        5 |
    | Standard     |    501 | Other  |       10 |
    | Standard     |    100 | Summer |       10 |
    | Standard     |    501 | Winter |       15 |
    | Premium      |     99 | Other  |        5 |
    | Premium      |    100 | Other  |       15 |
    | Premium      |    500 | Summer |       20 |
    | Premium      |    501 | Other  |       20 |
    | Premium      |    501 | Winter |       25 |

Scenario: Negative order amount throws exception
    Given a Standard customer
    And the current season is Other
    When the order amount is -1
    Then an exception should be thrown