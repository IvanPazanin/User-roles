function editUserRoles(userId, roleId) {
    var inputCheckBox = document.getElementById(`input-${userId}-${roleId}`);

    $.ajax({
        method: 'POST',
        url: 'api/users/edituserroles',
        data: JSON.stringify({
            userId: userId,
            roleId: roleId,
            hasRole: !inputCheckBox.checked
        }),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            console.log(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr, ajaxOptions, thrownError);
        }
    });

}