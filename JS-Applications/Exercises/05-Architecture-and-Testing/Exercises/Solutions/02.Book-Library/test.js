const { chromium } = require('playwright-chromium');
const { assert } = require('chai');

let browser, page;

describe('tests', function () {
	before(async () => { browser = await chromium.launch(); });
	after(async () => { await browser.close(); });
	beforeEach(async () => { page = await browser.newPage(); });
	afterEach(async () => { await page.close(); });

	it('loads books', async function () {
		await page.goto('http://localhost:5500/');
		await page.click('text=LOAD ALL BOOKS');

		const text = await page.textContent('table tbody');

		assert.include(text, "Harry Potter and the Philosopher's Stone");
		assert.include(text, 'J.K.Rowling');
	});

	it('adds book', async function () {
		await page.goto('http://localhost:5500/');

		const author = 'author', title = 'title';

		await page.fill('input[name="title"]', title);
		await page.fill('input[name="author"]', author);
		await page.click('text=Submit');

		await page.click('text=LOAD ALL BOOKS');

		const text = await page.textContent('table tbody');

		assert.include(text, author);
		assert.include(text, title);
	});

	it('doesnt add book if there are empty fields', async function () {
		await page.goto('http://localhost:5500/');

		const author = 'newAuthor', title = 'newTitle';

		await page.fill('input[name="title"]', title);
		await page.fill('input[name="author"]', '');
		await page.click('text=Submit');

		await page.fill('input[name="title"]', '');
		await page.fill('input[name="author"]', author);
		await page.click('text=Submit');

		await page.click('text=LOAD ALL BOOKS');

		const text = await page.textContent('table tbody');

		assert.notInclude(text, author);
		assert.notInclude(text, title);
	});

	it('edits book', async function () {
		await page.goto('http://localhost:5500/');

		await page.click('text=LOAD ALL BOOKS')
		await page.click('tr:nth-child(2) >> .editBtn')

		const visible = await page.isVisible('#editForm');
		assert.isTrue(visible);

		const editTitle = "editedBook";
		const editAuthor = 'editedAuthor';

		await page.fill('#editForm input[name="title"]', editTitle);
		await page.fill('#editForm input[name="author"]', editAuthor);
		await page.click('text=Save');

		await page.click('text=LOAD ALL BOOKS');

		const content = await page.textContent('table tbody');
		
		assert.include(content, editTitle);
		assert.include(content, editAuthor);
	});

	it('delete book', async () => {
        await page.goto('http://localhost:5500');
        await Promise.all([
            page.click('text=LOAD ALL BOOKS'),
            page.click('.deleteBtn'),
            page.on('dialog', dialog => dialog.accept())
        ]);
        
        await page.click('text=LOAD ALL BOOKS');
        const content = await page.textContent('table tbody');
		assert.notInclude(content, 'J.K.Rowling');
    });
	
});
