process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
const axios = require('axios');

async function testApi() {
    try {
        const res = await axios.get('https://localhost:7183/api/Productos');
        console.log("Success! First product:", JSON.stringify(res.data[0], null, 2));
    } catch (err) {
        console.error("Error:", err.message);
    }
}
testApi();
