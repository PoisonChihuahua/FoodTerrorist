Feature('');

Scenario('test something', (I) => {
    I.amOnPage('http://localhost:5000/')
    I.fillField('#username', '田中')
    I.click('登録')
    I.click('Open Dialog')
    I.click('確認')
    I.click('どちらでもない')
    I.click('About')
});
