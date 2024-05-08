window.addEventListener('pageshow', () => {
    fetchInvoices();
    document.getElementById('addInvoiceBtn').addEventListener('click', () => {
        window.location.href = 'add-edit-invoice.html';
    });
});

function createInvoiceRow(invoice) {
    const row = document.createElement('tr');
    row.dataset.id = invoice.id;
    row.innerHTML = `
        <td>${invoice.id}</td>
        <td>${invoice.number}</td>
        <td>${formatDate(invoice.date)}</td>
        <td>${invoice.clientName}</td>
        <td>${invoice.location.city}, ${invoice.location.address}</td>
        <td>
            <button class="btn btn-primary m-1 edit-btn" data-id="${invoice.id}" onclick="editInvoice(event)">
                <i class="fa fa-pencil" data-id="${invoice.id}"></i>
            </button>
            <button class="btn btn-danger m-1 delete-btn" data-id="${invoice.id}" onclick="deleteInvoice(event)">
                <i class="fa fa-trash" data-id="${invoice.id}"></i>
            </button>
        </td>
    `;
    return row;
}

function fetchInvoices() {
    fetch('/api/invoices')
        .then(response => {
            if (!response.ok) {
                throw new Error(`Failed to fetch invoices: ${response.statusText}`);
            }
            return response.json();
        })
        .then(data => {
            const tableBody = document.getElementById('invoicesBody');
            tableBody.innerHTML = '';

            data.forEach(invoice => {
                const row = createInvoiceRow(invoice);
                tableBody.appendChild(row);
            });
        })
        .catch(error => {
            console.error('Error fetching invoices:', error);
        });
}

function editInvoice(e) {
    const id = e.target.dataset.id;
    window.location.href = `add-edit-invoice.html?id=${id}`;
}

function deleteInvoice(e) {
    const id = e.target.dataset.id;
    const isConfirmed = confirm('Are you sure you want to delete this invoice?');
    if (isConfirmed) {
        fetch(`/api/invoices/${id}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`Failed to delete invoice (status: ${response.status})`);
                }
                console.log(`Invoice with ID ${id} has been successfully deleted.`);
                removeTableRow(id);
            })
            .catch(error => {
                console.error('Error deleting invoice:', error);
            });
    }
}

function removeTableRow(id) {
    const tableRow = document.querySelector(`#invoicesBody tr[data-id="${id}"]`);
    if (tableRow) {
        tableRow.remove();
    } else {
        console.warn(`Table row with ID ${id} not found.`);
    }
}

function formatDate(dateStr) {
    const date = new Date(dateStr);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    return `${year}-${month}-${day}`;
}

