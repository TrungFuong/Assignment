const DetailPost = (props) => {
    return (
        <>
            <div>
                <p>id: {props?.data?.id}</p>
                <p>title: {props?.data?.title}</p>
                <p>body: {props?.data?.body}</p>
            </div>
        </>
    );
}