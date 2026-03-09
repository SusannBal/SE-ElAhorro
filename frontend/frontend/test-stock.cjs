process.env.NODE_TLS_REJECT_UNAUTHORIZED = '0';
const axios = require('axios');

async function testStockApi() {
    try {

        const res = await axios.put('https://localhost:7183/api/Productos/1/sumar-stock', {
            cantidad: 10
        });
        console.log("Success:", res.data);
    } catch (err) {
        console.error("Error:", err.response?.data || err.message);
    }
}
testStockApi();
