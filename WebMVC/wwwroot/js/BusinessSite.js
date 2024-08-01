// wwwroot/js/site.js
let currentPage = 1;
const pageSize = 15;
let totalPages = 1;

document.addEventListener('DOMContentLoaded', function() {
    document.getElementById('searchForm').addEventListener('submit', async function(event) {
        event.preventDefault();
        currentPage = 1; // Reset to first page when a new search is performed
        fetchResults();
    });

    document.getElementById('clearButton').addEventListener('click', function() {
        document.getElementById('businessName').value = '';
        document.getElementById('sicCode').value = '';
    });

    document.getElementById('noneButton').addEventListener('click', function() {
        document.getElementById('businessName').value = '';
        document.getElementById('sicCode').value = '';
        document.getElementById('results').innerHTML = '';
        document.getElementById('pagination').innerHTML = '';
        document.getElementById('selectButton').classList.remove('active');
        document.getElementById('closeButton').classList.remove('active');
    });

    document.getElementById('pagination').addEventListener('click', function(event) {
        if (event.target.tagName === 'BUTTON') {
            const action = event.target.getAttribute('data-action');
            if (action === 'first') {
                currentPage = 1;
            } else if (action === 'previous') {
                if (currentPage > 1) {
                    currentPage--;
                }
            } else if (action === 'next') {
                if (currentPage < totalPages) {
                    currentPage++;
                }
            } else if (action === 'last') {
                currentPage = totalPages;
            }
            fetchResults();
        }
    });

    document.getElementById('pageInput').addEventListener('change', function(event) {
        const pageNumber = parseInt(event.target.value);
        if (pageNumber > 0 && pageNumber <= totalPages) {
            currentPage = pageNumber;
            fetchResults();
        }
    });

    document.getElementById('selectButton').addEventListener('click', function() {
        const selected = document.querySelector('input[name="selectBusiness"]:checked');
        if (selected) {
            alert(`Selected ID: ${selected.value}`);

            console.log(`Selected ID: ${selected.value}`);
        } else {
            alert('No business selected.');
        }
    });
    

    document.getElementById('closeButton').addEventListener('click', function() {
        document.getElementById('results').innerHTML = '';
        document.getElementById('pagination').innerHTML = '';
        document.getElementById('selectButton').classList.remove('active');
        document.getElementById('closeButton').classList.remove('active');
    });
});

async function fetchResults() {
    const businessName = document.getElementById('businessName').value;
    const sicCode = document.getElementById('sicCode').value;

    try {
        const response = await fetch(`http://localhost:5141/api/Business/search?businessName=${businessName}&sicCode=${sicCode}&page=${currentPage}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const data = await response.json();
        const resultsDiv = document.getElementById('results');
        resultsDiv.innerHTML = '';

        if (data.items.length > 0) {
            const table = document.createElement('table');
            const thead = document.createElement('thead');
            const tbody = document.createElement('tbody');

            const headerRow = document.createElement('tr');
            headerRow.innerHTML = `
                <th>Select</th>
                <th>Business Name</th>
                <th>SIC Code</th>
            `;
            thead.appendChild(headerRow);
            table.appendChild(thead);

            data.items.forEach(business => {
                const businessNameHighlighted = highlightText(business.businessName, businessName);
                const sicCodeHighlighted = highlightText(business.sicCode, sicCode);

                const row = document.createElement('tr');
                row.innerHTML = `
                    <td><input type="radio" name="selectBusiness" value="${business.id}"></td>
                    <td>${businessNameHighlighted}</td>
                    <td>${sicCodeHighlighted}</td>
                `;
                tbody.appendChild(row);
            });
            table.appendChild(tbody);
            resultsDiv.appendChild(table);

            totalPages = data.totalPagesResult;
            updatePagination();
            document.getElementById('selectButton').classList.add('active'); // Show Select button
            document.getElementById('closeButton').classList.add('active'); // Show Close button
        } else {
            resultsDiv.innerHTML = '<p>No results found</p>';
            document.getElementById('pagination').innerHTML = '';
            document.getElementById('selectButton').classList.remove('active'); // Hide Select button
            document.getElementById('closeButton').classList.remove('active'); // Hide Close button
        }
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

function highlightText(text, searchTerm) {
    if (!searchTerm) {
        return text;
    }
    const regex = new RegExp(`(${searchTerm})`, 'gi');
    return text.replace(regex, '<span class="highlight">$1</span>');
}

function updatePagination() {
    const paginationDiv = document.getElementById('pagination');
    paginationDiv.innerHTML = `
        <button data-action="first">Về trang 1</button>
        <button data-action="previous">Trang trước đó</button>
        <span>Page: <input type="number" id="pageInput" value="${currentPage}" min="1" max="${totalPages}"> of ${totalPages}</span>
        <button data-action="next">Trang tiếp theo</button>
        <button data-action="last">Trang cuối cùng</button>
    `;
}
