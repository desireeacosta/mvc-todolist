document.querySelectorAll(".delete-button").forEach(function (deleteButton) {
  deleteButton.addEventListener("click", function () {
    var cardId = this.getAttribute("data-id");

    var confirmDelete = confirm("Are you sure you want to delete this card?");

    if (confirmDelete) {
      fetch(`/Home/DeleteCard/${cardId}`, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json'
        },
      })
        .then(response => {
          if (response.ok) {
            location.reload();
          } else {
            console.error('Error deleting card:', response.status);
          }
        })
        .catch(error => console.error('Error deleting card:', error));
    }
  });
});