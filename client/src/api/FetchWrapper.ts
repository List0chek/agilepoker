async function http(method: string, url: string, headers?: HeadersInit): Promise<any> {
  const response = await fetch(url, {
    method: method,
    headers: {
      'Content-Type': 'application/json',
      ...headers,
    },
  });

  let responseJSON;
  const contentType = response.headers.get('Content-Type');
  if (contentType && contentType.includes('application/json')) {
    responseJSON = await response.json();
  } else responseJSON = undefined;

  if (response.status === 200) {
    return responseJSON;
  } else {
    throw new Error(responseJSON?.message);
  }
}

export async function get(url: string, headers?: HeadersInit): Promise<any> {
  return await http('GET', url, headers);
}

export async function post(url: string, headers?: HeadersInit): Promise<any> {
  return await http('POST', url, headers);
}
