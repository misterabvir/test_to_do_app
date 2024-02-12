$(() => {

  $.get("/tasks/get-all", async (data) => {
    $.each(data, (index, item) => {
      addRow(item.id, item.name, item.description, item.status);
    });

    $("#createTask").click(() => {
      var name = $("#taskName").val();
      var description = $("#taskDescription").val();
      var request = {
        name: name,
        description: description
      };
      createTask(request);
    });
  });

  function createTask(request) {
    $.ajax({
      type: "POST",
      url: "/tasks/create",
      contentType: "application/json",
      data: JSON.stringify(request),
      success: async (response) => {
        addRow(response.data, request.name, request.description, "Created");
        $("#taskName").val("");
        $("#taskDescription").val("");
      },
      error: (xhr, status, error) => {
        console.error(xhr.responseText);
      }
    });
  }

  function addRow(id, name, description, status) {
    var tableBody = $("#dataTable tbody");
    var row = $("<tr>");
    row.attr("id", "task_" + id);

    row.append(createNameItem(id, name));
    row.append(createDescriptionItem(id, description));
    row.append(createStatusItem(id, status));
    row.append(createDeleteItem(id, row));

    tableBody.append(row);

  }

  function createStatusItem(id, status) {
    var btn = $("<button class='btn btn-success'>" + status + "</button>");
    if(btn.text()==='Resolved'){
      btn.attr('disabled', true);
    }
    btn.click(() =>
    $.ajax({
      type: "Put",
      url: "/tasks/update-status",
      contentType: "application/json",
      data: JSON.stringify({ id: id }),
      success: function (response) {
        if (response.isSuccess) {
          if(btn.text() === 'Created'){
            btn.text('InProgress');
          }
          else if(btn.text()==='InProgress')
          {
            btn.text('Resolved');
            btn.attr('disabled', true);
          }
        } else {
          console.log(response);
        }
      }
    }));

    var td = $("<td>").append(btn)
    return td;
  }

  function createDeleteItem(id, row) {
    var btn = $("<button class='btn btn-danger'>Delete</button>");
    btn.click(() =>
      $.ajax({
        type: "Delete",
        url: "/tasks/delete",
        contentType: "application/json",
        data: JSON.stringify({ id: id }),
        success: function (response) {
          if (response.isSuccess) {
            row.remove();
          } else {
            console.log(response);
          }
        }
      }));
      var td = $("<td>").append(btn)
    return td;
  };

  function createNameItem(id, name) {
    var input = $("<input class='form-control' type='text' value='" + name + "'/>").hide();
    var span = $("<span>").append(name);
    span.click(() => {
      span.hide();
      input.val(span.text());
      input.show();
    });
    input.blur(() => {

      input.hide();
      span.show();
      span.text(input.val());
      var request = {
        id: id,
        name: input.val()
      };
      $.ajax({
        type: "Put",
        url: "/tasks/update-name",
        contentType: "application/json",
        data: JSON.stringify(request),
        success: function (response) {
          if (response.isSuccess) {
            span.text(request.name);
            input.val(request.name);
          } else {
            console.log(response);
          }
        }
      });
    });
    return $("<td>").append(span).append(input)
  }

  function createDescriptionItem(id, description) {
    var input = $("<input type='text'  class='form-control'  value='" + description + "'/>").hide();
    var span = $("<span>").append(description);
    span.click(() => {
      span.hide();
      input.val(span.text());
      input.show();
    });
    input.blur(() => {

      input.hide();
      span.show();
      span.text(input.val());
      var request = {
        id: id,
        description: input.val()
      };
      $.ajax({
        type: "Put",
        url: "/tasks/update-description",
        contentType: "application/json",
        data: JSON.stringify(request),
        success: function (response) {
          if (response.isSuccess) {
            span.text(request.name);
            input.val(request.name);
          } else {
            console.log(response);
          }
        }
      });
    });
    return $("<td>").append(span).append(input)
  }
})