process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
const axios = require('axios');

async function testApi() {
    try {
        const res = await axios.post('https://localhost:7183/api/Proveedores', {
            nombre: "Test Provider",
            contacto: "John Doe",
            telefono: "12345678",
            email: "test@test.com",
            direccion: "Test St 123"
        });
        console.log("Success:", res.data);
    } catch (err) {
        console.error("Error:", err.response?.data || err.message);
    }
}
testApi();
