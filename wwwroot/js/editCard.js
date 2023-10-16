document.querySelectorAll(".edit-button").forEach(function (editButton) {
  editButton.addEventListener("click", function () {
    var cardId = this.getAttribute("data-id");

    fetch(`/Home/Get/${cardId}`)
      .then(response => response.json())
      .then(updatedCard => {

        var newName = prompt("Enter new name:", updatedCard.name).trim();

        if (newName !== "") {
          var editedCard = {
            Name: newName,
            Status: updatedCard.status,
          };

          fetch(`/Home/SaveCard/${cardId}`, {
            method: 'PUT',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify(editedCard),
          })
            .then(response => {
              if (response.ok) {
                location.reload();
              } else {
                console.error('Error saving card:', response.status);
              }
            })
        } else {
          alert("Please enter a valid card name.");
        }
      })
  });
});