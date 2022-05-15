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

async function del() {
    const r = await fetch('/api/Contacts/hila', {
        method: 'DELETE'
    });
    console.log(r);
}

async function put() {
    const r = await fetch('/api/Contacts/hila', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ name: 'hila', nickName: 'hilali', server: 'serve' })
    });
    console.log(r);
}