async function getAll() {
    const r = await fetch('/api/Contacts');
    const d = await r.json();
    console.log(d);
}
async function get() {
    const r = await fetch('/api/Contacts/hila');
    const d = await r.json();
    console.log(d);
}

async function post() {
    const r = await fetch('/api/Contacts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name: 'hila', nickName: 'hilalosh', server: 'serve' })
    });
    console.log(r);
}
