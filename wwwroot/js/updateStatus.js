document.querySelectorAll(".task-checkbox").forEach(function (checkbox) {
  checkbox.addEventListener("change", function () {
    var cardId = this.getAttribute("data-id");
    var isChecked = this.checked;

    fetch(`/Home/Get/${cardId}`)
      .then(response => response.json())
      .then(updatedCard => {
        updatedCard.status = isChecked;
        fetch(`/Home/SaveCard/${cardId}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(updatedCard),
        })
      });
  });
});
