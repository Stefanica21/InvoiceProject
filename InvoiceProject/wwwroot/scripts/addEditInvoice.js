let isEditMode;
let editedInvoice;
let editedInvoiceDetails;
window.addEventListener('load', function () {
    function getUrlParameter(name) {
        const urlParams = new URLSearchParams(window.location.search);
        return urlParams.get(name);
    }
    const invoiceForm = document.querySelector('#numberInput');
    const numberInput = document.querySelector('#numberInput');
    const dateInput = document.querySelector('#dateInput');
    const clientNameInput = document.querySelector('#clientNameInput');
    const invoiceId = getUrlParameter('id');
    const title = document.querySelector('h1#title');
    const locationSelect = document.querySelector('select#locationSelect');
    const productNameInput = document.querySelector('#productNameInput');
    const amountInput = document.querySelector('#amountInput');
    const priceInput = document.querySelector('#priceInput');
    const valueInput = document.querySelector('#valueInput');
    invoiceId ? isEditMode = true : isEditMode = false;
    fetchLocations()
    if (isEditMode) {
        title.innerText = `Edit invoice, id=${invoiceId}`;
        fetchInvoiceById(invoiceId);
        fetchInvoiceDetailsById(invoiceId);
    } else {
        title.innerText = `Add new invoice`;
    }
    setUpNumberInputs();
});
function setUpNumberInputs() {
    const decimalInputs = document.querySelectorAll('.decimal-input');

    amountInput.addEventListener('input', event => {
        const inputValue = event.target.value;
        const numericValue = inputValue.replace(/[^0-9]/g, '');
        event.target.value = numericValue;
    });

    decimalInputs.forEach(input => {
        input.addEventListener('input', event => {
            const inputValue = event.target.value;
            const numericValue = inputValue.replace(/[^0-9.]/g, '');

            const decimalCount = numericValue.split('.').length - 1;
            if (decimalCount > 1) {
                const parts = numericValue.split('.');
                const integerPart = parts[0];
                const decimalPart = parts.slice(1).join('');
                event.target.value = `${integerPart}.${decimalPart}`;
            } else {
                event.target.value = numericValue;
            }
        });
    });
}
function fetchInvoiceById(invoiceId) {
    fetch(`/api/invoices/${invoiceId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`Failed to fetch invoice for edit: ${response.statusText}`);
            }
            return response.json();
        })
        .then(invoice => {
            editedInvoice = invoice;

            numberInput.value = invoice.number;
            dateInput.value = invoice.date.substring(0, 10);
            clientNameInput.value = invoice.clientName;
            const optionSelected = Array.from(locationSelect.options).find(option => option.value == invoice.locationId);
            if (optionSelected) 
                optionSelected.selected = true;
        })
        .catch(error => {
            console.error('Error fetching invoices:', error);
        });
}
function fetchInvoiceDetailsById(invoiceId) {
    fetch(`/api/invoices/details/${invoiceId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error(`Failed to fetch invoice details for edit: ${response.statusText}`);
            }
            return response.json();
        })
        .then(invoiceDetails => {
            editedInvoiceDetails = invoiceDetails;

            productNameInput.value = invoiceDetails.productName;
            amountInput.value = invoiceDetails.amount;
            priceInput.value = invoiceDetails.price;
            valueInput.value = invoiceDetails.value;
        })
        .catch(error => {
            console.error('Error fetching invoice details:', error);
        });
}
function fetchLocations() {
     fetch('/api/locations')
        .then(response => {
            if (!response.ok) {
                throw new Error(`Failed to fetch locations: ${response.statusText}`);
            }
            return response.json();
        })
        .then(data => {
            data.forEach(location => {
                const option = document.createElement('option');
                option.value = location.id;
                option.innerText = `${location.city}, ${location.address} (${location.postalCode})`;
                locationSelect.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error fetching invoices:', error);
        });
};
function createInvoice(){
    const formData = {
        number: document.getElementById('numberInput').value,
        date: document.getElementById('dateInput').value,
        clientName: document.getElementById('clientNameInput').value,
        locationId: parseInt(document.getElementById('locationSelect').value),
        productName: document.getElementById('productNameInput').value,
        amount: parseInt(document.getElementById('amountInput').value),
        price: parseFloat(document.getElementById('priceInput').value),
        value: parseFloat(document.getElementById('valueInput').value),
    };
    console.log(JSON.stringify(formData));
        fetch('/api/invoices', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Failed to save invoice');
                }
                invoiceForm.reset();
                alert('Invoice saved successfully!');
            })
            .catch(error => {
                console.error('Error saving invoice:', error);
                alert('Error saving invoice. Please try again.');
            });
}
function updateInvoice() {
    const formData = {
        id: editedInvoice.id,
        number: document.getElementById('numberInput').value,
        date: document.getElementById('dateInput').value,
        clientName: document.getElementById('clientNameInput').value,
        locationId: parseInt(document.getElementById('locationSelect').value),
        invoiceDetailsId: editedInvoiceDetails.id,
        productName: document.getElementById('productNameInput').value,
        amount: parseInt(document.getElementById('amountInput').value),
        price: parseFloat(document.getElementById('priceInput').value),
        value: parseFloat(document.getElementById('valueInput').value),
    };
    fetch(`/api/invoices/${editedInvoice.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to save invoice');
            }
            alert('Invoice updated successfully!');
        })
        .catch(error => {
            console.error('Error updating invoice:', error);
            alert('Error updating invoice. Please try again.');
        });
}


