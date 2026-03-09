const axios = require('axios');

async function test() {
    try {
        console.log('Fetching products...');
        const res = await axios.get('http://localhost:5176/api/Productos', {
            headers: {
                // We might need a token if it's [Authorize]
                // For now, let's see if it fails with 401, which confirms it's the right URL
            }
        });
        console.log('Success!');
        console.log('Keys of first product:', Object.keys(res.data[0]));
        console.log('productoProveedores type:', typeof res.data[0].productoProveedores);
        console.log('ProductoProveedores type:', typeof res.data[0].ProductoProveedores);
        console.log('Full first product:', JSON.stringify(res.data[0], null, 2));
    } catch (err) {
        console.error('Error:', err.response ? err.response.status : err.message);
        if (err.response && err.response.status === 401) {
            console.log('Authentication required. Need a token.');
        }
    }
}

test();
