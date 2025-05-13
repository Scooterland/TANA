window.initializeSortable = (id) => {
    const el = document.getElementById(id);
    if (!el) return;             

    if (el.__sortableInstance) return;

    el.__sortableInstance = new Sortable(el, {
        animation: 150,
        ghostClass: 'sortable-ghost',
        chosenClass: 'sortable-chosen'
    });
};

window.getSortedIds = (id) => {
    const el = document.getElementById(id);
    if (!el) return [];
    return Array.from(el.children).map(li => li.getAttribute("data-id"));
};

window.downloadFile = (fileName, bytesBase64) => {
    const link = document.createElement('a');
    link.href = "data:application/pdf;base64," + bytesBase64;
    link.download = fileName;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};
