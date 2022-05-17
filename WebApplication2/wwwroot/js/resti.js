async function getAllContacts() {
    const r = await fetch('/api/userID/Contacts');
    const d = await r.json();
    console.log(d);
}
async function getContactData() {
    const r = await fetch('/api/userID/Contacts/hila');
    const d = await r.json();
    console.log(d);
}

async function getMesseges() {
    const r = await fetch('/api/userID/Contacts/hila/messeges');
    const d = await r.json();
    console.log(d);
}

async function getMessege() {
    const r = await fetch('/api/userID/Contacts/hila/messeges/1');
    const d = await r.json();
    console.log(d);
}

async function addContact() {
    const r = await fetch('/api/userID/Contacts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: 'hila', name: 'hilah', server: 'serve'})
    });
    console.log(r);
}

async function postMessege() {
    const r = await fetch('/api/userID/Contacts/hila/messeges', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ content: "bye" })
    });
    console.log(r);
}
async function delContact() {
    const r = await fetch('/api/userID/Contacts/hila', {
        method: 'DELETE'
    });
    console.log(r);
}

async function delMessege() {
    const r = await fetch('/api/userID/Contacts/hila/messeges/1', {
        method: 'DELETE'
    });
    console.log(r);
}

async function putContact() {
    const r = await fetch('/api/userID/Contacts/hila', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: 'hila', name: 'hilali', server: 'serve' })
    });
    console.log(r);
}
async function putMessege() {
    const r = await fetch('/api/userID/Contacts/hila/messeges/2', {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ content: 'stammmm' })
    });
    console.log(r);
}

async function postUser() {
    const r = await fetch('/api/add', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: 'userID', name: 'orpi', password: 'orpaz12345'})
    });
    console.log(r);
}

async function getAllUsers() {
    const r = await fetch('/api/users');
    const d = await r.json();
    console.log(d);
}

    async function getUser() {
    const r = await fetch('/api/user', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ id: 'userID', password: 'orpaz12345' })
    });
    console.log(r);
}

