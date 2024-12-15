//// Inicializa uma lista ordenável com Sortable.js
//function initializeSortableList(elementId) {
//    const listElement = document.getElementById(elementId);

//    if (!listElement) {
//        console.error(`Elemento '${elementId}' não encontrado!`);
//        return;
//    }

//    new Sortable(listElement, {
//        animation: 150,
//        onEnd: function (evt) {
//            console.log('Nova ordem:', Array.from(evt.from.children).map(el => el.getAttribute('data-id')));

//            // Obtenha a nova ordem dos elementos
//            const newOrder = Array.from(evt.from.children).map(el => el.getAttribute('data-id'));

//            // Envie para o Blazor
//            DotNet.invokeMethodAsync('TrainningDeploy', 'UpdateOrdenation', newOrder)
//                .then(() => console.log('Ordem enviada para o Blazor com sucesso!'))
//                .catch(err => console.error('Erro ao enviar ordem para o Blazor:', err));
//        }
//    });
//}

//// Retorna a ordem atual de IDs de um elemento
//function getSortableOrder(elementId) {
//    const el = document.getElementById(elementId);
//    if (!el) {
//        console.error(`Elemento '${elementId}' não encontrado!`);
//        return [];
//    }

//    // Mapeia as IDs na ordem atual
//    return Array.from(el.children).map(item => item.getAttribute('data-id'));
//}

//// Escuta o evento DOMContentLoaded e inicializa automaticamente sortable-list
//document.addEventListener('DOMContentLoaded', function () {
//    initializeSortableList('sortable-list');
//});


function initializeWithInstance(dotNetObjectReference) {
    // Exemplo de chamada após 2 segundos
    setTimeout(() => {
        dotNetObjectReference.invokeMethodAsync('SayHelloAsync', 'John Doe')
            .then(() => console.log('Chamada bem-sucedida para o método .NET!'))
            .catch(err => console.error('Erro ao chamar método .NET:', err));
    }, 2000);
}
