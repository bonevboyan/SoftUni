const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser, page;

describe('tests', function () {
	before(async () => { browser = await chromium.launch(); });
	after(async () => { await browser.close(); });
	beforeEach(async () => { page = await browser.newPage(); });
	afterEach(async () => { await page.close(); });

	it('loads messages', async function () {
		await page.goto('http://localhost:5500/');
		await page.click('text=Refresh');

		await page.waitForSelector('text=Spami');

		const text = await page.$eval('textarea', el => el.value);

		assert.include(text, 'Spami: Hello, are you there?');
		assert.include(text, 'Yep, whats up :?');
		assert.include(text, 'How are you? Long time no see? :)');
		assert.include(text, 'Hello, guys! :))');
		assert.include(text, 'Hello, George nice to see you! :)))');
	});

	it('sends messages', async function () {
		await page.goto('http://localhost:5500/');

		const user = 'user', message = 'message';

		await page.fill('#author', user);
		await page.fill('#content', message);

		await page.click('text=Send');
		await page.click('text=Refresh');

		const text = await page.$eval('textarea', el => el.value);

		assert.include(text, `${user}: ${message}`);

	});
});
